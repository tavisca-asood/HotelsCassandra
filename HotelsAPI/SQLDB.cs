using HotelsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelsAPI
{
    public class SQLDB : IRepository
    {
        public void Book(Booked booked)
        {
            SQLEntity entity = new SQLEntity();
            entity.BookedHotels.Add(booked);
            entity.SaveChanges();
        }

        public List<Booked> GetBookedHotels()
        {
            SQLEntity entity = new SQLEntity();
            return entity.BookedHotels.ToList();
        }
    }
}
