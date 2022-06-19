using System.ComponentModel.DataAnnotations;

namespace GettingBetter.API.Tournament_System.Resources;

public class SaveTournamentResource
{
    [Required]
    [MaxLength(30)]
    public string Title { get; set; } 
    
    [Required]
    [MaxLength(30)]
    public string Description { get; set; }
    
    [Required]
    [MaxLength(30)]
    public string Date { get; set; }
    
    [Required]
    [MaxLength(30)]
    public string Addres { get; set; }
    // Relationships
  
    [Required]
    public int CyberId { get; set; }
   
}