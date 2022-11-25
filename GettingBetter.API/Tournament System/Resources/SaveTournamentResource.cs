using System.ComponentModel.DataAnnotations;

namespace GettingBetter.API.Tournament_System.Resources
{

    public class SaveTournamentResource
    {
        [Required] [MaxLength(900)] public string Title { get; set; }

        [Required] [MaxLength(900)] public string Description { get; set; }

        [Required] [MaxLength(900)] public string Date { get; set; }

        [Required] [MaxLength(900)] public string Addres { get; set; }

        [Required] public int Capacity { get; set; }
        

        [Required] public int CyberId { get; set; }

    }
}