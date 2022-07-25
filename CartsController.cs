using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcommerceWebAPI.Models;
using EcommerceWebAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.SqlServer.Dac.Model;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EcommerceWebAPI.Controllers
{

    [Authorize]
    public class CartController : Controller
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<CartItem> cprods = await _cartService.GetItemsAsync(name);


            string? name = GetCurrentUserAsync();

            if (name != null)
            {
                if (cprods != null)
                {
                    ViewBag.TotalAmount = cprods.Sum(c => c.TotalAmount);
                    ViewBag.TotalCount = cprods.Count();

                    return View(cprods);
                }
            }
            return BadRequest();


        }

        private string? GetCurrentUserAsync() => HttpContext.User?.Identity?.Name;
        public ActionResult UpdateQuantity(int itemId, int q)
        {
            return RedirectToAction("Index");
        }

        public ActionResult Add(int id)
        {
            string? name = GetCurrentUserAsync();

            if (name == null)
            {
                var items = _cartService.AddAsync(id, name);

                return RedirectToAction("Index");
            }

            return BadRequest();
        }

        public ActionResult Remove(string id)
        {
            return RedirectToAction("Index");
        }


    }
}

