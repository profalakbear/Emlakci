using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ServiceContracts
{
    public interface IRoomService
    {
        Room GetById(int id);
        List<Room> GetAll();
    }
}
