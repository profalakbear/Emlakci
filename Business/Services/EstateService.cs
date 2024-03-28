using Business.ServiceContracts;
using Data;
using Data.RepositoryContracts;
using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Contexts;
using System.Threading.Tasks;

namespace Business.Services
{
    public class EstateService : IEstateService
    {
        private readonly IEstateRepository _repository;
        public EstateService(IEstateRepository repository)
        {
            _repository = repository;
        }

        public Estate CreateAndReturnAsync(Estate entity)
        {
            var user = _repository.CreateAndReturnAsync(entity);
            return user;
        }

        public Task CreateAsync(Estate entity)
        {
            return _repository.CreateAsync(entity);
        }

        public Task DeleteAsync(int id)
        {
            return _repository.DeleteAsync(id);
        }

        public Task<List<Estate>> GetAllAsync()
        {
            return _repository.GetAllAsync();
        }

        public Task<Estate> GetByIdAsync(int id)
        {
            return _repository.GetByIdAsync(id);
        }

        public Task UpdateAsync(Estate entity)
        {
            return _repository.UpdateAsync(entity);
        }
    }
}
