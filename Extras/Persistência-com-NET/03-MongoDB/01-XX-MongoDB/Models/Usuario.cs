﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace _01_XX_MongoDB.Models
{
    public class Usuario
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
    }
}