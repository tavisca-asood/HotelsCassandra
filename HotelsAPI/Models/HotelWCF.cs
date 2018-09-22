using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Models
{
    public class HotelWCF
    {
        public int ID{ get; set; }
        public List<Room> Rooms{ get; set; }
    }
}
