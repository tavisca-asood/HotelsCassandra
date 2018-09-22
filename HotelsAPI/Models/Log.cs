using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelsAPI.Models
{
    public class Log
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string IP { get; set; }
        [Required]
        public string Request { get; set; }
        public string Response { get; set; }
        public string Exception { get; set; }
        [Required]
        public DateTime Time { get; set; }
        public string Comment { get; set; }
    }
}
