using System.ComponentModel.DataAnnotations;

namespace SchoolPayment.Models;
public class Deposit
{
    public int Id { get; set; }
    
    [Required]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
    public DateTime Date { get; set; }
    [Required]
    public int Amount { get; set; }
    [Required]
    public int StudentId { get; set; }
    
    public Student? Student { get; set; }  
}
