using asset.api.Models.Base;
using asset.api.Models.Requests;
using asset.api.Models.Responses;
using asset.api.Models.Responses;
using asset.api.Services;
using Microsoft.AspNetCore.Mvc.Core;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace user.api.Controllers;

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

    [HttpGet]
    [ProducesResponseType(typeof(BaseResponse<List<ResponseAssetGetAll>>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll()
    {
        //TODO:Paging
        BaseResponse<List<ResponseAssetGetAll>> response = await _assetService.GetAllAsync();
        return Ok(response);
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(BaseResponse<ResponseAssetGetById>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetById(Guid id)
    {
        return Ok();
    }

    [HttpPost]
    [ProducesResponseType(typeof(BaseResponse<bool>), StatusCodes.Status200OK)]
    public async Task<IActionResult> Create([FromHeader] Guid userId, [FromBody] RequestCreateAsset request)
    {
        BaseResponse<bool> response = await _assetService.CreateAsync(request, userId);
        return Ok(response);
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(typeof(BaseResponse<ResponseAssetGetById>), StatusCodes.Status200OK)]
    public async Task<IActionResult> Update(Guid id)
    {
        return Ok();
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(typeof(BaseResponse<ResponseAssetGetById>), StatusCodes.Status200OK)]
    public async Task<IActionResult> Delete(Guid id)
    {
        return Ok();
    }
}