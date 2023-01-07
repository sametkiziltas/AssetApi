namespace asset.api.Models.Responses;

public class ResponseAssetGetAll
{
    public string Category { get; set; }
    public string MacAddress { get; set; }
    public string Status { get; set; }
    public Guid CreatedUserId { get; set; }
    public Guid? UpdatedUserId { get; set; }
}