using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HotelsWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Hotels" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Hotels.svc or Hotels.svc.cs at the Solution Explorer and start debugging.
    public class Hotels : IHotels
    {
        public List<Hotel> GetHotelData()
        {
            return new Database().instance.GetRooms();
        }
    }
}
