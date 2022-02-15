using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class GetIndianTime
{
    public static DateTime getDateTime()
    {
        // Get time in local time zone 
        DateTime thisTime = DateTime.Now;

        // Get GTB Standard Time zone - (GMT+02:00) Athens, Istanbul, Minsk
        TimeZoneInfo tst = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");  // "GTB Standard Time");
        DateTime tstTime = TimeZoneInfo.ConvertTime(thisTime, TimeZoneInfo.Local, tst);
        return tstTime;
    }

    public static TimeSpan getTimeInterval(DateTime timeDiffFROM, DateTime timeDiffTo)
    {
        TimeSpan diff = timeDiffFROM.Subtract(timeDiffTo);
        return diff;
    }
}