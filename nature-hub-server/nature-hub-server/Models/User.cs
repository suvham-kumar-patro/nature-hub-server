using System.ComponentModel.DataAnnotations;

namespace nature_hub_server.Models
{
    public class User
    {
        [Key]
        public int UId { get; set; }

        public string UName { get; set; }
        public string UPassword { get; set; }
    }
}
