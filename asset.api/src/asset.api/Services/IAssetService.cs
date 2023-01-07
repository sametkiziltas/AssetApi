using asset.api.Models.Base;
using asset.api.Models.Requests;
using asset.api.Models.Responses;

namespace asset.api.Services;

public interface IAssetService
{
    Task<BaseResponse<bool>> CreateAsync(RequestCreateAsset request, Guid userId);
    Task<BaseResponse<List<ResponseAssetGetAll>>> GetAllAsync();
}