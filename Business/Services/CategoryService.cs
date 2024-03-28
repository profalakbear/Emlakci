using Business.ServiceContracts;
using Data;
using Data.RepositoryContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;
        public CategoryService(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public List<EstateCategory> GetAll()
        {
            return _repository.GetAll();
        }

        public EstateCategory GetById(int id)
        {
            return _repository.GetById(id);
        }
    }
}
