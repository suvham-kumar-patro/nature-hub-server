using System.ComponentModel.DataAnnotations;
namespace nature_hub_server.Models
{
    public class CartItem
    {
        [Key]
        public int CartItemId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
