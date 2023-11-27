using ASPNet.API.Data;
using ASPNet.API.Models.Domain;
using Microsoft.CodeAnalysis.Elfie.Serialization;
using Microsoft.EntityFrameworkCore;

namespace ASPNet.API.Repositories;

public class SQLRegionRepository : IRegionRepository
{
    private readonly APSNetDbContext _dbContext;

    public SQLRegionRepository(APSNetDbContext dbContext)
    {
        this._dbContext = dbContext; 
    }
    
    public async Task<List<Region>> GetAllAsync()
    {
        return await _dbContext.Regions.ToListAsync();
    }

    public async Task<Region?> GetById(Guid Id)
    {
        return await _dbContext.Regions.FirstOrDefaultAsync(region => region.Id == Id);
    }

    public async Task<Region> Create(Region region)
    {
        await _dbContext.Regions.AddAsync(region);
        await _dbContext.SaveChangesAsync();
        return region; 
    }

    public async Task<Region?> Updated(Guid id, Region region)
    {
        var existingRegion = await _dbContext.Regions.FindAsync(id);
        if (existingRegion == null)
            return null;

        existingRegion.Code = region.Code;
        existingRegion.Name = region.Name;
        existingRegion.RegionImageUrl = region.RegionImageUrl;

        await _dbContext.SaveChangesAsync();
        
        return existingRegion; 
    }

    public async Task<Region?> Delete(Guid id)
    {
        var existingRegion = await _dbContext.Regions.FindAsync(id);
        if (existingRegion == null)
            return null;

        _dbContext.Regions.Remove(existingRegion);
        return existingRegion; 
    }
}