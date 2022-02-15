using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


public class OrderStatus
{
    public enum OrderStatus_
    {
        Confirmed = 1,
        Cancelled = 2,
        Refunded = 3,
        Replacement = 4
    }
}