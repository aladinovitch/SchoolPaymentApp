using System.ComponentModel.DataAnnotations;

namespace SchoolPayment.Models;
public class Participation
{
    public int Id { get; set; }
    
    [Required]
    public bool Attendance { get; set; }
    public string? Observation { get; set; }
    [Required]
    public int SessionId { get; set; }
    [Required]
    public int StudentId { get; set; }
    
    public Session? Session { get; set; }
    public Student? Student { get; set; }  
}
