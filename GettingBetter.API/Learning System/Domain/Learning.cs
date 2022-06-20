using GettingBetter.API.GettingBetter_System.Domain.Models;

namespace GettingBetter.API.Learning_System.Domain;

public class Learning
{
    public int Id { get; set; }
    public int StudentId { get; set; }
    public int CoachId { get; set; }
    public Student Student  { get; set; }
    public Coach Coach  { get; set; }
}