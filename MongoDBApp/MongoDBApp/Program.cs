using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;


namespace MongoDBApp
{
    class Program
    {
        protected static IMongoClient _client = new MongoClient("mongodb://db1.example.net:2500/?replicaSet=test");
        //protected static IMongoClient _client = new MongoClient("mongodb://10.10.19.12:27017");
        protected static IMongoDatabase _database = _client.GetDatabase("test");

        static void Main(string[] args)
        {
            Run();
        }

        public static void Run()
        {
            InsertData();
            Console.WriteLine(ReadData().ToString());
            Console.WriteLine("Program done.");
        }

        public static async Task<List<BsonDocument>> ReadData()
        {
            Console.WriteLine("Done inserting. Begin reading.");
            var collection = _database.GetCollection<BsonDocument>("restaurants");
            var filter = Builders<BsonDocument>.Filter.Eq("borough", "Manhattan");
            var result = await collection.Find(filter).ToListAsync();
            return result;
        }

        public static async void InsertData()
        {
            Console.WriteLine("Inserting.");
            var document = new BsonDocument
            {
                { "address" , new BsonDocument
                    {
                        { "street", "2 Avenue" },
                        { "zipcode", "10075" },
                        { "building", "1480" },
                        { "coord", new BsonArray { 73.9557413, 40.7720266 } }
                    }
                },
                { "borough", "Manhattan" },
                { "cuisine", "Italian" },
                { "grades", new BsonArray
                    {
                        new BsonDocument
                        {
                            { "date", new DateTime(2014, 10, 1, 0, 0, 0, DateTimeKind.Utc) },
                            { "grade", "A" },
                            { "score", 11 }
                        },
                        new BsonDocument
                        {
                            { "date", new DateTime(2014, 1, 6, 0, 0, 0, DateTimeKind.Utc) },
                            { "grade", "B" },
                            { "score", 17 }
                        }
                    }
                },
                { "name", "Vella" },
                { "restaurant_id", "41704620" }
            };

            var collection = _database.GetCollection<BsonDocument>("restaurants");
            await collection.InsertOneAsync(document);
        }
    }
}
