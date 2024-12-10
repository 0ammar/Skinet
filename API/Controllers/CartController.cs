using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartController(ICartService cartService) : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<ShoppingCart>> GetCartById(string id)
        {
            var cart = await cartService.GetCartAsync(id);
            return Ok(cart ?? new ShoppingCart{Id = id});
        }

        [HttpPost]
        public async Task<ActionResult<ShoppingCart>> UpdateCart(ShoppingCart cart)
        {
            var uppdateCart = await cartService.SetCartAsync(cart);
            if(uppdateCart == null) return BadRequest("Problem with the cart");
            return uppdateCart;
        }

        [HttpDelete]
        public async Task<ActionResult<ShoppingCart>> DeleteCart(string id)
        {
            var result = await cartService.DeleteCartAsync(id);

            if ((bool)!result) return BadRequest("Problem deleting cart");

            return Ok();
        } 
    }
}