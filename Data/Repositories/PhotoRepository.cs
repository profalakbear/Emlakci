using Data.RepositoryContracts;
using Data.UnitOfWork;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class PhotoRepository : IPhotoRepository
    {
        private readonly PropertyEntities _context;
        private readonly IUnitOfWork _unitOfWork;

        public PhotoRepository(PropertyEntities context, IUnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }

        public async Task CreateAsync(Photo entity)
        {
            _context.Photos.Add(entity);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var photo = await _context.Photos.FindAsync(id);
            if (photo != null)
            {
                _context.Photos.Remove(photo);
                await _unitOfWork.SaveChangesAsync();
            }
        }

        public async Task<List<Photo>> GetAllAsync()
        {
            return await _context.Photos.ToListAsync();
        }

        public async Task<Photo> GetByIdAsync(int id)
        {
            return await _context.Photos.FindAsync(id);
        }

        public async Task UpdateAsync(Photo entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
