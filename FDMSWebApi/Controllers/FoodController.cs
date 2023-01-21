using FDMSWebApi.Common;
using FDMSWebApi.Domain;
using FDMSWebApi.Infrastructure;
using FDMSWebApi.model;
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
            var result = await _context.Foods.Select( FD => new FoodDto
                {
                    Id = FD.Id,
                    FoodCategoryId = FD.FoodCategoryId,
                    FoodName = FD.FoodName,
                    FoodImage = FD.FoodImage,
                    Quantity = FD.Quantity,
                    FoodNutritions = _context.FoodNutritionMapping.Where(x=> x.FoodId == FD.Id)
                                     .Join(_context.Nutrition, FNM=> FNM.NutritionId,
                                     FN=> FN.Id,
                                     (FNM,FN) => new FoodNutritionDto
                                     {
                                         Id= FNM.Id,
                                         FoodId = FNM.FoodId,
                                         NutritionId = FNM.NutritionId,
                                         NutritionName = FN.Name,
                                         ServingAmount = FNM.ServingAmount,
                                         NutritionAmount = FNM.NutritionAmount
                                         
                                     }).ToList(),
                    FoodIngrediants = _context.FoodIngrediantMapping.Where(x => x.FoodId == FD.Id)
                                      .Join(_context.Ingrediant, FIM=> FIM.IngrediantId,
                                      FI=> FI.Id,
                                      (FIM, FI) => new FoodIngrediantDto
                                      {
                                        Id = FIM.Id,
                                        FoodId = FIM.FoodId,
                                        IngrediantId = FIM.IngrediantId,
                                        IngrediantName = FI.Name,
                                        ServingAmount = FIM.ServingAmount,
                                        CaloryAmount = FIM.CaloryAmount
                                        
                                      })
                                      .ToList(),
            }).ToListAsync();
            return Ok(result);
        }

        [HttpGet("GetFatsFoods", Name = "GetFatsFoods")]
        public async Task<IActionResult> GetFatsFoods()
        {
            var result = await _context.Foods.Where(c => c.FoodCategoryId == 1).Select(FD => new FoodDto
            {
                Id = FD.Id,
                FoodCategoryId = FD.FoodCategoryId,
                FoodName = FD.FoodName,
                FoodImage = FD.FoodImage,
                Quantity = FD.Quantity,
                FoodNutritions = _context.FoodNutritionMapping.Where(x => x.FoodId == FD.Id)
                                     .Join(_context.Nutrition, FNM => FNM.NutritionId,
                                     FN => FN.Id,
                                     (FNM, FN) => new FoodNutritionDto
                                     {
                                         Id = FNM.Id,
                                         FoodId = FNM.FoodId,
                                         NutritionId = FNM.NutritionId,
                                         NutritionName = FN.Name,
                                         ServingAmount = FNM.ServingAmount,
                                         NutritionAmount = FNM.NutritionAmount

                                     }).ToList(),
                FoodIngrediants = _context.FoodIngrediantMapping.Where(x => x.FoodId == FD.Id)
                                      .Join(_context.Ingrediant, FIM => FIM.IngrediantId,
                                      FI => FI.Id,
                                      (FIM, FI) => new FoodIngrediantDto
                                      {
                                          Id = FIM.Id,
                                          FoodId = FIM.FoodId,
                                          IngrediantId = FIM.IngrediantId,
                                          IngrediantName = FI.Name,
                                          ServingAmount = FIM.ServingAmount,
                                          CaloryAmount = FIM.CaloryAmount

                                      })
                                      .ToList(),
            }).ToListAsync();
            return Ok(result);
        }

        [HttpGet("GetMeatFoods", Name = "GetMeatFoods")]
        public async Task<IActionResult> GetMeatFoods()
        {
            var result = await _context.Foods.Where(c => c.FoodCategoryId == 2).Select(FD => new FoodDto
            {
                Id = FD.Id,
                FoodCategoryId = FD.FoodCategoryId,
                FoodName = FD.FoodName,
                FoodImage = FD.FoodImage,
                Quantity = FD.Quantity,
                FoodNutritions = _context.FoodNutritionMapping.Where(x => x.FoodId == FD.Id)
                                    .Join(_context.Nutrition, FNM => FNM.NutritionId,
                                    FN => FN.Id,
                                    (FNM, FN) => new FoodNutritionDto
                                    {
                                        Id = FNM.Id,
                                        FoodId = FNM.FoodId,
                                        NutritionId = FNM.NutritionId,
                                        NutritionName = FN.Name,
                                        ServingAmount = FNM.ServingAmount,
                                        NutritionAmount = FNM.NutritionAmount

                                    }).ToList(),
                FoodIngrediants = _context.FoodIngrediantMapping.Where(x => x.FoodId == FD.Id)
                                     .Join(_context.Ingrediant, FIM => FIM.IngrediantId,
                                     FI => FI.Id,
                                     (FIM, FI) => new FoodIngrediantDto
                                     {
                                         Id = FIM.Id,
                                         FoodId = FIM.FoodId,
                                         IngrediantId = FIM.IngrediantId,
                                         IngrediantName = FI.Name,
                                         ServingAmount = FIM.ServingAmount,
                                         CaloryAmount = FIM.CaloryAmount

                                     })
                                     .ToList(),
            }).ToListAsync();
            return Ok(result);
        }

        [HttpGet("GetMilkFoods", Name = "GetMilkFoods")]
        public async Task<IActionResult> GetMilkFoods()
        {
            var result = await _context.Foods.Where(c => c.FoodCategoryId == 3).Select(FD => new FoodDto
            {
                Id = FD.Id,
                FoodCategoryId = FD.FoodCategoryId,
                FoodName = FD.FoodName,
                FoodImage = FD.FoodImage,
                Quantity = FD.Quantity,
                FoodNutritions = _context.FoodNutritionMapping.Where(x => x.FoodId == FD.Id)
                                     .Join(_context.Nutrition, FNM => FNM.NutritionId,
                                     FN => FN.Id,
                                     (FNM, FN) => new FoodNutritionDto
                                     {
                                         Id = FNM.Id,
                                         FoodId = FNM.FoodId,
                                         NutritionId = FNM.NutritionId,
                                         NutritionName = FN.Name,
                                         ServingAmount = FNM.ServingAmount,
                                         NutritionAmount = FNM.NutritionAmount

                                     }).ToList(),
                FoodIngrediants = _context.FoodIngrediantMapping.Where(x => x.FoodId == FD.Id)
                                      .Join(_context.Ingrediant, FIM => FIM.IngrediantId,
                                      FI => FI.Id,
                                      (FIM, FI) => new FoodIngrediantDto
                                      {
                                          Id = FIM.Id,
                                          FoodId = FIM.FoodId,
                                          IngrediantId = FIM.IngrediantId,
                                          IngrediantName = FI.Name,
                                          ServingAmount = FIM.ServingAmount,
                                          CaloryAmount = FIM.CaloryAmount

                                      })
                                      .ToList(),
            }).ToListAsync();
            return Ok(result);
        }

        [HttpGet("GetVegetableFoods", Name = "GetVegetableFoods")]
        public async Task<IActionResult> GetVegetableFoods()
        {
            var result = await _context.Foods.Where(c => c.FoodCategoryId == 4).Select(FD => new FoodDto
            {
                Id = FD.Id,
                FoodCategoryId = FD.FoodCategoryId,
                FoodName = FD.FoodName,
                FoodImage = FD.FoodImage,
                Quantity = FD.Quantity,
                FoodNutritions = _context.FoodNutritionMapping.Where(x => x.FoodId == FD.Id)
                                    .Join(_context.Nutrition, FNM => FNM.NutritionId,
                                    FN => FN.Id,
                                    (FNM, FN) => new FoodNutritionDto
                                    {
                                        Id = FNM.Id,
                                        FoodId = FNM.FoodId,
                                        NutritionId = FNM.NutritionId,
                                        NutritionName = FN.Name,
                                        ServingAmount = FNM.ServingAmount,
                                        NutritionAmount = FNM.NutritionAmount

                                    }).ToList(),
                FoodIngrediants = _context.FoodIngrediantMapping.Where(x => x.FoodId == FD.Id)
                                     .Join(_context.Ingrediant, FIM => FIM.IngrediantId,
                                     FI => FI.Id,
                                     (FIM, FI) => new FoodIngrediantDto
                                     {
                                         Id = FIM.Id,
                                         FoodId = FIM.FoodId,
                                         IngrediantId = FIM.IngrediantId,
                                         IngrediantName = FI.Name,
                                         ServingAmount = FIM.ServingAmount,
                                         CaloryAmount = FIM.CaloryAmount

                                     })
                                     .ToList(),
            }).ToListAsync();
            return Ok(result);
        }


        [HttpGet("GetFruitsFoods", Name = "GetFruitsFoods")]
        public async Task<IActionResult> GetFruitsFoods()
        {
            var result = await _context.Foods.Where(c => c.FoodCategoryId == 5).Select(FD => new FoodDto
            {
                Id = FD.Id,
                FoodCategoryId = FD.FoodCategoryId,
                FoodName = FD.FoodName,
                FoodImage = FD.FoodImage,
                Quantity = FD.Quantity,
                FoodNutritions = _context.FoodNutritionMapping.Where(x => x.FoodId == FD.Id)
                                    .Join(_context.Nutrition, FNM => FNM.NutritionId,
                                    FN => FN.Id,
                                    (FNM, FN) => new FoodNutritionDto
                                    {
                                        Id = FNM.Id,
                                        FoodId = FNM.FoodId,
                                        NutritionId = FNM.NutritionId,
                                        NutritionName = FN.Name,
                                        ServingAmount = FNM.ServingAmount,
                                        NutritionAmount = FNM.NutritionAmount

                                    }).ToList(),
                FoodIngrediants = _context.FoodIngrediantMapping.Where(x => x.FoodId == FD.Id)
                                     .Join(_context.Ingrediant, FIM => FIM.IngrediantId,
                                     FI => FI.Id,
                                     (FIM, FI) => new FoodIngrediantDto
                                     {
                                         Id = FIM.Id,
                                         FoodId = FIM.FoodId,
                                         IngrediantId = FIM.IngrediantId,
                                         IngrediantName = FI.Name,
                                         ServingAmount = FIM.ServingAmount,
                                         CaloryAmount = FIM.CaloryAmount

                                     })
                                     .ToList(),
            }).ToListAsync();
            return Ok(result);
        }

        [HttpGet("GetBakeryFoods", Name = "GetBakeryFoods")]
        public async Task<IActionResult> GetBakeryFoods()
        {
            var result = await _context.Foods.Where(c => c.FoodCategoryId == 6).Select(FD => new FoodDto
            {
                Id = FD.Id,
                FoodCategoryId = FD.FoodCategoryId,
                FoodName = FD.FoodName,
                FoodImage = FD.FoodImage,
                Quantity = FD.Quantity,
                FoodNutritions = _context.FoodNutritionMapping.Where(x => x.FoodId == FD.Id)
                                    .Join(_context.Nutrition, FNM => FNM.NutritionId,
                                    FN => FN.Id,
                                    (FNM, FN) => new FoodNutritionDto
                                    {
                                        Id = FNM.Id,
                                        FoodId = FNM.FoodId,
                                        NutritionId = FNM.NutritionId,
                                        NutritionName = FN.Name,
                                        ServingAmount = FNM.ServingAmount,
                                        NutritionAmount = FNM.NutritionAmount

                                    }).ToList(),
                FoodIngrediants = _context.FoodIngrediantMapping.Where(x => x.FoodId == FD.Id)
                                     .Join(_context.Ingrediant, FIM => FIM.IngrediantId,
                                     FI => FI.Id,
                                     (FIM, FI) => new FoodIngrediantDto
                                     {
                                         Id = FIM.Id,
                                         FoodId = FIM.FoodId,
                                         IngrediantId = FIM.IngrediantId,
                                         IngrediantName = FI.Name,
                                         ServingAmount = FIM.ServingAmount,
                                         CaloryAmount = FIM.CaloryAmount

                                     })
                                     .ToList(),
            }).ToListAsync();
            return Ok(result);
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
