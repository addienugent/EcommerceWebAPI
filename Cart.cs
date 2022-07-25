using System;
namespace EcommerceWebAPI.Models
{

    public class Cart
    {
        public int UserName { get; set; }
        public int? Id { get; set; }
        public string? Description { get; set; } = null!;
        public int Quantity { get; set; }
        public int? TotalPrice { get; set; }
        public object CartId { get; internal set; }

        public string? CCnum { get; internal set; }
        public string? CVC { get; internal set; }
        public string? Address { get; internal set; }
        public object CartProds { get; internal set; }
    }
}

