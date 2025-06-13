using System.ComponentModel.DataAnnotations; // <--- Make sure this is present
using System.ComponentModel.DataAnnotations.Schema; // <--- Make sure this is present

namespace RecordMania.Models;

[Table("Task")]
public class TaskS
{
    [Key]
    public int Id { get; set; }

    [Required] 
    [StringLength(100)] 
    public string Name { get; set; }

    [StringLength(2000)] 
    public string Description { get; set; }
    
    public ICollection<Record> Records { get; set; }

}