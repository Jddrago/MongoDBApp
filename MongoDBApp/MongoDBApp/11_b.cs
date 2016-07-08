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
        public async Task<List<BsonDocument>> Query()
        {
            IMongoCollection<BsonDocument> LocalCollection = Program._database.GetCollection<BsonDocument>("restaurants");
            var filter = Builders<BsonDocument>.Filter.Eq("borough", "Manhattan");
            var count = 0;
            Console.WriteLine("Begin processing");
            using (var cursor = await LocalCollection.FindAsync(filter))
            {
                Console.WriteLine("hi");
                while (await cursor.MoveNextAsync())
                {
                    var batch = cursor.Current;
                    foreach (var document in batch)
                    {
                        Console.WriteLine(document.ToJson());
                        Console.WriteLine(count);
                        count++;
                    }
                }
            }
            var result = await LocalCollection.Find(filter).ToListAsync();
            return result;
        }
    }
}
