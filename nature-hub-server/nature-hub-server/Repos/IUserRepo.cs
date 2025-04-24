using nature_hub_server.Models;

namespace nature_hub_server.Repos
{
    public interface IUserRepo
    {
        Task<IEnumerable<User>> GetUsers();
        Task<User> GetById(int id);
        Task Add(User user);
        Task Update(User user);
        Task DeleteByid(int id);
    }
}
