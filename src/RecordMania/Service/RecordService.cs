namespace RecordMania.Service;

using Microsoft.EntityFrameworkCore;
using RecordMania.DAL;
using RecordMania.Models;

public class RecordService : IRecordService
{
    private readonly RecordManiaDbContext _dbContext;

    public RecordService(RecordManiaDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Record>> GetRecordsAsync(DateTime? createdAfter, int? languageId, int? taskId)
    {
        var query = _dbContext.Records
            .Include(r => r.Language)
            .Include(r => r.TaskS)
            .Include(r => r.Student)
            .AsQueryable();

        if (createdAfter.HasValue)
            query = query.Where(r => r.CreatedAt >= createdAfter.Value);

        if (languageId.HasValue)
            query = query.Where(r => r.LanguageId == languageId.Value);

        if (taskId.HasValue)
            query = query.Where(r => r.TaskId == taskId.Value);

        return await query
            .OrderByDescending(r => r.CreatedAt)
            .ThenBy(r => r.Student.LastName)
            .ToListAsync();
    }

    public async Task<Record> AddRecordAsync(RecordRequest request)
    {
       
        var language = await _dbContext.Languages.FindAsync(request.LanguageId);
        if (language == null)
            throw new ArgumentException("Language not found");

     
        var student = await _dbContext.Students.FindAsync(request.StudentId);
        if (student == null)
            throw new ArgumentException("Student not found");

      
        TaskS task = null;

        if (request.TaskId.HasValue)
        {
            task = await _dbContext.Tasks.FindAsync(request.TaskId.Value);

            
            if (task == null && !string.IsNullOrEmpty(request.TaskName) && !string.IsNullOrEmpty(request.TaskDescription))
            {
                task = new TaskS
                {
                    Name = request.TaskName,
                    Description = request.TaskDescription
                };
                _dbContext.Tasks.Add(task);
                await _dbContext.SaveChangesAsync();
            }
            else if (task == null)
            {
                throw new ArgumentException("Task not found");
            }
        }
        else if (!string.IsNullOrEmpty(request.TaskName) && !string.IsNullOrEmpty(request.TaskDescription))
        {
            
            task = new TaskS
            {
                Name = request.TaskName,
                Description = request.TaskDescription
            };
            _dbContext.Tasks.Add(task);
            await _dbContext.SaveChangesAsync();
        }
        else
        {
            throw new ArgumentException("Task information is missing");
        }

        var record = new Record
        {
            LanguageId = language.Id,
            StudentId = student.Id,
            TaskId = task.Id,
            ExecutionTime = request.ExecutionTime,
            CreatedAt = DateTime.UtcNow
        };

        _dbContext.Records.Add(record);
        await _dbContext.SaveChangesAsync();

        return record;
    }
}