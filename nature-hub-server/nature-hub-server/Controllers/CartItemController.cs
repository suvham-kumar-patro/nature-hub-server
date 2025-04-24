using Microsoft.AspNetCore.Mvc;
using nature_hub_server.Models;
using nature_hub_server.Repos;

namespace nature_hub_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartItemController : ControllerBase
    {

        private readonly ICartItemRepo _cartRepo;

        public CartItemController(ICartItemRepo cartRepo)
        {
            _cartRepo = cartRepo;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<CartItem>>> Get()
        {
            var carts = await _cartRepo.GetCart();
            if (carts == null)
            {
                return NotFound();
            }
            return Ok(carts);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CartItem>> Get(int id)
        {
            var cart = await _cartRepo.GetCartById(id);
            if (cart == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(cart);
            }
        }
        [HttpPost]
        public async Task<ActionResult<CartItem>> Post(CartItem cart)
        {
            await _cartRepo.AddCart(cart);
            return CreatedAtAction(nameof(Get), new { id = cart.CartItemId }, cart);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<CartItem>> Put(int id, CartItem cart)
        {
            if (id != cart.CartItemId)
            {
                return BadRequest();
            }

            await _cartRepo.UpdateCart(cart);
            return NoContent();

        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var cart = await _cartRepo.GetCartById(id);
            if (cart == null)
            {
                return NotFound();
            }
            await _cartRepo.DeleteCart(id);
            return NoContent();
        }
    }
}
