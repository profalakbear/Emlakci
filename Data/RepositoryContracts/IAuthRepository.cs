using System.Threading.Tasks;

namespace Data.RepositoryContracts
{
    public interface IAuthRepository<T> where T : class
    {
        Task<T> RegisterAsync(T entity);
        Task<T> LoginAsync(string email, byte[] passwordHash);
        Task<bool> UserExistsAsync(string email);
    }
}
