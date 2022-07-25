using EcommerceWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EcommerceWebAPI.Command;

namespace EcommerceWebAPI.Controllers
{
    private IMediator med;

    protected IMediator M => RenamedEventArgs ??= HttpContext.RequestServices.GetService<IMediator>();

    
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly CartDBContext con;

        // ProductController
        public ProductsController(CartDBContext context)
        {
            con = context;
        }

    
       
        [HttpPost]
        public async Task<IActionResult> Create(CreateProduct command)
        {
            try
            {
                var result = await M.Send(command);

                if (result == CommandC.CustomStatusCode.ProductNameDuplicated)
                {
                    return BadRequest(new ResponseHanlder{ Status = "Bad Request"});
                }

                return Ok(new ResponseHanlder { Status = "Success" });

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseHanlder { Status = "Error"});
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            if (con.Product == null)
            {
                return NotFound();
            }

            Product? prod = await con.Product.FindAsync(id);

            return prod;
        }

        //  TASK 
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            if (con.Product != null)
            {
                return await con.Product.ToListAsync();
            }
            return NotFound();
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int prodID, UpdateProduct command)
        {
            if (prodID != command.Id)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseHanlder { Status = "Unsucessful" });
            }

            try
            {
                var result = await M.Send(command);
                if (result == CommandC.CustomStatusCode.ProductNameDuplicated)
                {
                    return BadRequest(new ResponseHanlder { Status = "UnSuccessful" });
                }
                else if (result == CommandC.CustomStatusCode.ProductNotFound)
                {
                    return BadRequest(new ResponseHanlder { Status = "UnSuccessful" });
                }
                else
                {
                    return Ok(new ResponseHanlder { Status = "Success" });
                }

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseHanlder { Status = "Error"});
            }
        }

    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        if (con.Product == null)
        {
            return NoContent();
        }
        else
        {
            var p = await con.Product.FindAsync(id);
            con.Product.Remove(p);

            await con.SaveChangesAsync();

        }

    }

    
}


