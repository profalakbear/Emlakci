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
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _repository;
        public RoomService(IRoomRepository repository)
        {
            _repository = repository;
        }

        public List<Room> GetAll()
        {
            return _repository.GetAll();
        }

        public Room GetById(int id)
        {
            return _repository.GetById(id);
        }
    }
}
