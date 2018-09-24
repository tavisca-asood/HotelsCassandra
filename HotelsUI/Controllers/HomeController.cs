using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using HotelsUI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HotelsUI.Controllers
{
    public class HomeController : Controller
    {
        string url = @"http://localhost:56424";
        public IActionResult Index()
        {
            return View();
        }
        public ActionResult Hotels()
        {
            List<Hotel> hotels = GetHotelsFromAPI();
            return View(hotels);
        }
        public ActionResult Rooms(int hotelID)
        {
            List<Hotel> hotels = GetHotelsFromAPI();
            List<Room> rooms = hotels.Find(x=>x.ID==hotelID).Rooms;
            ViewBag.Hotel = hotels.Find(x => x.ID == hotelID);
            return View(rooms);
        }
        public ActionResult Book(int hotelID,string type,int price)
        {
            Task.Run(()=>BookHotel(hotelID, type, price));
            return View("~/Views/Home/Index.cshtml");
        }
        public ActionResult Bookings()
        {
            List<Booked> bookings = GetBookedHotels();
            return View(bookings);
        }


        public List<Hotel> GetHotelsFromAPI()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.GetAsync(@"/api/hotels").Result;
                if (response.IsSuccessStatusCode)
                {
                    string jsonData = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<List<Hotel>>(jsonData);
                }
            }
            return null;
        }
        public void BookHotel(int hotelID, string type, int price)
        {
            using (var client = new HttpClient())
            {
                Dictionary<string, string> roomType = new Dictionary<string, string>();
                roomType.Add("type", type);
                roomType.Add("price", price.ToString());
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var content = new FormUrlEncodedContent(roomType);
                HttpResponseMessage response = client.PostAsync(@"/api/hotels/"+hotelID, content).Result;
                if (response.IsSuccessStatusCode)
                {
                }
            }
        }
        public List<Booked> GetBookedHotels()
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.GetAsync(@"http://localhost:56424/api/booked").Result;
                if (response.IsSuccessStatusCode)
                {
                    string jsonData = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<List<Booked>>(jsonData);
                }
            }
            return null;
        }
    }
}
