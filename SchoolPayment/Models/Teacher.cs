using System.ComponentModel.DataAnnotations;

namespace SchoolPayment.Models;
public class Teacher
{
    public int Id { get; set; }
    
    public string? Number { get; set; }
    [Required]
    public string? Lname { get; set; }
    [Required]
    public string? Fname { get; set; }
    [Required]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
    public DateTime Birthdate { get; set; }
    
    
    public ICollection<Payment>? TeacherPayments { get; set; }
    public ICollection<Animation>? TeacherAnimations { get; set; }    
}
