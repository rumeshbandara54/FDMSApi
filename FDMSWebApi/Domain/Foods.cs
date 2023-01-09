namespace FDMSWebApi.Domain
{
    public class Foods
    {
        public int Id { get; set; }
        public int FoodCategoryId { get; set; }
        public string? FoodName { get; set; }
        public int? NutritionId { get; set; }
        public string? Ingredients { get; set; }

        public string? PDFAverge { get; set; }

        public byte[]? FoodImage { get; set; }
    }
}
