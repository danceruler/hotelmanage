using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleForTest
{
    class Program
    {
        static void Main(string[] args)
        {

            var db = new MongoDbHelper<test>();

            var a = new test()
            {
                Name = "test",
                Amount = 1000,
                CreateDateTime = DateTime.Now,
                strs = new List<test>()
            };
            var entity = new test
            {
                Name = "test",
                Amount = 1000,
                CreateDateTime = DateTime.Now,
                strs = new List<test>() { a , a }
            };
            db.Insert(entity);
            Thread.Sleep(1000);
            //var database = "test";
            //var collection = "test";
            //var db = new MongoClient("mongodb://localhost:27017").GetDatabase(database);
            //var coll = db.GetCollection<TestMongo>(collection);
            //var coll2 = db.GetCollection<TestMongo2>(collection);
            //var entity = new TestMongo2
            //{
            //    Name2 = "SkyChen",
            //    Amount2 = 100,
            //    CreateDateTime2 = DateTime.Now
            //};
            //coll2.InsertOne(entity);
        }

        public class test:BaseEntity
        {

            [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
            public DateTime CreateDateTime { get; set; }

            public decimal Amount { get; set; }

            public string Name { get; set; }

            public List<test> strs { get; set; }

        }

        public class TestMongo2
        {

            [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
            public DateTime CreateDateTime2 { get; set; }

            public decimal Amount2 { get; set; }

            public string Name2 { get; set; }

        }

    }
}
