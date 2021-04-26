using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SmartMedOpdracht.Models
{
    public class Medicine
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Name")]
        public string name { get; set; }

        public int quantity { get; set; }

        public DateTime creationDate { get; set; }

        public Medicine(string id, string name, int quantity, DateTime creationDate)
        {
            Id = id;
            this.name = name;
            this.quantity = quantity;
            this.creationDate = creationDate;
        }

        public Medicine()
        {
 
        }


    }
}

