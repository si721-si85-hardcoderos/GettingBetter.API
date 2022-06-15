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
   
    public int StudentId { get; set; }
    //public Student Student { get; set; }
    
    public CyberResource Cyber { get; set; } 
}