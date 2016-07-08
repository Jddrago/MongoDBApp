using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace MongoDBApp
{
    class _11_g: Program
    {
               // Write an aggregate (sum, average, count, etc.) grouped
               // by a particular field. (Select state, sum(population)
               //                              [...]
               //                         Group by state) 

               static void Query()
        {
            IMongoCollection<BsonDocument> LocalCollection = Program._database.GetCollection<BsonDocument>("restaurants");
            var aggregate = LocalCollection.Aggregate().Group(new BsonDocument { { "_id", "$borough" }, { "count", new BsonDocument("$sum", 1) } });
            var result = await aggregate.ToListAsync();

            var expectedResults = new[] {
                BsonDocument.Parse("{ _id : 'Staten Island', count : 969 }"),
                BsonDocument.Parse("{ _id : 'Brooklyn', count : 6086 }"),
                BsonDocument.Parse("{ _id : 'Manhattan', count : 10259 }"),
                BsonDocument.Parse("{ _id : 'Queens', count : 5656 }"),
                BsonDocument.Parse("{ _id : 'Bronx', count : 2338 }"),
                BsonDocument.Parse("{ _id : 'Missing', count : 51 }")
            };
            result.Should().BeEquivalentTo(expectedResults);
        }
    }
}
