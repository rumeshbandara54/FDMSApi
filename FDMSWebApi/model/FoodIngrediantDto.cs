namespace FDMSWebApi.model
{
    public class FoodIngrediantDto
    {
        public int Id { get; set; }

        public int FoodId { get; set; }

        public int IngrediantId { get; set; }
        public string? IngrediantName { get; set; }

        public Double? ServingAmount { get; set; }

        public Double? CaloryAmount { get; set; }
    }
}
