namespace FDMSWebApi.model
{
    public class FoodNutritionDto
    {
        public int Id { get; set; }

        public int FoodId { get; set; }

        public int NutritionId { get; set; }
        public string? NutritionName { get; set; }
        public Double ServingAmount { get; set; }

        public Double NutritionAmount { get; set; }
    }
}
