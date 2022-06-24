using GettingBetter.API.GettingBetter_System.Domain.Models;
namespace GettingBetter.API.Advisory_System.Domain.Models;

public class Advisory
{
    public int Id { get; set; }
    public string AdvisoryImage  { get; set; }
    public string DiscorServer  { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Hour { get; set; }
    public string Date { get; set; }
   
    public int StudentId  { get; set; } 
    public int CoachId  { get; set; }

    public Student Student  { get; set; }
    public Coach Coach  { get; set; }
    public IList<Student> Students { get; set; } = new List<Student>();
    public IList<Coach> Coaches { get; set; } = new List<Coach>();

}