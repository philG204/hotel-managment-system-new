using hotel.managment.system.Data.DB;
using hotel_managment_system;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hotel_managment_system_v2.Repositories
{
    public interface IEventRepository : IRepositoryBase<int, Event>
    {
    }
}
