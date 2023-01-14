using asset.api.Entities;
using Microsoft.EntityFrameworkCore;

namespace asset.api.Repositories;

public class AssetRepository : IAssetRepository
{
    private readonly AppDbContext _context;

    public AssetRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<bool> InsertAsync(Asset entity)
    {
        await _context.AddAsync(entity);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<List<Asset>> GetListAsync()
    {
        return await _context.Assets.Where(x => x.IsDeleted == false).ToListAsync();
    }

    public async Task<Asset> GetByIdAsync(Guid id)
    {
        return await _context.Assets.FirstOrDefaultAsync(asset => asset.Id == id);
    }

    public async Task<bool> UpdateAsync(Asset entity)
    {
        _context.Update(entity);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> SoftDeleteAsync(Guid id)
    {
        var entity = await _context.Assets.FirstOrDefaultAsync(asset => asset.Id == id);

        entity.IsDeleted = true;
        _context.Update(entity);
        await _context.SaveChangesAsync();
        return true;
    }
}