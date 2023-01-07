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
        return await _context.Assets.ToListAsync();
    }
}