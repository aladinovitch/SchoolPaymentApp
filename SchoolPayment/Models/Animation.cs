using System.ComponentModel.DataAnnotations;

namespace SchoolPayment.Models;
public class Animation
{
    public int Id { get; set; }

    [Required]
    public bool Attendance { get; set; }
    public string? Observation { get; set; }
    [Required]
    public int SessionId { get; set; }
    [Required]
    public int TeacherId { get; set; }

    public Teacher? Teacher { get; set; }
    public Session? Session { get; set; }
}
