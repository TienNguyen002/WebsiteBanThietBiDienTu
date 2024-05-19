using Microsoft.AspNetCore.Identity;

namespace Domain.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string? Name { get; set; }
        public string? Address { get; set; }
        public IList<Comment> Comments { get; set; }
        public IList<Order> Orders { get; set; }
    }
}
