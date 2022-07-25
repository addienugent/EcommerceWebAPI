using System;
using EcommerceWebAPI.DTO;

namespace EcommerceWebAPI.Models
{
    public class Product
    {
        internal object Products;

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int Price { get; set; }
        public string Description { get; set; }

        public int Quantity { get; set; }

        public static implicit operator Product(ProductItem v)
        {
            throw new NotImplementedException();
        }
    }
}

