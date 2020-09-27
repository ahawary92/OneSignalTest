using Microsoft.AspNet.Identity.EntityFramework;

namespace Core.Domain
{
    public class MyDbContext : IdentityDbContext<AppUser>
    {
    }
}
