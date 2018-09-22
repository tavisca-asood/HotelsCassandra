using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using HotelsAPI;
using HotelsAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Service.Models;

namespace Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        [Log]
        public ActionResult<IEnumerable<Hotel>> Get()
        {
            return GetHotels().Result;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        [Log]
        public ActionResult<string> Get(int id)
        {
            return string.Empty;
        }

        //POST api/values
        [HttpPost("{id}")]
        [Log]
        public void Post(int id, [FromBody]JObject details)
        {
            HotelJSON hotelJSON = GetDataFromJSON().Find(x => x.ID == id);
            Booked booked = new Booked()
            {
                Name = hotelJSON.Name,
                Type = details["type"].ToString(),
                Price = int.Parse(details["price"].ToString())
            };
            new Database().instance.Book(booked);
        }

        //PUT api/values/5
        [HttpPut("{id}")]
        [Log]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        [Log]
        public void Delete(int id)
        {
        }
        public async Task<List<Hotel>> GetHotels()
        {
            Task<List<HotelJSON>> json = new Task<List<HotelJSON>>(GetDataFromJSON);
            json.Start();
            Task<List<HotelWCF>> wcf = new Task<List<HotelWCF>>(GetDataFromWCF);
            wcf.Start();
            List<HotelJSON> hotelsJSON = await json;
            List<HotelWCF> hotelsWCF = await wcf;
            return Hotels.MergeHotelData(hotelsJSON, hotelsWCF);
        }
        public List<HotelJSON> GetDataFromJSON()
        {
            List<HotelJSON> hotels = new List<HotelJSON>();
            using (StreamReader r = new StreamReader(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "/data.json"))
            {
                string json = r.ReadToEnd();
                hotels = JsonConvert.DeserializeObject<List<HotelJSON>>(json);
            }
            return hotels;
        }
        public List<HotelWCF> GetDataFromWCF()
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.GetAsync(@"http://localhost:49844/Hotels.svc/rooms").Result;
                if (response.IsSuccessStatusCode)
                {
                    string jsonData = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<List<HotelWCF>>(jsonData);
                }
            }
            return null;
        }
    }
}
