using asset.api.Entities;

namespace asset.api.Repositories;

public interface IAssetRepository
{
    Task<bool> InsertAsync(Asset entity);

    Task<List<Asset>> GetListAsync();
}