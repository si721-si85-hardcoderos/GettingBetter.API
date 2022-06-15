using GettingBetter.API.GettingBetter_System.Domain.Models;
using GettingBetter.API.GettingBetter_System.Domain.Services.Communication;

namespace GettingBetter.API.GettingBetter_System.Domain.Services;

public interface IStudentService
{
    Task<IEnumerable<Student>> ListAsync();
   // Task<IEnumerable<Student>> ListByCoachIdAsync(int coachId);
    Task<StudentResponse> SaveAsync(Student student);
    Task<StudentResponse> UpdateAsync(int studentId, Student student);
    Task<StudentResponse> DeleteAsync(int studentId);
}