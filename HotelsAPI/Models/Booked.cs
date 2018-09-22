using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelsAPI.Models
{
    public class Booked
    {
        [Key]
        public int ID{ get; set; }
        public string Name{ get; set; }
        public string Type{ get; set; }
        public int Price{ get; set; }
    }
}
