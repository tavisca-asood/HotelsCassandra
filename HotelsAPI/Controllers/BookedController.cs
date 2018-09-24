using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelsAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookedController : ControllerBase
    {
        // GET: api/Booked
        [HttpGet]
        public List<Booked> Get()
        {
            return new Database().instance.GetBookedHotels();
        }
    }
}
