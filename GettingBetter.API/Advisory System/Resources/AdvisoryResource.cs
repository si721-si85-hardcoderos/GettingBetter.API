using GettingBetter.API.GettingBetter_System.Resources;

namespace GettingBetter.API.Advisory_System.Resources;

public class AdvisoryResource
{
    public int Id { get; set; }
    public string AdvisoryImage  { get; set; }
    public string DiscorServer  { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Hour { get; set; }
    public string Date { get; set; }
    // Relationships
    
    public StudentResource Student { get; set; } 
    public CoachResource Coach { get; set; } 
}