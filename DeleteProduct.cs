
using System;
namespace EcommerceWebAPI.Command
{
    public class DeleteProduct : IRequest<int>
    {
        public int Id { get; set; }
        public class DeleteProduct : IRequestHandler<DeleteProduct, int>
        {
            private readonly IProductContext context;

            public async Task<int> Handle(DeleteProduct command, CancellationToken cancellationToken)
            {
                var product = await context.Products.Where(a => a.Id == command.Id).FirstOrDefaultAsync();


                if (product != null)
                {
                    context.Products.Remove(product);
                    await context.SaveProducts();
                    return product.Id;
                }   

                return -1;
            }

            public DeleteProduct(IProductContext c)
            {
                context = c;
            }
 
        }
    }
}


