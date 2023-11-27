using ASPNet.API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace ASPNet.API.Data;

public class APSNetDbContext : DbContext
{
    public APSNetDbContext(DbContextOptions<APSNetDbContext> dbContextOptions) : base(dbContextOptions)
    {

    }
    
    public DbSet<Difficulty> Difficulties { get; set; }
    public DbSet<Region> Regions { get; set; }
    public DbSet<Walk> Walks { get; set; }
    public DbSet<Image> Images { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        //Seed Data For Difficulties 
        var difficulties = new List<Difficulty>()
        {
            new Difficulty()
            {
                Id = Guid.Parse("06c543cc-35ef-44ce-b07f-f51b67f9c268"),
                Name = "Easy"
            },
            new Difficulty()
            {
                Id = Guid.Parse("c90f9516-7255-42ae-8071-8b8612125fff"),
                Name = "Medium"
            },
            new Difficulty()
            {
                Id = Guid.Parse("9f96adeb-d150-4105-8dc1-07bf5693b397"),
                Name = "Hard"
            },
        };

        modelBuilder.Entity<Difficulty>().HasData(difficulties);
        
        //Seed Data for Regions 
        var regions = new List<Region>
        {
            new Region
            {
                Id = Guid.Parse("099574af-e075-42ec-917c-34ad68c9c60b"), Name = "Uberaba", Code = "UBA", RegionImageUrl = "www.imageofuberaba.com.br"
            },
            new Region
            {
                Id = Guid.Parse("c243864e-fcad-4429-acfc-bb5c82122334"), Name = "Uberlândia", Code = "UDI", RegionImageUrl = "www.imageofuberlândia.com.br"
            },
            new Region
            {
                Id = Guid.Parse("be242579-c8a9-486b-9f4e-3cae5c0c7b36"), Name = "Ituiutaba", Code = "ITB", RegionImageUrl = "wwww.imageofituiutaba.com.br"
            }
        };

        modelBuilder.Entity<Region>().HasData(regions);
        
        //Seed Data for Wa

    }
}
