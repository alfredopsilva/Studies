using ASPNet.API.Models.Domain;

namespace ASPNet.API.Repositories;

public interface IRegionRepository
{
    Task<List<Region>> GetAllAsync();
    Task<Region?> GetById(Guid Id);
    Task<Region> Create(Region region);
    Task<Region?> Updated(Guid id, Region region);
    Task<Region?> Delete(Guid id);
}