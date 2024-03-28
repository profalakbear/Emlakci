using Business.ServiceContracts;
using Data;
using Data.RepositoryContracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Services
{
    public class PhotoService : IPhotoService
    {
        private readonly IPhotoRepository _repository;
        public PhotoService(IPhotoRepository repository)
        {
            _repository = repository;
        }

        public Task CreateAsync(Photo entity)
        {
            return _repository.CreateAsync(entity);
        }

        public Task DeleteAsync(int id)
        {
            return _repository.DeleteAsync(id);
        }

        public Task<List<Photo>> GetAllAsync()
        {
            return _repository.GetAllAsync();
        }

        public Task<Photo> GetByIdAsync(int id)
        {
            return _repository.GetByIdAsync(id);
        }

        public Task UpdateAsync(Photo entity)
        {
            return _repository.UpdateAsync(entity);
        }
    }
}
