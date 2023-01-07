using System.Text.RegularExpressions;
using asset.api.Models.Enums;

namespace asset.api.Models.Requests;

public class RequestCreateAsset
{
    public string Category { get; set; }
    public string MacAddress { get; set; }
    public Status Status { get; set; }
    
    public bool IsNotValidMacAddress(string str)
    {
        string regex = "^([0-9A-Fa-f]{2}[:-])"
                       + "{5}([0-9A-Fa-f]{2})|"
                       + "([0-9a-fA-F]{4}\\."
                       + "[0-9a-fA-F]{4}\\."
                       + "[0-9a-fA-F]{4})$";
 
        Regex p = new(regex);
 
        if (str == null)
        {
            return false;
        }
 
        Match m = p.Match(str);
 
        return !m.Success;
    }
}



