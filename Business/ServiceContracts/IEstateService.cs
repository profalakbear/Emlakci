using Data;

namespace Business.ServiceContracts
{
    public interface IEstateService : IBaseService<Estate>
    {
        Estate CreateAndReturnAsync(Estate entity);
    }
}
