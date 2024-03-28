using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.RepositoryContracts
{
    public interface IRoomRepository
    {
        Room GetById(int id);
        List<Room> GetAll();
    }
}
