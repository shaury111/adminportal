using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


public class ProductFilterBy
{
    public enum SortBy
    {
        default_ = 1,
        name_a_to_z = 2,
        name_z_to_a = 3,
        price_low_to_high = 4,
        price_high_to_low = 5,
        rating_highest = 6,
        rating_lowest = 7
    }

    public enum RecordToShow
    {
        all_records = 0,
        top_15 = 15,
        top_25 = 25,
        top_50 = 50,
        top_75 = 75,
        top_100 = 100
    }
}
