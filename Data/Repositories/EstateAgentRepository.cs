using Data.RepositoryContracts;
using Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class EstateAgentRepository : IEstateAgentRepository
    {
        private readonly PropertyEntities _context;
        private readonly IUnitOfWork _unitOfWork;

        public EstateAgentRepository(PropertyEntities context, IUnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }

        public async Task CreateAsync(EstateAgent entity)
        {
            _context.EstateAgents.Add(entity);
            await _unitOfWork.SaveChangesAsync();
            //await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var estateAgent = await _context.EstateAgents.FindAsync(id);
            if (estateAgent != null)
            {
                _context.EstateAgents.Remove(estateAgent);
                await _unitOfWork.SaveChangesAsync();
                //await _context.SaveChangesAsync();
            }
        }

        public async Task<List<EstateAgent>> GetAllAsync()
        {
            return await _context.EstateAgents.ToListAsync();
        }

        public async Task<EstateAgent> GetByIdAsync(int id)
        {
            return await _context.EstateAgents.FindAsync(id);
        }

        public async Task UpdateAsync(EstateAgent entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _unitOfWork.SaveChangesAsync();
            //await _context.SaveChangesAsync();
        }

        public async Task<EstateAgent> GetByEmailAsync(string email)
        {
            return await _context.EstateAgents.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<EstateAgent> LoginAsync(string email, byte[] passwordHash)
        {
            return await _context.EstateAgents.FirstOrDefaultAsync(e => e.Email == email && e.PasswordHash == passwordHash);
        }

        public async Task<EstateAgent> RegisterAsync(EstateAgent newAgent)
        {
            var existingAgent = await _context.EstateAgents.FirstOrDefaultAsync(u => u.Email == newAgent.Email);
            if (existingAgent != null)
            {
                throw new InvalidOperationException("Agent with this email already exists.");
            }

            _context.EstateAgents.Add(newAgent);
            await _unitOfWork.SaveChangesAsync();
            //await _context.SaveChangesAsync();

            return newAgent;
        }

        public async Task<bool> UserExistsAsync(string email)
        {
            return await _context.EstateAgents.AnyAsync(e => e.Email == email);
        }
    }
}
