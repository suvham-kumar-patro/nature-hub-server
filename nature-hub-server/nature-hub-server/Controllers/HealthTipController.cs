using Microsoft.AspNetCore.Mvc;
using nature_hub_server.Models;
using nature_hub_server.Repos;

namespace nature_hub_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthTipController : ControllerBase
    {
        private readonly IHealthTipRepo _healthTipRepo;

        public HealthTipController(IHealthTipRepo healthTipRepo)
        {
            _healthTipRepo = healthTipRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<HealthTip>>> Get()
        {
            var healthTips = await _healthTipRepo.GetHealthTip();
            if (healthTips == null)
            {
                return NotFound();
            }
            return Ok(healthTips);
        }
    }
}
