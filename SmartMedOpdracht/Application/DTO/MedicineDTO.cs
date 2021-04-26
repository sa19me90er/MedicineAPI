using System;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson.Serialization.Attributes;

namespace SmartMedOpdracht.Application
{
    public class MedicineDTO
    {
            public string Id { get; set; }
            public string name { get; set; }
            [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than 0")]
            public int quantity { get; set; }
            [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
            public DateTime creationDate { get; set; }

        
    }
}
