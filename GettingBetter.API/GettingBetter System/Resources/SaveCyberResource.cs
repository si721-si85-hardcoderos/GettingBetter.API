using System.ComponentModel.DataAnnotations;
using Swashbuckle.AspNetCore.Annotations;

namespace GettingBetter.API.GettingBetter_System.Resources;



public class SaveCyberResource
{
        [Required] 
        [MaxLength(30)] 
        public string FirstName { get; set; }
        
        [Required] 
        [MaxLength(30)] 
        public string LastName { get; set; }
        
        [Required] 
        [MaxLength(30)] 
        public string CyberName { get; set; }
        
        [Required] 
        [MaxLength(30)] 
        public string Bibliography { get; set; }
        
        [Required] 
        [MaxLength(30)] 
        public string Address { get; set; }
        
        [Required] 
        [MaxLength(30)] 
        public string Email { get; set; }

        [Required] 
        [MaxLength(30)] 
        public string Password { get; set; } 
}
