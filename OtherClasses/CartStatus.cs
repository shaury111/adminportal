using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


public class CartStatus
{
    public enum CartStatus_
    {
        Added_to_cart = 1,
        Removed_from_cart = 2,
        Purchased_the_item = 3     
    }
}