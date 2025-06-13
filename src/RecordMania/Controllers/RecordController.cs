using Microsoft.AspNetCore.Mvc;
using RecordMania.Models;
using RecordMania.Service;

[ApiController]
[Route("api/records")]
public class RecordsController : ControllerBase
{
    private readonly IRecordService _recordService;

    public RecordsController(IRecordService recordService)
    {
        _recordService = recordService;
    }

    [HttpGet]
    public async Task<IActionResult> GetRecords(DateTime? createdAfter, int? languageId, int? taskId)
    {
        try
        {
            var records = await _recordService.GetRecordsAsync(createdAfter, languageId, taskId);
            return Ok(records);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Message = "An error occurred while retrieving records.", Error = ex.Message });
        }
    }

    [HttpPost]
    public async Task<IActionResult> AddRecord([FromBody] RecordRequest request)
    {
        try
        {
            var record = await _recordService.AddRecordAsync(request);
            return CreatedAtAction(nameof(GetRecords), new { id = record.Id }, record);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { Message = ex.Message });
        }
        catch (Exception)
        {
            return StatusCode(500, new { Message = "An error occurred while adding the record." });
        }
    }
}