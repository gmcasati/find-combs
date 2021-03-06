using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FindCombsApi.Models
{
    public class Request
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("RequestDate")]
        public DateTime Date { get; set; }

        public IList<int> Values { get; set; }

        public int Key { get; set; }

        public IList<int> Combination { get; set; }
    }
}
