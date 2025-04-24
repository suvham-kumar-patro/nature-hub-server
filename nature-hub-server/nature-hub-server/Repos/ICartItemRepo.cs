using nature_hub_server.Models;

namespace nature_hub_server.Repos
{
    public interface ICartItemRepo
    {
        Task<IEnumerable<CartItem>> GetCart();
        Task<CartItem> GetCartById(int id);
        Task AddCart(CartItem cart);
        Task UpdateCart(CartItem cart);
        Task DeleteCart(int id);
    }
}
