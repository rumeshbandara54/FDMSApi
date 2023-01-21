using FDMSWebApi.Common;
using FDMSWebApi.Domain;
using FDMSWebApi.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace FDMSWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoriteController : ControllerBase
    {
        private readonly AppDbContext _context; 
        public FavoriteController(AppDbContext context)
        {
            _context = context; 
        }
        [HttpGet("GetAllFavoritesByUserId", Name = "GetAllFavoritesByUserId")]
        public async Task<IActionResult> GetAllFavoritesByUserId(int userId)
        {
            var result = await _context.Favouite.ToListAsync();
            return Ok(result.Where(x => x.UserId == userId));

        }

        [HttpGet("GetAllFavorites",Name = "GetAllFavorites")]
        public async Task<IActionResult> GetAllFavorites()
        {
            var result = await _context.Favouite.ToListAsync();
            return Ok(result);

        }

        [HttpPost("CreateFavorites", Name = "CreateFavorites")]
        public async Task<IActionResult> CreateFavorites(Favorite favorite) 
        {
            var result = await _context.Favouite.AddAsync(favorite);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("RemoveFavorites", Name = "RemoveFavorites")]
        public async Task<IActionResult> RemoveFavorites(int userId, int favoriteId)
        {
            var result = await _context.Favouite.FirstOrDefaultAsync(x => x.UserId == userId && x.Id == favoriteId);
            if (result != null)
            {
                _context.Favouite.Remove(result);
                await _context.SaveChangesAsync(); 
            }
            return Ok(result);
        }
       
    }
}
