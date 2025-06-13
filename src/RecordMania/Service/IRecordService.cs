using RecordMania.Models;

namespace RecordMania.Service;

public interface IRecordService
{
    Task<IEnumerable<Record>> GetRecordsAsync(DateTime? createdAfter, int? languageId, int? taskId);
    Task<Record> AddRecordAsync(RecordRequest request);
}