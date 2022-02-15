using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class GeoMapTransitMode
{    
    public enum Transit_Mode
    {
        bus = 0,
        train = 1
    }

    public enum Mode
    {
        transit = 0,
        driving = 1,
        walking = 2,
        bicycling = 3
    }
}