using GettingBetter.API.Tournament_System.Domain.Models;

namespace GettingBetter.API.GettingBetter_System.Domain.Models;

public class Student
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string NickName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string UserImage { get; set; }
    public IList<RegisterTournament> RegisterTournaments { get; set; } = new List<RegisterTournament>();


}