using System.Threading.Tasks;

namespace Data.RepositoryContracts
{
    public interface IUserRepository : IBaseRepository<User>, IAuthRepository<User>
    {
        Task<User> GetByEmailAsync(string email);
    }
}
