using asset.api.Models.Base;
using asset.api.Models.Requests;
using asset.api.Models.Responses;
using asset.api.Models.Responses;
using asset.api.Services;
using asset.api.Services.Asset;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Core;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace asset.api.Controllers;


[Route("api/assets")]
public class AssetController : ControllerBase
{
    private readonly IAssetService _assetService;

    #region constructor

    public AssetController(IAssetService assetService)
    {
        _assetService = assetService;
    }

    #endregion
    
    /// <summary>
    /// Gets all assets that are active
    /// </summary>
    [HttpGet]
    [ProducesResponseType(typeof(BaseResponse<List<ResponseAssetGetAll>>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll([FromHeader] Guid userId)
    {
        //TODO:Paging
        BaseResponse<List<ResponseAssetGetAll>> response = await _assetService.GetAllAsync();
        return Ok(response);
    }
    
    /// <summary>
    /// Get asset with given id
    /// </summary>
    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(BaseResponse<ResponseAssetGetById>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetById([FromHeader] Guid userId, Guid id)
    {
        BaseResponse<ResponseAssetGetById> response = await _assetService.GetByIdAsync(id);

        if (response.Data == default)
            return NotFound();

        return Ok();
    }
    
    /// <summary>
    /// Creates an Asset.
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="request"></param>
    /// <returns>Is it created successfully?</returns>
    [HttpPost]
    [ProducesResponseType(typeof(BaseResponse<bool>), StatusCodes.Status200OK)]
    public async Task<IActionResult> Create([FromHeader] Guid userId, [FromBody] RequestCreateAsset request)
    {
        BaseResponse<bool> response = await _assetService.CreateAsync(request, userId);
        return Ok(response);
    }

    /// <summary>
    /// Update asset with given asset infos
    /// </summary>
    [HttpPut]
    [ProducesResponseType(typeof(BaseResponse<bool>), StatusCodes.Status200OK)]
    public async Task<IActionResult> Update([FromHeader] Guid userId, [FromBody] RequestUpdateAsset request)
    {
        BaseResponse<bool> response = await _assetService.UpdateAsync(request, userId);
        return Ok(response);
    }
    
    /// <summary>
    /// Delete asset with given asset id
    /// </summary>
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(typeof(BaseResponse<bool>), StatusCodes.Status200OK)]
    public async Task<IActionResult> Delete([FromHeader] Guid userId, Guid id)
    {
        BaseResponse<bool> response = await _assetService.DeleteAsync(id, userId);

        return Ok();
    }
}