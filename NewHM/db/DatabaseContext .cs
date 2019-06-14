using NewHM.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewHM.db
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("mydatabase")
        {


        }
        //public DatabaseContext() : base(new SQLiteConnection()
        //{
        //    ConnectionString = new SQLiteConnectionStringBuilder()
        //    {
        //        DataSource = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "db\\test.db"),
        //        ForeignKeys = false
        //    }.ConnectionString
        //}, false)
        //{


        //}
        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        //    base.OnModelCreating(modelBuilder);
        //}

            
        public DbSet<Bill> Bill { get; set; }
        public DbSet<BookTran> BookTran { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<HMBlock> HMBlock { get; set; }
        public DbSet<HotelMenuPower> HotelMenuPower { get; set; }
        public DbSet<HotelTablePower> HotelTablePower { get; set; }
        public DbSet<HotelUser> HotelUser { get; set; }
        public DbSet<HotelUserLevelPowers> HotelUserLevelPowers { get; set; }
        public DbSet<Room> Room { get; set; }
        public DbSet<RoomPrice> RoomPrice { get; set; }
        public DbSet<RoomPriceInfo> RoomPriceInfo { get; set; }
        public DbSet<RoomType> RoomType { get; set; }
        public DbSet<Tran> Tran { get; set; }
        public DbSet<ValueRule_fullday> ValueRule_fullday { get; set; }
        public DbSet<ValueRule_hour> ValueRule_hour { get; set; }
        public DbSet<ValueRule_special> ValueRule_special { get; set; }
        public DbSet<VipInfo> VipInfo { get; set; }
        public DbSet<VipType> VipType { get; set; }
        public DbSet<Order> Order { get; set; }

     

    }
}
