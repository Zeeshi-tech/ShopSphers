using Microsoft.AspNetCore.Identity;

namespace ShopSphere.Models
{
    public class ApplicationUser : IdentityUser
    {
        public bool IsSellerApproved { get; set; } = false;

        public bool IsAdmin { get; set; } = false;
    }
}
