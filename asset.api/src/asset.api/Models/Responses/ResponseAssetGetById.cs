namespace asset.api.Models.Responses;

public class ResponseAssetGetById
{
    public Guid Id { get; set; }
    public string Category { get; set; }
    public string MacAddress { get; set; }
    public string Status { get; set; }
    public Guid CreatedUserId { get; set; }
    public Guid? UpdatedUserId { get; set; }
}