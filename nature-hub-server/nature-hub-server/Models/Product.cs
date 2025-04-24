using System.ComponentModel.DataAnnotations;

namespace nature_hub_server.Models
{
    public class Product
    {
        [Key]
        public int PId { get; set; }
        public string PName { get; set; }
        public double PPrice { get; set; }
        public string PDescription { get; set; }
        public string PImageUrl { get; set; }
    }
}
