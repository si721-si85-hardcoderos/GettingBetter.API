using GettingBetter.API.GettingBetter_System.Resources;

namespace GettingBetter.API.Tournament_System.Resources;

public class TournamentResource
{
    public int Id { get; set; }
   
    public string Title { get; set; }
    
    public string Description { get; set; }
    
    public string Date { get; set; }
    
    public string Addres { get; set; }
    // Relationships
    
    public CyberResource Cyber { get; set; } 
}