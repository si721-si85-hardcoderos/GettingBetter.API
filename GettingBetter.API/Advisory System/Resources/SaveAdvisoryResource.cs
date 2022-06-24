using System.ComponentModel.DataAnnotations;

namespace GettingBetter.API.Advisory_System.Resources;

public class SaveAdvisoryResource
{
    [Required]
    [MaxLength(200)]
    public string AdvisoryImage  { get; set; }
    
    [Required]
    [MaxLength(150)]
    public string DiscorServer  { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string Title { get; set; }
    
    [Required]
    [MaxLength(300)]
    public string Description { get; set; }
    
    [Required]
    [MaxLength(10)]
    public string Hour { get; set; }
    
    
    [Required]
    [MaxLength(10)]
    public string Date { get; set; }
    
    // Relationships
  
    [Required]
    public int StudentId { get; set; }
    [Required]
    public int CoachId { get; set; }
   
}