using System;
namespace EcommerceWebAPI.DTO
{

    public class CartItem
    {
        public virtual ProductItem products { get; set; } = new ProductItem();

        public int Id { get; set; }
        public int Quantity { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
       
    }
}

