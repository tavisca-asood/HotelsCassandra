using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace HotelsWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IHotels" in both code and config file together.
    [ServiceContract]
    public interface IHotels
    {
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "rooms", ResponseFormat = WebMessageFormat.Json)]
        List<Hotel> GetHotelData();
    }
}
