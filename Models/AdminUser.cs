using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Models
{
    public class AdminUser
    {


        [Required]
        [StringLength(100)]
        public string UserId { get; set; }
        public string Password { get; set; }
    }

}