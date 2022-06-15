using GettingBetter.API.GettingBetter_System.Domain.Models;

namespace GettingBetter.API.Tournaments_System.Domain.Models;

public class Tournament
{
    public int Id { get; set; }
    public string Title{ get; set; }
    public string Description { get; set; }
    public string Date { get; set; }
    public string Addres { get; set; }
    // Relationships
    public int StudentId { get; set; }
    //public Student Student { get; set; }
    
    public int CyberId { get; set; }
    public Cyber Cyber { get; set; } 
}
