namespace FDMSWebApi.Domain
{
    public class FoodNutritionMapping
    {

        public int Id { get; set; }

        public int FoodId { get; set; }

        public int NutritionId { get; set; }
        public Double ServingAmount { get; set; }

        public Double NutritionAmount { get; set; }
    }
}
