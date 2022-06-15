using GettingBetter.API.GettingBetter_System.Domain.Models;
using GettingBetter.API.GettingBetter_System.Domain.Repositories;
using GettingBetter.API.Shared.Persistence.Contexts;
using GettingBetter.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GettingBetter.API.GettingBetter_System.Persistence.Repositories;

public class StudentRepository : BaseRepository, IStudentRepository
{
    public StudentRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Student>> ListAsync()
    {
        return await _context.Students.ToListAsync();
    }

    public async Task AddAsync(Student student)
    {
        await _context.Students.AddAsync(student);
    }

    public async Task<Student> FindByIdAsync(int studentId)
    {
        return await _context.Students.FindAsync(studentId);

    }

  

 /*   public async Task<IEnumerable<Student>> FindByCoachIdAsync(int coachId)
    {
        return await _context.Students
            .Where(p => p.CoachId == coachId)
            .Include(p => p.Coach)
            .ToListAsync();
    }
*/
    public void Update(Student student)
    {
        _context.Students.Update(student);
    }

    public void Remove(Student student)
    {
        _context.Students.Remove(student);
    } 
}