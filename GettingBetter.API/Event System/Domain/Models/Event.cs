
using GettingBetter.API.GettingBetter_System.Domain.Models;

namespace GettingBetter.API.Event_System.Domain.Models;

public class Event
{
    public int Id { get; set; }
    public string ImageEvent { get; set; }
    public string UrlPublication { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Address { get; set; } 
    // Relationship

    public int CyberId { get; set; }
    public Cyber Cyber { get; set; }
    
}