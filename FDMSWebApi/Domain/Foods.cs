﻿namespace FDMSWebApi.Domain
{
    public class Foods
    {
        public int Id { get; set; }
        public int FoodCategoryId { get; set; }
        public string? FoodName { get; set; }

        public byte[]? FoodImage { get; set; }
        public Double Quantity { get; set; }
    }
}
