using System.Text.RegularExpressions;
using asset.api.Models.Enums;

namespace asset.api.Models.Requests;

public class RequestCreateAsset : RequestBaseAsset
{
    public string Category { get; set; }
    public string MacAddress { get; set; }
}



