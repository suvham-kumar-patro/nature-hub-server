using nature_hub_server.Models;

namespace nature_hub_server.Repos
{
    public interface IHealthTipRepo
    {
        Task<IEnumerable<HealthTip>> GetHealthTip();

        Task<HealthTip> GetHealthTipById(int id);

        Task AddHealthTip(HealthTip healthTip);

        Task UpdateHealthTip(HealthTip healthTip);

        Task DeleteHealthTip(int id);


    }
}
