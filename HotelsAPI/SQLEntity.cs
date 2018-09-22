using HotelsAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelsAPI
{
    public class SQLEntity: DbContext
    {
        public DbSet<Booked> BookedHotels { get; set; }
        public DbSet<Log> Logs { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=TAVDESK121;Database=Training;Integrated Security=True");
        }
    }
}
