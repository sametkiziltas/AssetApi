using asset.api.Models.Base;
using asset.api.Models.Requests;
using asset.api.Models.Responses;

namespace asset.api.Services.Asset;

public interface IAssetService
{
    Task<BaseResponse<List<ResponseAssetGetAll>>> GetAllAsync();
    Task<BaseResponse<ResponseAssetGetById>> GetByIdAsync(Guid id);
    Task<BaseResponse<bool>> CreateAsync(RequestCreateAsset request, Guid userId);
    Task<BaseResponse<bool>> UpdateAsync(RequestUpdateAsset request, Guid userId);
    Task<BaseResponse<bool>> DeleteAsync(Guid id, Guid userId);
}