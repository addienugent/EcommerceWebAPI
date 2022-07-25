using System;
namespace EcommerceWebAPI.DTO
{
    public class ProductItem
    {
        public int Id { get; set; }

        public decimal Price { get; set; }
        public int Quantity { get; internal set; }
        public string? Name { get; set; }
        public string? Description { get; set; }

    }
}

