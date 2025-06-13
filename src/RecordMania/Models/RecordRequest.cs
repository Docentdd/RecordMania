namespace RecordMania.Models;

public class RecordRequest
{
    public int LanguageId { get; set; }
    public int StudentId { get; set; }
    public int? TaskId { get; set; }
    public string? TaskName { get; set; }
    public string? TaskDescription { get; set; }
    public long ExecutionTime { get; set; }
}