using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecordMania.Models;
[Table("Student")]
public class Student
{

    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string FirstName { get; set; }

    [Required]
    [StringLength(100)]
    public string LastName { get; set; }

    [Required]
    [StringLength(250)]
    [EmailAddress]
    public string Email { get; set; }
    
    public ICollection<Record> Records { get; set; }
}