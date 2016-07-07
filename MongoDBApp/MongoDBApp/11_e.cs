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
        IMongoCollection<BsonDocument> LocalCollection = Program._database.GetCollection<BsonDocument>("restaurants");
    }
}
