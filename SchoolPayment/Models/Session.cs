using System.ComponentModel.DataAnnotations;

namespace SchoolPayment.Models;
public class Session
{
    public int Id { get; set; }
    
    [Required]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime Date { get; set; }
    public int Number { get; set; }
    [Required]
    public int ModuleId { get; set; }
    
    public Module? Module { get; set; }
    
    public ICollection<Participation>? SessionParticipations { get; set; }
    public ICollection<Animation>? SessionAnimations { get; set; } 
}
