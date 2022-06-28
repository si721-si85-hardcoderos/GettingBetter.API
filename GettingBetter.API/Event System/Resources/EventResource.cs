using GettingBetter.API.GettingBetter_System.Resources;

namespace GettingBetter.API.Event_System.Resources;

public class EventResource
{
    public int Id { get; set; }

    public string ImageEvent { get; set; }

    public string UrlPublication { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }
    
    public string Address { get; set; } 
    // Relationships
    
    public CyberResource Cyber { get; set; } 
}