using System.ComponentModel.DataAnnotations;

namespace SchoolPayment.Models;
public class Student
{
    public int Id { get; set; }
    
    public string? Number { get; set; }
    [Required]
    [Display(Name ="Last name")]
    public string? Lname { get; set; }
    [Required]
    [Display(Name = "First name")]
    public string? Fname { get; set; }
    [Required]
    public DateTime Birthdate { get; set; }
    [Required]
    [Display(Name = "Registration date")]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
    public DateTime Registration { get; set; }
    [Required]
    public float Discount { get; set; }
    
    
    public ICollection<Deposit>? StudentDeposits { get; set; }
    public ICollection<Participation>? StudentParticipations { get; set; }  
}

