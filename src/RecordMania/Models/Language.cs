using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecordMania.Models;

public class Language
{

    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Name { get; set; }


    public ICollection<Record> Records { get; set; }
}