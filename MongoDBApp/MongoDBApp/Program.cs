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
            Console.WriteLine("Insert.");
            InsertData();
            Console.WriteLine("Test query " + ReadData().ToString());
            MongoDBApp._11_b.Query();
            Console.WriteLine("Program done.");
        }

        public static Task<List<BsonDocument>> ReadData()
        {
            var collection = _database.GetCollection<BsonDocument>("restaurants");
            var filter = Builders<BsonDocument>.Filter.Eq("borough", "Manhattan");
            var result = collection.Find(filter).ToListAsync();
            return result;
        }

        public static void InsertData()
        {
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

            var document2 = new BsonDocument
            {
                { "address" , new BsonDocument
                    {
                        { "street", "N Market St" },
                        { "zipcode", "21701" },
                        { "building", "105" }
                    }
                },
                { "borough", "Frederick" },
                { "cuisine", "New American" },
                { "grades", new BsonArray
                    {
                        new BsonDocument
                        {
                            { "date", new DateTime(2015, 11, 12, 0, 0, 0, DateTimeKind.Utc) },
                            { "grade", "A" },
                            { "score", 10 }
                        },
                        new BsonDocument
                        {
                            { "date", new DateTime(2016, 3, 27, 0, 0, 0, DateTimeKind.Utc) },
                            { "grade", "A" },
                            { "score", 11 }
                        }
                    }
                },
                { "name", "Firestone" },
                { "restaurant_id", "41705913" }
            };

            var document3 = new BsonDocument
            {
                { "address" , new BsonDocument
                    {
                        { "street", "9th Ave" },
                        { "zipcode", "10019" },
                        { "building", "836" }
                    }
                },
                { "borough", "New York" },
                { "cuisine", "Bacon" },
                { "grades", new BsonArray
                    {
                        new BsonDocument
                        {
                            { "date", new DateTime(2014, 10, 21, 0, 0, 0, DateTimeKind.Utc) },
                            { "grade", "B" },
                            { "score", 17 }
                        },
                        new BsonDocument
                        {
                            { "date", new DateTime(2015, 12, 5, 0, 0, 0, DateTimeKind.Utc) },
                            { "grade", "B" },
                            { "score", 16 }
                        }
                    }
                },
                { "name", "BarBacon" },
                { "restaurant_id", "41749267" }
            };

            var collection = _database.GetCollection<BsonDocument>("restaurants");
            collection.InsertOneAsync(document);
            collection.InsertOneAsync(document2);
            collection.InsertOneAsync(document3);
        }
    }
}
