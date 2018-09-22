using Newtonsoft.Json;
using Service.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Service
{
    public class Hotels
    {
        public static List<Hotel> MergeHotelData(List<HotelJSON> json, List<HotelWCF> wcf)
        {
            List<Hotel> hotels = new List<Hotel>();
            for(int i=0;i<json.Count;i++)
            {
                hotels.Add(new Hotel()
                {
                    ID=json[i].ID,
                    Name=json[i].Name,
                    Address=json[i].Address,
                    Amenities=json[i].Amenities,
                    Rooms=wcf[i].Rooms
                });
            }
            return hotels;
        }
    }
}
