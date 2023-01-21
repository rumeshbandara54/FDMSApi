namespace FDMSWebApi.Domain
{
    public class FoodIngrediantMapping
    {
        public int Id { get; set; }

        public int FoodId { get; set; }

        public int IngrediantId { get; set; }

        public Double? ServingAmount { get; set; }

        public Double? CaloryAmount { get; set; }
    }
}
