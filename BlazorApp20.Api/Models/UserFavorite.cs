<<<<<<< HEAD
﻿using MongoDB.Bson;
=======
using MongoDB.Bson;
>>>>>>> 0bb5bb79d79d8c270fc6d65f314bbc3e1d6ac43f
using MongoDB.Bson.Serialization.Attributes;

namespace BlazorApp20.Api.Models
{
    public class UserFavorite
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string UserId { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string FavoriteWeather { get; set; } = string.Empty;
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 0bb5bb79d79d8c270fc6d65f314bbc3e1d6ac43f
