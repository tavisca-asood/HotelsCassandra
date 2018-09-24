using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelsAPI.Models
{
    public interface IRepository
    {
        void Book(Booked booked);
        List<Booked> GetBookedHotels();
    }
}
