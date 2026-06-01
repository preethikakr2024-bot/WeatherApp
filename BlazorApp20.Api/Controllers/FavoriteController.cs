<<<<<<< HEAD
﻿using BlazorApp20.Api.Models;
using BlazorApp20.Api.Services;
using Microsoft.AspNetCore.Mvc;
=======
using Microsoft.AspNetCore.Mvc;
using BlazorApp20.Api.Services;
using BlazorApp20.Api.Models;
>>>>>>> 0bb5bb79d79d8c270fc6d65f314bbc3e1d6ac43f

namespace BlazorApp20.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FavoriteController : ControllerBase
    {
        private readonly MongoService _mongo;

        public FavoriteController(MongoService mongo)
        {
            _mongo = mongo;
        }

        [HttpPost]
        public async Task<IActionResult> Save([FromBody] UserFavorite fav)
        {
            if (fav == null)
                return BadRequest("Favorite cannot be null");
<<<<<<< HEAD

=======
>>>>>>> 0bb5bb79d79d8c270fc6d65f314bbc3e1d6ac43f
            await _mongo.SaveFavorite(fav);
            return Ok(new { message = "Saved successfully" });
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> Get(string userId)
        {
            if (string.IsNullOrWhiteSpace(userId))
                return BadRequest("UserId is required");
<<<<<<< HEAD

=======
>>>>>>> 0bb5bb79d79d8c270fc6d65f314bbc3e1d6ac43f
            var data = await _mongo.GetFavorite(userId);
            return Ok(data);
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 0bb5bb79d79d8c270fc6d65f314bbc3e1d6ac43f
