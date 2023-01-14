using asset.api.Entities;
using asset.api.Models.Base;
using asset.api.Models.Enums;
using asset.api.Models.Requests;
using asset.api.Models.Responses;
using asset.api.Repositories;

namespace asset.api.Services.Asset;

public class AssetService : IAssetService
{
    private readonly IAssetRepository _assetRepository;

    public AssetService(IAssetRepository assetRepository)
    {
        _assetRepository = assetRepository;
    }

    public async Task<BaseResponse<bool>> CreateAsync(RequestCreateAsset request, Guid userId)
    {
        BaseResponse<bool> response = new();
        
        if (userId == default)
            return response.SetError("User must be authenticated!");

        if (request.IsInvalidMacAddress(request.MacAddress))
            return response.SetError("MAC Address is not valid!");

        
        bool result = await _assetRepository.InsertAsync(new Entities.Asset
        {
            CreatedBy = userId,
            Category = request.Category,
            MacAddress = request.MacAddress,
            Status = Status.Caution
        });

        return response.SetData(result);
    }

    public async Task<BaseResponse<bool>> UpdateAsync(RequestUpdateAsset request, Guid userId)
    {
        BaseResponse<bool> response = new();
        
        if (request.Id == default)
            return response.SetError("Asset must be selected!");

        if (userId == default)
            return response.SetError("User must be authenticated!");

        if (request.IsInvalidMacAddress(request.MacAddress))
            return response.SetError("New MAC Address is not valid!");

        var entity = await _assetRepository.GetByIdAsync(request.Id);

        entity.Category = request.Category;
        entity.MacAddress = request.MacAddress;
        entity.Status = request.Status;
        entity.UpdatedBy = userId;
        
        bool result = await _assetRepository.UpdateAsync(entity);

        return response.SetData(result);
    }


    public async Task<BaseResponse<List<ResponseAssetGetAll>>> GetAllAsync()
    {
        BaseResponse<List<ResponseAssetGetAll>> response = new();

        var entity = await _assetRepository.GetListAsync();

        var result = entity.Select(x => new ResponseAssetGetAll()
        {
            Id = x.Id,
            Category = x.Category,
            MacAddress = x.MacAddress,
            Status = x.Status.ToString(),
            CreatedUserId = x.CreatedBy,
            UpdatedUserId = x.UpdatedBy
        });
        
        response.Data.AddRange(result);
        
        return response;
    }

    public async Task<BaseResponse<ResponseAssetGetById>> GetByIdAsync(Guid id)
    {
        BaseResponse<ResponseAssetGetById> response = new();

        if (id == default)
            return response.SetError("Asset Id is not valid!");

        var entity = await _assetRepository.GetByIdAsync(id);

        var result = new ResponseAssetGetById()
        {
            Id = entity.Id,
            Category = entity.Category,
            MacAddress = entity.MacAddress,
            Status = entity.Status.ToString(),
            CreatedUserId = entity.CreatedBy,
            UpdatedUserId = entity.UpdatedBy
        };

        return response.SetData(result);
    }
    
    public async Task<BaseResponse<bool>> DeleteAsync(Guid id, Guid userId)
    {
        BaseResponse<bool> response = new();

        if (id == default)
            return response.SetError("Asset Id is not valid!");

        bool result = await _assetRepository.SoftDeleteAsync(id);
        
        return response.SetData(result);
    }

}