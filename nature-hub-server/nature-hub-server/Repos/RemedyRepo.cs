using Microsoft.EntityFrameworkCore;
using nature_hub_server.Data;
using nature_hub_server.Models;

namespace nature_hub_server.Repos
{
    public class RemedyRepo : IRemedyRepo
    {
        private readonly NatureHubDbContext _repo;
        public RemedyRepo(NatureHubDbContext repo)
        {
            _repo = repo;
        }
        public async Task Add(Remedy remedy)
        {
            await _repo.Remedies.AddAsync(remedy);
            await _repo.SaveChangesAsync();
        }

        public async Task DeleteByid(int id)
        {
            var remedy = await _repo.Remedies.FindAsync(id);
            if (remedy != null)
            {
                _repo.Remedies.Remove(remedy);
                await _repo.SaveChangesAsync();
            }
        }

        public async Task<Remedy> GetById(int id)
        {
            return await _repo.Remedies.FindAsync(id);
        }

        public async Task<IEnumerable<Remedy>> GetRemedies()
        {
            return await _repo.Remedies.ToListAsync();
        }

        public async Task Update(Remedy remedy)
        {
            _repo.Remedies.Update(remedy);
            await _repo.SaveChangesAsync();
        }
    }
}
