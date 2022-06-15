using GettingBetter.API.GettingBetter_System.Domain.Models;

namespace GettingBetter.API.GettingBetter_System.Domain.Repositories;

public interface IStudentRepository
{
    Task<IEnumerable<Student>> ListAsync();
    Task AddAsync(Student student);
    Task<Student> FindByIdAsync(int studentId);
    //Task<IEnumerable<Student>> FindByCoachIdAsync(int coachId);
    void Update(Student student);
    void Remove(Student student);
}