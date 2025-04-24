using System.ComponentModel.DataAnnotations;

namespace nature_hub_server.Models
{
    public class HealthTip
    {
        [Key]
        public int HId { get; set; }
        public string HName { get; set; }
        public string HDescription { get; set; }
        public string HCategory { get; set; }
    }
}
