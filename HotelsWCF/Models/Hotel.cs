using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace HotelsWCF
{
    [DataContract]
    public class Hotel
    {
        [DataMember]
        public int ID{ get; set; }
        [DataMember]
        public List<Room> Rooms{ get; set; }
    }
}