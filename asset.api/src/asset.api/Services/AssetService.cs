using asset.api.Entities;
using asset.api.Models.Base;
using asset.api.Models.Enums;
using asset.api.Models.Requests;
using asset.api.Models.Responses;
using asset.api.Repositories;

namespace asset.api.Services;

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

        if (request.IsNotValidMacAddress(request.MacAddress))
            return response.SetError("MAC Address is not valid!");

        
        bool result = await _assetRepository.InsertAsync(new Asset
        {
            CreatedBy = userId,
            Category = request.Category,
            MacAddress = request.MacAddress,
            Status = Status.Caution
        });

        return response.SetData(result);
    }

    public async Task<BaseResponse<List<ResponseAssetGetAll>>> GetAllAsync()
    {
        BaseResponse<List<ResponseAssetGetAll>> response = new();

        var data = await _assetRepository.GetListAsync();

        var result = data.Select(x => new ResponseAssetGetAll()
        {
            Category = x.Category,
            MacAddress = x.MacAddress,
            Status = x.Status.ToString(),
            CreatedUserId = x.CreatedBy,
            UpdatedUserId = x.UpdatedBy
        });
        
        response.Data.AddRange(result);
        
        return response;
    }
}