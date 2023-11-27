using ASPNet.API.Data;
using ASPNet.API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace ASPNet.API.Repositories;

public class SQLWalkRepository : IWalkRepository
{
    private readonly APSNetDbContext _dbContext;

    public SQLWalkRepository(APSNetDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<Walk> CreateAsync(Walk walk)
    {
        await _dbContext.Walks.AddAsync(walk);
        await _dbContext.SaveChangesAsync();
        return walk;
    }

    public async Task<List<Walk>> GetAllAsync(string? filterOn = null, string? filterQuery = null,
                                                string? sortBy = null, bool isAscending = true,
                                                    int pageNumber = 1, int pageSize = 10)
    {
        var walks = _dbContext.Walks.Include("Difficulty").Include("Region").AsQueryable();
        
        //Filtering
        if (!string.IsNullOrWhiteSpace(filterOn) && !string.IsNullOrWhiteSpace(filterQuery))
        {
            if (filterOn.Equals("Name", StringComparison.OrdinalIgnoreCase))
            {
                walks = walks.Where(x => x.Name.Contains(filterQuery));
            }
        }
        
        //Sorting
        if (!string.IsNullOrWhiteSpace(sortBy))
        {
            if (filterOn.Equals("Name", StringComparison.OrdinalIgnoreCase))
            {
                walks = isAscending ? walks.OrderBy(x => x.Name) : walks.OrderByDescending(x => x.Name);
            }
        }
        
        //Pagination 
        var skipResults = (pageNumber - 1) * pageSize;
        
        return await walks.Skip(skipResults).Take(pageSize).ToListAsync();
    }

    public async Task<Walk?> GetByIdAsync(Guid id)
    {
        return await _dbContext.Walks
            .Include("Difficulty")
            .Include("Region")
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Walk?> UpdateByIdAsync(Guid id, Walk walk)
    {
        var existingWalk = await _dbContext.Walks.FindAsync(id);
        if (existingWalk == null)
            return null;

        existingWalk.Name = walk.Name; 
        existingWalk.Description = walk.Description; 
        existingWalk.LengthInKm = walk.LengthInKm; 
        existingWalk.WalkImageUrl = walk.WalkImageUrl; 
        existingWalk.DifficultyId = walk.DifficultyId; 
        existingWalk.RegionId = walk.RegionId;

        await _dbContext.SaveChangesAsync();
        return existingWalk; 
    }

    public async Task<Walk?> DeleteByIdAsync(Guid id)
    {
        var walk = await _dbContext.Walks.FindAsync(id);
        if (walk == null)
            return null;

        _dbContext.Walks.Remove(walk);
        await _dbContext.SaveChangesAsync();
        return walk; 


    }
}