using GettingBetter.API.GettingBetter_System.Domain.Models;
using GettingBetter.API.Shared.Domain.Services.Communication;

namespace GettingBetter.API.GettingBetter_System.Domain.Services.Communication;

public class StudentResponse : BaseResponse<Student>
{
    public StudentResponse(string message) : base(message)
    {
    }

    public StudentResponse(Student resource) : base(resource)
    {
    } 
}