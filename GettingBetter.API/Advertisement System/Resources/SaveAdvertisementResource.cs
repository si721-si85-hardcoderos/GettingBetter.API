using System.ComponentModel.DataAnnotations;

namespace GettingBetter.API.Advertisement_System.Resources;

public class SaveAdvertisementResource
{
    [Required]
    [MaxLength(30)]
    public string Title { get; set; } 
    
    [Required]
    [MaxLength(50)]
    public string Description { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string ImageAdvertisement { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string UrlPublication { get; set; }   
}