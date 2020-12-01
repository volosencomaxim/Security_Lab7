using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Security_Lab7
{
    [BsonIgnoreExtraElements]
    class People
    {
        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("mail")]
        public string Mail { get; set; }

        [BsonElement("token")]
        public string Token { get; set; }
    }
}
