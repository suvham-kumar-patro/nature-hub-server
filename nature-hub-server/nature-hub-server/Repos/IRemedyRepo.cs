using nature_hub_server.Models;

namespace nature_hub_server.Repos
{
    public interface IRemedyRepo
    {
        Task<IEnumerable<Remedy>> GetRemedies();
        Task<Remedy> GetById(int id);
        Task Add(Remedy remedy);
        Task Update(Remedy remedy);
        Task DeleteByid(int id);
    }
}
