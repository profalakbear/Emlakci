using System.Threading.Tasks;

namespace Data.RepositoryContracts
{
    public interface IEstateAgentRepository : IBaseRepository<EstateAgent>, IAuthRepository<EstateAgent>
    {
        Task<EstateAgent> GetByEmailAsync(string email);
    }
}
