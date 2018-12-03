using HotelManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HotelManager.Helper
{
    public static class CustomHelper
    {
        //通过房客ID得到房客信息
        public static Customer GetCustomerbyID(this string id)
        {
            using (RetailContext context = new RetailContext())
            {
                string sql = string.Format("select * from customers where identification = '{0}'", id);
                return context.Database.SqlQuery<Customer>(sql).SingleOrDefault();
            }
        }
        //得到在住房客信息
        public static List<Customer> GetHereTransCustomers()
        {
            using (RetailContext context = new RetailContext())
            {
                string sql = string.Format("select * from customers where identification in (select customID from finishtranses where IsDoing = true)");
                return context.Database.SqlQuery<Customer>(sql).ToList();
            }
        }
        //得到预定房客信息
        public static List<Customer> GetHereBooksCustomers()
        {
            using (RetailContext context = new RetailContext())
            {
                string sql = string.Format("select * from customers where identification in (select customID from finishbooks where IsBook = true)");
                return context.Database.SqlQuery<Customer>(sql).ToList();
            }
        }

    }
}
