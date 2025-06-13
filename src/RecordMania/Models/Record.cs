using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecordMania.Models;

public class Record
{

    public int Id { get; set; }

    [Required]
    public int LanguageId { get; set; }

    [Required]
    public int TaskId { get; set; }

    [Required]
    public int StudentId { get; set; }

    [Required]
    public long ExecutionTime { get; set; } 

    [Required]
    public DateTime CreatedAt { get; set; } 
    
    [ForeignKey("LanguageId")]
    public Language Language { get; set; }

    [ForeignKey("TaskId")]
    public TaskS TaskS { get; set; }

    [ForeignKey("StudentId")]
    public Student Student { get; set; }
}