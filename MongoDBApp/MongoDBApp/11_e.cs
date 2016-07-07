using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB;
using MongoDB.Bson;
using MongoDB.Driver;

namespace MongoDBApp
{
    class _11_e
    {
        IMongoCollection<BsonDocument> LocalCollection;

        public _11_e(IMongoCollection<BsonDocument> input)
        {
            IMongoCollection<BsonDocument> LocalCollection = input;
        }

        public IMongoCollection<BsonDocument> ListEmpty(String field)
        {
            IMongoCollection<BsonDocument> MatchingDocs;
            MatchingDocs = db.LocalCollection.find(field: "");
            return MatchingDocs;
        }
    }
}
