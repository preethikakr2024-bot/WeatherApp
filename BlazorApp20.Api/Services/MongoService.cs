<<<<<<< HEAD
﻿using MongoDB.Driver;
=======
using MongoDB.Driver;
>>>>>>> 0bb5bb79d79d8c270fc6d65f314bbc3e1d6ac43f
using BlazorApp20.Api.Models;

namespace BlazorApp20.Api.Services
{
    public class MongoService
    {
        private readonly IMongoCollection<UserFavorite> _favorites;

        public MongoService(IMongoClient client)
        {
            var database = client.GetDatabase("BlazorApp20");
            _favorites = database.GetCollection<UserFavorite>("Favorites");
        }

        public async Task SaveFavorite(UserFavorite fav)
        {
<<<<<<< HEAD
            var existing = await _favorites
                .Find(f => f.UserId == fav.UserId)
                .FirstOrDefaultAsync();

=======
            var existing = await _favorites.Find(f => f.UserId == fav.UserId).FirstOrDefaultAsync();
>>>>>>> 0bb5bb79d79d8c270fc6d65f314bbc3e1d6ac43f
            if (existing == null)
                await _favorites.InsertOneAsync(fav);
            else
                await _favorites.ReplaceOneAsync(f => f.UserId == fav.UserId, fav);
        }

        public async Task<UserFavorite?> GetFavorite(string userId)
        {
<<<<<<< HEAD
            return await _favorites
                .Find(f => f.UserId == userId)
                .FirstOrDefaultAsync();
        }
    }
}
=======
            return await _favorites.Find(f => f.UserId == userId).FirstOrDefaultAsync();
        }
    }
}
>>>>>>> 0bb5bb79d79d8c270fc6d65f314bbc3e1d6ac43f
