using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace MongoDBApp
{
    class _11_e: Program
    {
        IMongoCollection<BsonDocument> LocalCollection = _database.GetCollection<BsonDocument>("restaurants");

        public Task<List<BsonDocument>> ListEmpty(String field)
        {
            var filter = Builders<BsonDocument>.Filter.Eq(field, "");
            var MatchingDocs = LocalCollection.Find(filter).ToListAsync();
            return MatchingDocs;
        }
    }
}
