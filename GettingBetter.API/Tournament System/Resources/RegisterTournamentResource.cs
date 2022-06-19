using GettingBetter.API.GettingBetter_System.Domain.Models;
using GettingBetter.API.GettingBetter_System.Resources;

namespace GettingBetter.API.Tournament_System.Resources;

public class RegisterTournamentResource
{
    public int Id { get; set; }
    public TournamentResource Tournament { get; set; } 
    public StudentResource Student { get; set; } 
}