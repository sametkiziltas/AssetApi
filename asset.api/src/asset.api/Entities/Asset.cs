using asset.api.Entities.Base;
using asset.api.Models.Enums;

namespace asset.api.Entities;

public class Asset : ModifiableEntity
{
    public string Category { get; set; }
    public string MacAddress { get; set; }
    public Status Status { get; set; }
    
}