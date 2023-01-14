using asset.api.Entities;

namespace asset.api.Repositories;

public interface IAssetRepository
{
    Task<Asset> GetByIdAsync(Guid id);
    Task<List<Asset>> GetListAsync();
    Task<bool> InsertAsync(Asset entity);
    Task<bool> UpdateAsync(Asset entity);
    Task<bool> SoftDeleteAsync(Guid id);
}