using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IotApi.Data;

public class IdentityContext: IdentityDbContext<AppUser>
{
    public IdentityContext(DbContextOptions options) : base(options) {}
    
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        if (!builder.IsConfigured)
        {
            builder.UseSqlServer();
        }
    }
}