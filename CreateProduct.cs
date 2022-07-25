using System;

using EcommerceWebAPI.DTO;
using EcommerceWebAPI.Models;
namespace EcommerceWebAPI.Command
{
    
    public class CreateProduct : IRequest<int>
    {
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

       
        public class CreateProduct
        {
            private readonly Product context;

            public CreateProductHandler(ProductItem Context)
            {
                context = Context;
            }

            public async Task<int> Handle(CreateProduct com, CancellationToken cancellationToken)
            {

                var p = new ProductItem();

                
                p.Name = com.Name;
                p.Price = com.Price;
                p.Quantity = com.Quantity;
                p.Description = com.Description;

                if (context.Products.Any(x => x.Name == com.ProductName))
                {
                    return 0;
                }

                context.Add(p);

                await context.SaveProduct();

                return p.Id;
            }
        }
    }

    public class CreateProduct
    {
    }

    public interface IRequest<T>
    {
    }
}
