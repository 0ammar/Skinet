using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class CartController(ICartService cartService) : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<ShoppingCart>> GetCartById(string id)
        {
            var cart = await cartService.GetCartAsync(id);
            return Ok(cart ?? new ShoppingCart { Id = id });
        }

        [HttpPost]
        public async Task<ActionResult<ShoppingCart>> UpdateCart(ShoppingCart cart)
        {
            if (string.IsNullOrWhiteSpace(cart.Id))
            {
                return BadRequest(new
                {
                    Title = "Validation Error",
                    Status = 400,
                    Errors = new { Id = new[] { "The id field is required." } }
                });
            }
            var uppdateCart = await cartService.SetCartAsync(cart);
            if (uppdateCart == null) return BadRequest("Problem with the cart");
            return Ok(uppdateCart);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteCart(string id)
        {
            var result = await cartService.DeleteCartAsync(id);

            if (!result) return BadRequest("Problem deleting cart");

            return Ok();
        }
    }
}