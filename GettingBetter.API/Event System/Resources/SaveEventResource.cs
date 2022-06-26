using System.ComponentModel.DataAnnotations;

namespace GettingBetter.API.Event_System.Resources;

public class SaveEventResource
{
    [Required]
    [MaxLength(50)]
    public string ImageEvent { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string UrlPublication { get; set; }
    
    [Required]
    [MaxLength(30)]
    public string Title { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string Description { get; set; }
    
    [Required]
    [MaxLength(30)]
    public string Address { get; set; } 
    // Relationship

    [Required]
    public int CyberId { get; set; }
   
}