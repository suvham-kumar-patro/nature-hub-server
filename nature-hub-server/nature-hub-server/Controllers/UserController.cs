using Microsoft.AspNetCore.Mvc;
using nature_hub_server.Models;
using nature_hub_server.Repos;

namespace nature_hub_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepo _repo;
        public UserController(IUserRepo repo)
        {
            _repo = repo;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> Get()
        {
            return Ok(await _repo.GetUsers());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> Get(int id)
        {
            var user = await _repo.GetById(id);
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
        public async Task<ActionResult<User>> Post(User user)
        {
            try
            {
                await _repo.Add(user);
                return CreatedAtAction(nameof(Get), new { id = user.UId }, user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpPut("{id}")]
        public async Task<ActionResult<User>> Put(int id, User user)
        {
            if (id != user.UId)
            {
                return BadRequest();
            }
            await _repo.Update(user);
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
