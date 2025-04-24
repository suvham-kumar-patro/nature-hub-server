using Microsoft.AspNetCore.Mvc;
using nature_hub_server.Models;
using nature_hub_server.Repos;

namespace nature_hub_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RemedyController : ControllerBase
    {
        private readonly IRemedyRepo _repo;
        public RemedyController(IRemedyRepo repo)
        {
            _repo = repo;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Remedy>>> Get()
        {
            return Ok(await _repo.GetRemedies());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Remedy>> Get(int id)
        {
            var rem = await _repo.GetById(id);
            if (rem == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(rem);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Remedy>> Post(Remedy remedy)
        {
            await _repo.Add(remedy);
            return CreatedAtAction(nameof(Get), new { id = remedy.RId }, remedy);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Remedy>> Put(int id, Remedy remedy)
        {
            if (id != remedy.RId)
            {
                return BadRequest();
            }
            await _repo.Update(remedy);
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
