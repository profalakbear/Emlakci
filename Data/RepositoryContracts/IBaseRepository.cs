using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.RepositoryContracts
{
    public interface IBaseRepository<T> where T : class
    {
        Task CreateAsync(T entity);
        Task<T> GetByIdAsync(int id);
        Task<List<T>> GetAllAsync();
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
    }
}
