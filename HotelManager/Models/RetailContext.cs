using HotelManager.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager.Models
{
    public class RetailContext : DbContext
    {
        public RetailContext()
            : base("myDatabase")
        {
        }
        public DbSet<Person> Persons { set; get; }
        public DbSet<Customer> Customers { set; get; }
        public DbSet<Room> Rooms { set; get; }
        public DbSet<Finishtrans> Finishtranses { set; get; }
        public DbSet<Vipinfo> Vipinfos { set; get; }
        public DbSet<RoomType> RoomTypes { set; get; }
        public DbSet<RoomStateModel> RoomStates { set; get; }

    }
}
