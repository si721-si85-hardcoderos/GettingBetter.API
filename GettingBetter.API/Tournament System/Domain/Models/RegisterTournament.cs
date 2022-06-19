using GettingBetter.API.GettingBetter_System.Domain.Models;

namespace GettingBetter.API.Tournament_System.Domain.Models;

public class RegisterTournament
{
    public int Id { get; set; }
    public int TournamentId { get; set; }
    public Tournament Tournament { get; set; }
    public int StudentId { get; set; }
    public Student Student { get; set; }
    public IList<Student> Students { get; set; } = new List<Student>();
}