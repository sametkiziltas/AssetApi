using asset.api.Models.Enums;

namespace asset.api.Models.Requests;

public class RequestUpdateAsset : RequestBaseAsset
{
    public Guid Id { get; set; }
    public string Category { get; set; }
    public string MacAddress { get; set; }
    public Status Status { get; set; }

}