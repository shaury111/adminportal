using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class TruncateLongString
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="fullString"></param>
    /// <param name="length">Given Length plus 3 dots</param>
    /// <returns></returns>
    static public string TruncateString(string fullString, int length = 20)
    {        
        return (fullString != null && fullString.Length >= length)? fullString.Substring(0, length) + "..." : fullString;
    }
}