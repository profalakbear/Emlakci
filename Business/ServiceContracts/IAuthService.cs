using System.Threading.Tasks;

namespace Business.ServiceContracts
{
    public interface IAuthService<T> where T : class
    {
        Task<T> RegisterAsync(T entity);
        Task<T> LoginAsync(string email, string password);
    }
}
