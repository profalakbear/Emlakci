using Business.Helpers;
using Business.ServiceContracts;
using Data;
using Data.RepositoryContracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public Task CreateAsync(User entity)
        {
            return _repository.CreateAsync(entity);
        }

        public Task DeleteAsync(int id)
        {
            return _repository.DeleteAsync(id);
        }

        public Task<List<User>> GetAllAsync()
        {
            return _repository.GetAllAsync();
        }

        public Task<User> GetByEmailAsync(string email)
        {
            return _repository.GetByEmailAsync(email);
        }

        public Task<User> GetByIdAsync(int id)
        {
            return _repository.GetByIdAsync(id);
        }

        public async Task<User> LoginAsync(string email, string password)
        {
            var user = await GetByEmailAsync(email);
            var isPasswordCorrect = AuthHelper.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt);
            if (isPasswordCorrect)
            {
                return user;
            }

            return null;
        }

        public Task<User> RegisterAsync(User entity)
        {
            var(passwordHash, passwordSalt) = AuthHelper.CreatePasswordHash(entity.Password);
            entity.Password = string.Empty;
            entity.PasswordHash = passwordHash;
            entity.PasswordSalt = passwordSalt;
            return _repository.RegisterAsync(entity);
        }

        public Task UpdateAsync(User entity)
        {
            return _repository.UpdateAsync(entity);
        }

    }
}
