using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.ServiceContracts
{
    public interface IBaseService<T> where T : class
    {
        Task CreateAsync(T entity);
        Task<T> GetByIdAsync(int id);
        Task<List<T>> GetAllAsync();
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
    }
}
