using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class ItemDeliveryStatus
{
    public enum DeliveryStatus
    {
        Item_Booked = 1,
        Waiting_for_Admin_Confirmation = 2,
        Admin_Confirmed = 3,
        Ready_to_Dispatch_from_Sender = 4,
        Item_Dispatched = 5,
        Ready_to_Deliver = 6,
        Item_Delivered_Received = 7,
        Item_Order_Rejected = 8
    }
}