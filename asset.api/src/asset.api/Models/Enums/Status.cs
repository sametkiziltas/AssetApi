using System.ComponentModel;

namespace asset.api.Models.Enums;

public enum Status
{
    [Description("Default")]
    Caution = 1,
    Usable = 2,
    Down = 3,
    Passive = 4,
}