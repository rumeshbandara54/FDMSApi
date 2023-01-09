namespace FDMSWebApi.Domain
{
    public class Favorite
    {
        public int Id { get; set; }
        public int FoodId { get; set; }
        public string? FavoriteName { get; set; }
        public int UserId { get; set; }
    }
}
