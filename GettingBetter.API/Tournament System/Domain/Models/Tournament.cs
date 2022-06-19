using GettingBetter.API.GettingBetter_System.Domain.Models;

namespace GettingBetter.API.Tournament_System.Domain.Models;

public class Tournament
{
    public int Id { get; set; }
    public string Title{ get; set; }
    public string Description { get; set; }
    public string Date { get; set; }
    public string Addres { get; set; }
    // Relationships
    
    public int CyberId { get; set; }
    public Cyber Cyber { get; set; }
    
    public IList<RegisterTournament> RegisterTournaments { get; set; } = new List<RegisterTournament>();
}
