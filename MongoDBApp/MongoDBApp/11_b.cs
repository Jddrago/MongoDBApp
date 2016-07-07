using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace MongoDBApp
{
    class _11_b: Program
    {
        public static void Query()
        {
            IMongoCollection<BsonDocument> LocalCollection = Program._database.GetCollection<BsonDocument>("restaurants");
            var filter = Builders<BsonDocument>.Filter.Eq("borough", "Manhattan");
            var result = LocalCollection.Find(filter).ToList<BsonDocument>();

            foreach (BsonDocument item in result)
            {
                Console.WriteLine("Processing first document.");
                    foreach (BsonElement element in item.Elements)
                {
                    Console.WriteLine("Name: {0}, Value: {1}", element.Name, element.Value);
                }
            }
        }
    }
}
