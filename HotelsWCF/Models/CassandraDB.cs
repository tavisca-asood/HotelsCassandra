using Cassandra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelsWCF
{
    public class CassandraDB : IRepository
    {
        public List<Hotel> GetRooms()
        {
            Cluster cluster = Cluster.Builder().AddContactPoint("127.0.0.1").Build();
            ISession session = cluster.Connect("Training");
            RowSet rows = session.Execute("select * from rooms");
            List<Hotel> hotels = new List<Hotel>();
            foreach (Row row in rows)
            {
                dynamic id = row["id"];
                dynamic types = row["rooms"];
                List<Room> rooms = new List<Room>();
                string[] x = types;
                for(int i=0;i<x.Length;i++)
                {
                    string[] room = x[i].Split(',');
                    rooms.Add(new Room()
                    {
                        Type=room[0],
                        Price=int.Parse(room[1])
                    });
                }
                hotels.Add(new Hotel()
                {
                    ID=id,
                    Rooms=rooms
                });
            }
            return hotels;
        }
    }
}