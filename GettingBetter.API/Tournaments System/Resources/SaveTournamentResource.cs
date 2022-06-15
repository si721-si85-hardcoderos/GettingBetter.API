using System.ComponentModel.DataAnnotations;

namespace GettingBetter.API.Tournaments_System.Resources;

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
    public int StudentId { get; set; }
    //public Student Student { get; set; }
    [Required]
    public int CyberId { get; set; }
   
}