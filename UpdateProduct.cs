using System;
namespace EcommerceWebAPI.Command
{
    public class UpdateProduct : IRequest<int>
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public string Description { get; set; }


        public class UpdateItemCmdHandler : IRequestHandler<UpdateProduct, int>
        {
            private readonly IProductContext context;


            
            public async Task<int> Handle(UpdateProduct command, CancellationToken cancellationToken)
            {
                var p = context.Products.Where(e => e.Id == command.Id).FirstOrDefault();
                if (p != null)
                {
                    if (context.Products.Any(e => e.Id != command.Id && e.Name == command.Name))
                    {
                        return 0;
                    }
                    else
                    { 
                        p.Name = command.Name;
                        p.Amount = command.Quantity;
                        p.Price = command.Price;
                        p.Description = command.Description;

                        await context.SaveProducts();

                        return p.Id;
                    }

                }
                
               
                return -1;
            }

            public UpdateItemCmdHandler(IProductContext c)
            {
                this.context = c;
            }
        }
    }
}

