using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Students")]
public class Student
{
    [Key]
    public int StudentId { get; set; }
    public string FullName { get; set; }
    public int Age { get; set; }
    public string Major { get; set; }
}