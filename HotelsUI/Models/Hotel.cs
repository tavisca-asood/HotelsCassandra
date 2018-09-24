using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelsUI.Models
{
    public class Hotel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Amenities { get; set; }
        public string Address { get; set; }
        public List<Room> Rooms { get; set; }
    }
}
