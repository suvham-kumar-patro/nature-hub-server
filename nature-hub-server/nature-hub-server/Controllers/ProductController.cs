using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using nature_hub_server.Models;
using nature_hub_server.Repos;

namespace nature_hub_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepo _repo;
        public ProductController(IProductRepo repo)
        {
            _repo = repo;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> Get()
        {
            return Ok(await _repo.GetAllProducts());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> Get(int id)
        {
            var user = await _repo.GetProductById(id);
            if (user == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(user);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Product>> Post(Product product)
        {
            await _repo.Add(product);
            return CreatedAtAction(nameof(Get), new { id = product.PId }, product);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Product>> Put(int id, Product product)
        {
            if (id != product.PId)
            {
                return BadRequest();
            }
            await _repo.Update(product);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _repo.DeleteByid(id);
            return NoContent();
        }
    }
}
