using Microsoft.EntityFrameworkCore;
using nature_hub_server.Data;
using nature_hub_server.Models;

namespace nature_hub_server.Repos
{
    public class ProductRepo : IProductRepo
    {
        private readonly NatureHubDbContext _repo;
        public ProductRepo(NatureHubDbContext repo)
        {
            _repo = repo;
        }

        public async Task Add(Product product)
        {
            await _repo.Products.AddAsync(product);
            await _repo.SaveChangesAsync();
        }



        public async Task DeleteByid(int id)
        {
            var product = await _repo.Products.FindAsync(id);
            if (product != null)
            {
                _repo.Products.Remove(product);
                await _repo.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await _repo.Products.ToListAsync();
        }

        public async Task<Product> GetProductById(int id)
        {
            return await _repo.Products.FindAsync(id);
        }

        public async Task Update(Product product)
        {
            _repo.Products.Update(product);
            await _repo.SaveChangesAsync();
        }
    }
}
