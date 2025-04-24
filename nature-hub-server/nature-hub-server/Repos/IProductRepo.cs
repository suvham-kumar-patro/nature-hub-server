using nature_hub_server.Models;

namespace nature_hub_server.Repos
{
    public interface IProductRepo
    {
        Task<IEnumerable<Product>> GetAllProducts();
        Task<Product> GetProductById(int id);
        Task Add(Product product);
        Task Update(Product product);
        Task DeleteByid(int id);
    }
}
