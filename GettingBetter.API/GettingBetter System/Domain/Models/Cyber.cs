using GettingBetter.API.Tournament_System.Domain.Models;

namespace GettingBetter.API.GettingBetter_System.Domain.Models;


public class Cyber
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CyberName { get; set; }
        public string Bibliography { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
       
        public string CyberImage { get; set; } 
        public IList<Tournament> Tournaments { get; set; } = new List<Tournament>();
        
        
}

