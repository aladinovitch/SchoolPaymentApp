using System.ComponentModel.DataAnnotations;

namespace SchoolPayment.Models;
public class Module
{
    public int Id { get; set; }
    
    [Required]
    public string? Name { get; set; }
    public string? Code { get; set; }
    
    
    public ICollection<Session>? ModuleSessions { get; set; }  
}
