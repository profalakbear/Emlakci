using Data;
using System.Threading.Tasks;

namespace Business.ServiceContracts
{
    public interface IEstateAgentService : IBaseService<EstateAgent>, IAuthService<EstateAgent> 
    {
        Task<EstateAgent> GetByEmailAsync(string email);
    }
}
