using Microsoft.AspNetCore.Identity;

namespace crypto_app.Models;

public class AppUser : IdentityUser
{
    public string Name { get; set; }
}
