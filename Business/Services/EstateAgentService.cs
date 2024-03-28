using Business.Helpers;
using Business.ServiceContracts;
using Data;
using Data.RepositoryContracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Services
{
    public class EstateAgentService : IEstateAgentService
    {
        private readonly IEstateAgentRepository _repository;
        public EstateAgentService(IEstateAgentRepository repository)
        { 
            _repository = repository;
        }

        public Task CreateAsync(EstateAgent entity)
        {
            return _repository.CreateAsync(entity);
        }

        public Task DeleteAsync(int id)
        {
            return _repository.DeleteAsync(id);
        }

        public Task<List<EstateAgent>> GetAllAsync()
        {
            return _repository.GetAllAsync();
        }

        public Task<EstateAgent> GetByEmailAsync(string email)
        {
            return _repository.GetByEmailAsync(email);
        }

        public Task<EstateAgent> GetByIdAsync(int id)
        {
            return _repository.GetByIdAsync(id);
        }

        public async Task<EstateAgent> LoginAsync(string email, string password)
        {
            var agent = await GetByEmailAsync(email);
            var isPasswordCorrect = AuthHelper.VerifyPasswordHash(password, agent.PasswordHash, agent.PasswordSalt);
            if (isPasswordCorrect)
            {
                return agent;
            }

            return null;
        }

        public Task<EstateAgent> RegisterAsync(EstateAgent entity)
        {
            var (passwordHash, passwordSalt) = AuthHelper.CreatePasswordHash(entity.Password);
            entity.Password = string.Empty;
            entity.PasswordHash = passwordHash;
            entity.PasswordSalt = passwordSalt;
            return _repository.RegisterAsync(entity);
        }

        public Task UpdateAsync(EstateAgent entity)
        {
            return _repository.UpdateAsync(entity);
        }
    }
}
