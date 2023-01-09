using FDMSWebApi.Common;
using FDMSWebApi.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Text;

namespace FDMSWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodController : ControllerBase
    {
        private readonly AppDbContext _context;
        ByteConverterTest bconvert = new ByteConverterTest();
        public FoodController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet("GetFoods", Name = "GetFoods")]
        public async Task<IActionResult> GetFoods()
        {
            var result = await _context.Foods.ToListAsync();
            return Ok(result);
        }

        [HttpGet("GetFatsFoods", Name = "GetFatsFoods")]
        public async Task<IActionResult> GetFatsFoods()
        {
            var result = await _context.Foods.ToListAsync();
            return Ok(result.Where(x=> x.FoodCategoryId == 1));
        }

        [HttpGet("GetMeatFoods", Name = "GetMeatFoods")]
        public async Task<IActionResult> GetMeatFoods()
        {
            var result = await _context.Foods.ToListAsync();
            return Ok(result.Where(x => x.FoodCategoryId == 2));
        }

        [HttpGet("GetMilkFoods", Name = "GetMilkFoods")]
        public async Task<IActionResult> GetMilkFoods()
        {
            var result = await _context.Foods.ToListAsync();
            return Ok(result.Where(x => x.FoodCategoryId == 3));
        }

        [HttpGet("GetVegetableFoods", Name = "GetVegetableFoods")]
        public async Task<IActionResult> GetVegetableFoods()
        {
            var result = await _context.Foods.ToListAsync();
            return Ok(result.Where(x => x.FoodCategoryId == 4));
        }


        [HttpGet("GetFruitsFoods", Name = "GetFruitsFoods")]
        public async Task<IActionResult> GetFruitsFoods()
        {
            var result = await _context.Foods.ToListAsync();
            return Ok(result.Where(x => x.FoodCategoryId == 5));
        }

        [HttpGet("GetBakeryFoods", Name = "GetBakeryFoods")]
        public async Task<IActionResult> GetBakeryFoods()
        {
            var result = await _context.Foods.ToListAsync();
            return Ok(result.Where(x => x.FoodCategoryId == 5));
        }


        [HttpPut("UpdateFoodImage", Name = "UpdateFoodImage")]
        public async Task<byte[]> UpdateFoodImage(string path,int foodId)
        {
            byte[] imageArray = bconvert.GetImageToByteArray(path);

            var result = await _context.Foods.FirstOrDefaultAsync(x => x.Id == foodId);
            if (result != null)
            {
                result.FoodImage = imageArray;
            }
            _context.Foods.Update(result);
            await _context.SaveChangesAsync();
            return imageArray;
        }

        [HttpGet("GetFoodImage", Name = "GetFoodImage")]
        public async Task<IActionResult> GetFoodImage(int foodId)
        {
            var result = await _context.Foods.FirstOrDefaultAsync(x => x.Id == foodId);
            var imageString = Convert.ToBase64String(result!.FoodImage, 0, result!.FoodImage.Length);
            return Ok(imageString);
        }


    }
}
