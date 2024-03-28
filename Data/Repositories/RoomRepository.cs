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
    public class RoomRepository : IRoomRepository
    {
        private readonly PropertyEntities _context;
        private readonly IUnitOfWork _unitOfWork;

        public RoomRepository(PropertyEntities context, IUnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }

        public List<Room> GetAll()
        {
            try
            {
                return _context.Rooms.ToList();
            } catch
            {
                return null;
            }
        }

        public Room GetById(int id)
        {
            return _context.Rooms.Find(id);
        }
    }
}
