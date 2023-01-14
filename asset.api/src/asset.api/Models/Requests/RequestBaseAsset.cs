using System.Text.RegularExpressions;

namespace asset.api.Models.Requests;

public class RequestBaseAsset
{
    public bool IsInvalidMacAddress(string str)
    {
        string regex = "^([0-9A-Fa-f]{2}[:-])"
                       + "{5}([0-9A-Fa-f]{2})|"
                       + "([0-9a-fA-F]{4}\\."
                       + "[0-9a-fA-F]{4}\\."
                       + "[0-9a-fA-F]{4})$";
 
        Regex p = new(regex);
 
        if (str == null)
            return false;
 
        Match m = p.Match(str);
 
        return !m.Success;
    }
}