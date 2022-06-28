using System.ComponentModel.DataAnnotations;

namespace GettingBetter.API.Learning_System.Resources;

public class SaveLearningResource
{
    [Required]
    public int StudentId { get; set; }
    [Required]
    public int CoachId { get; set; }
}