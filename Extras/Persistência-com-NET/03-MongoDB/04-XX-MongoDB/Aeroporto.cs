﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver.GeoJsonObjectModel;

namespace _04_XX_MongoDB
{
    class Aeroporto
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public GeoJsonPoint<GeoJson2DGeographicCoordinates> Loc { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Code { get; set; }
    }
}
