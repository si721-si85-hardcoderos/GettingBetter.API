using System.ComponentModel.DataAnnotations;

namespace GettingBetter.API.Tournament_System.Resources;

public class SaveRegisterTournamentResource
{
    [Required]
    public int TournamentId { get; set; }
    [Required]
    public int StudentId { get; set; }
   
}