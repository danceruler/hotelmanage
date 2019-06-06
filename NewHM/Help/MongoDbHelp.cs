using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewHM.Help
{
  

    public class MyMongoDb
    {
        private static readonly string connStr = ConfigurationManager.ConnectionStrings["hmconstr"].ToString();

        private static readonly string dbName = ConfigurationManager.AppSettings["dbName"].ToString();

        private static IMongoDatabase db = null;

        private static readonly object lockHelper = new object();

        public MyMongoDb() { }

        public static IMongoDatabase GetDb()
        {
            if (db == null)
            {
                lock (lockHelper)
                {
                    if (db == null)
                    {
                        var client = new MongoClient(connStr);
                        db = client.GetDatabase(dbName);
                    }
                }
            }
            return db;
        }
    }

    public class MongoDbHelper<T> where T : BaseEntity
    {
        private IMongoDatabase db = null;

        public IMongoCollection<T> collection = null;

        public MongoDbHelper()
        {
            this.db = MyMongoDb.GetDb();
            collection = db.GetCollection<T>(typeof(T).Name);
        }

        public IMongoCollection<T> Collection()
        {
            return collection;
        }

        public T Insert(T entity)
        {
            var flag = ObjectId.GenerateNewId();
            entity.GetType().GetProperty("Id").SetValue(entity, flag);
            entity.toFindAll = "y";
            entity.CreateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            entity.UpdateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            collection.InsertOne(entity);
            return entity;
        }

        public T AsyncInsert(T entity)
        {
            var flag = ObjectId.GenerateNewId();
            entity.GetType().GetProperty("Id").SetValue(entity, flag);
            entity.toFindAll = "y";
            entity.CreateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            entity.UpdateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            collection.InsertOneAsync(entity);
            return entity;
        }

        public void Modify(string id, string field, string value)
        {
            var filter = Builders<T>.Filter.Eq("Id", ObjectId.Parse(id));
            var updated = Builders<T>.Update.Set(field, value);
            UpdateResult result = collection.UpdateOneAsync(filter, updated).Result;
        }

        public void Update(T entity)
        {
            var old = collection.Find(e => e.Id.Equals(entity.Id)).ToList().FirstOrDefault();

            foreach (var prop in entity.GetType().GetProperties())
            {
                var newValue = prop.GetValue(entity);
                var oldValue = old.GetType().GetProperty(prop.Name).GetValue(old);
                if (newValue != null)
                {
                    if (!newValue.ToString().Equals(oldValue.ToString()))
                    {
                        old.GetType().GetProperty(prop.Name).SetValue(old, newValue.ToString());
                    }
                }
            }
            old.toFindAll = "y";
            old.UpdateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            var filter = Builders<T>.Filter.Eq("Id", entity.Id);
            ReplaceOneResult result = collection.ReplaceOne(filter, old);
        }

        public void AsyncUpdate(T entity)
        {
            var old = collection.Find(e => e.Id.Equals(entity.Id)).ToList().FirstOrDefault();

            foreach (var prop in entity.GetType().GetProperties())
            {
                var newValue = prop.GetValue(entity);
                var oldValue = old.GetType().GetProperty(prop.Name).GetValue(old);
                if (newValue != null)
                {
                    if (!newValue.ToString().Equals(oldValue.ToString()))
                    {
                        old.GetType().GetProperty(prop.Name).SetValue(old, newValue.ToString());
                    }
                }
            }
            old.toFindAll = "y";
            old.UpdateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            var filter = Builders<T>.Filter.Eq("Id", entity.Id);
            ReplaceOneResult result = collection.ReplaceOneAsync(filter, old).Result;
        }

        public void Delete(T entity)
        {
            var filter = Builders<T>.Filter.Eq("Id", entity.Id);
            collection.DeleteOne(filter);
        }

        public void AsyncDelete(T entity)
        {
            var filter = Builders<T>.Filter.Eq("Id", entity.Id);
            collection.DeleteOneAsync(filter);
        }

        public T QueryOne(string id)
        {
            return collection.Find(a => a.Id == ObjectId.Parse(id)).ToList().FirstOrDefault();
        }

        public List<T> QueryAll()
        {
            return collection.Find(a => a.toFindAll.Equals("y")).ToList();
        }
    }

    public abstract class BaseEntity
    {
        public ObjectId Id { get; set; }

        public string toFindAll { get; set; }

        public string CreateTime { get; set; }

        public string UpdateTime { get; set; }
    }
}
