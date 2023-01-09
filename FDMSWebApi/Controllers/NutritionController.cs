using FDMSWebApi.Common;
using FDMSWebApi.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FDMSWebApi.Controllers
{
    public class NutritionController : Controller
    {
        private readonly AppDbContext _context;
        ByteConverterTest bconvert = new ByteConverterTest();
        public NutritionController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet("GetFoods", Name = "GetFoods")]
        public async Task<IActionResult> GetFoods()
        {
            var result = await _context.Foods.ToListAsync();
            return Ok(result);
        }

        [HttpGet("GetNutritionFoods", Name = "GetNutritionFoods")]
        public async Task<IActionResult> GetNutritionFoods()
        {
            var result = await _context.Foods.ToListAsync();
            return Ok(result.Where(x => x.FoodCategoryId == 1));
        }
    }
}
