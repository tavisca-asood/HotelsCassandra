using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelsWCF
{
    public interface IRepository
    {
        List<Hotel> GetRooms();
    }
}
