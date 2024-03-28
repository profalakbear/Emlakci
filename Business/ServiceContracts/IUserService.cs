using Data;
using System.Threading.Tasks;

namespace Business.ServiceContracts
{
    public interface IUserService : IBaseService<User>, IAuthService<User> 
    {
        Task<User> GetByEmailAsync(string email);
    }
}
