using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ASPNet.API.Data;

public class AspWalksDbContext : IdentityDbContext
{
    public AspWalksDbContext(DbContextOptions<AspWalksDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        var readerRoleId = "ee626480-f3e6-4db3-96b6-d0d71a97c1b5";
        var writerRoleId = "7a42c06c-ac96-41f7-8515-0c6c6e83cdbe";

        var roles = new List<IdentityRole>
        {
            new IdentityRole
            {
                Id = readerRoleId,
                ConcurrencyStamp = readerRoleId,
                Name = "Reader",
                NormalizedName = "Reader".ToUpper()
            },
            new IdentityRole
            {
                Id = writerRoleId,
                ConcurrencyStamp = writerRoleId,
                Name = "Writer",
                NormalizedName = "Writer".ToUpper()
            }

        };

        builder.Entity<IdentityRole>().HasData(roles);
    }
}   