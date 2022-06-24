using GettingBetter.API.GettingBetter_System.Resources;

namespace GettingBetter.API.Learning_System.Resources;

public class LearningResource
{
    public int Id { get; set; }
    
    public CoachResource Coach { get; set; }
    public StudentResource Student { get; set; }
}