using FDMSWebApi.Domain;

namespace FDMSWebApi.model
{
    public class FoodDto
    {
        public int Id { get; set; }
        public int FoodCategoryId { get; set; }
        public string? FoodName { get; set; }
        public byte[]? FoodImage { get; set; }
        public Double Quantity { get; set; }
        public List<FoodNutritionDto>? FoodNutritions { get; set; }
        public List<FoodIngrediantDto>? FoodIngrediants { get; set; }
    }
}
