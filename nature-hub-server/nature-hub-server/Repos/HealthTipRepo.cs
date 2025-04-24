using Microsoft.EntityFrameworkCore;
using nature_hub_server.Data;
using nature_hub_server.Models;

namespace nature_hub_server.Repos
{
    public class HealthTipRepo : IHealthTipRepo
    {
        private readonly NatureHubDbContext _natureHubDbContext;

        public HealthTipRepo(NatureHubDbContext natureHubDbContext)
        {
            _natureHubDbContext = natureHubDbContext;
        }
        public async Task AddHealthTip(HealthTip healthTip)
        {
            await _natureHubDbContext.HealthTips.AddAsync(healthTip);
            await _natureHubDbContext.SaveChangesAsync();
        }

        public async Task DeleteHealthTip(int id)
        {
            var healthTip = await _natureHubDbContext.HealthTips.FindAsync(id);
            if (healthTip != null)
            {
                _natureHubDbContext.HealthTips.Remove(healthTip);
                await _natureHubDbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<HealthTip>> GetHealthTip()
        {
            return await _natureHubDbContext.HealthTips.ToListAsync();
        }

        public Task<HealthTip> GetHealthTipById(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateHealthTip(HealthTip healthTip)
        {
            throw new NotImplementedException();
        }
    }
}
