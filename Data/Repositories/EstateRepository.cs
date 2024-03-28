using Data.RepositoryContracts;
using Data.UnitOfWork;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class EstateRepository : IEstateRepository
    {
        private readonly PropertyEntities _context;
        private readonly IUnitOfWork _unitOfWork;

        public EstateRepository(PropertyEntities context, IUnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }

        public Estate CreateAndReturnAsync(Estate entity)
        {
            var user = _context.Estates.Add(entity);
            _context.SaveChanges();
            return user;
        }

        public async Task CreateAsync(Estate entity)
        {
            _context.Estates.Add(entity);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var estate = await _context.Estates.FindAsync(id);
            if (estate != null)
            {
                _context.Estates.Remove(estate);
                await _unitOfWork.SaveChangesAsync();
            }
        }

        public async Task<List<Estate>> GetAllAsync()
        {
            return await _context.Estates.ToListAsync();
        }

        public async Task<Estate> GetByIdAsync(int id)
        {
            return await _context.Estates.FindAsync(id);
        }

        public async Task UpdateAsync(Estate entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
