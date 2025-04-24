using System.ComponentModel.DataAnnotations;

namespace nature_hub_server.Models
{
    public class Remedy
    {
        [Key]
        public int RId { get; set; }
        public string RName { get; set; }
        public string RDescription { get; set; }
        public string RBenefits { get; set; }
        public string RPreparationMethod { get; set; }
        public string RUsageInstructions { get; set; }
    }
}
