using System.Threading.Tasks;

namespace Data.RepositoryContracts
{
    public interface IEstateRepository : IBaseRepository<Estate> 
    {
        Estate CreateAndReturnAsync(Estate entity);
    }
}
