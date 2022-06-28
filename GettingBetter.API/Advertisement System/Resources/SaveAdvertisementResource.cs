using System.ComponentModel.DataAnnotations;

namespace GettingBetter.API.Advertisement_System.Resources;

public class SaveAdvertisementResource
{
    [Required]
    [MaxLength(50)]
    public string Title { get; set; } 
    
    [Required]
    [MaxLength(900)]
    public string Description { get; set; }
    
    [Required]
    [MaxLength(120)]
    public string ImageAdvertisement { get; set; }
    
    [Required]
    [MaxLength(120)]
    public string UrlPublication { get; set; }   
}