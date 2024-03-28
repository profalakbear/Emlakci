using Data.RepositoryContracts;
using Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly PropertyEntities _context;
        private readonly IUnitOfWork _unitOfWork;

        public CategoryRepository(PropertyEntities context, IUnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }

        public List<EstateCategory> GetAll()
        {
            return _context.EstateCategories.ToList();
        }

        public EstateCategory GetById(int id)
        {
            return _context.EstateCategories.Find(id);
        }
    }
}
