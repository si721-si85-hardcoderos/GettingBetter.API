using GettingBetter.API.GettingBetter_System.Domain.Models;
using GettingBetter.API.Shared.Domain.Services.Communication;

namespace GettingBetter.API.GettingBetter_System.Domain.Services.Communication;


    public class CyberResponse : BaseResponse<Cyber>
    {
        public CyberResponse(string message) : base(message)
        {
        }

        public CyberResponse(Cyber resource) : base(resource)
        {
        }
    }

