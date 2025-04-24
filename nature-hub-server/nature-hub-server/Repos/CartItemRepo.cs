using Microsoft.EntityFrameworkCore;
using nature_hub_server.Data;
using nature_hub_server.Models;

namespace nature_hub_server.Repos
{
    public class CartItemRepo : ICartItemRepo
    {
        private readonly NatureHubDbContext _natureHubDbContext;

        public CartItemRepo(NatureHubDbContext natureHubDbContext)
        {
            _natureHubDbContext = natureHubDbContext;
        }

        public async Task AddCart(CartItem cart)
        {
            var existingItem = await _natureHubDbContext.Carts
             .FirstOrDefaultAsync(c => c.ProductId == cart.ProductId);

            if (existingItem != null)
            {
                existingItem.Quantity += cart.Quantity;
                _natureHubDbContext.Carts.Update(existingItem);
            }
            else
            {
                await _natureHubDbContext.Carts.AddAsync(cart);
            }

            await _natureHubDbContext.SaveChangesAsync();
        }

        public async Task DeleteCart(int id)
        {
            var cart = await _natureHubDbContext.Carts.FindAsync(id);
            if (cart != null)
            {
                _natureHubDbContext.Carts.Remove(cart);
                await _natureHubDbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<CartItem>> GetCart()
        {
            return await _natureHubDbContext.Carts.ToListAsync();
        }

        public async Task<CartItem> GetCartById(int id)
        {
            return await _natureHubDbContext.Carts.FindAsync(id);
        }

        public async Task UpdateCart(CartItem cart)
        {
            _natureHubDbContext.Carts.Update(cart);
            await _natureHubDbContext.SaveChangesAsync();
        }
    }
}
