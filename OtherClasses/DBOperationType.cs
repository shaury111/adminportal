using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public static class DBOperationType
{
    public static string Active = "A";
    public static string InActive = "I";
    public static string Cancelled = "C";
    public enum DbOperations
    {
        Select = 0,
        Save = 1,
        Update = 2,
        Delete = 3
    }

    public enum RecordStatus
    {
        /// <summary>
        /// For Active Record Please Enter  (A)
        /// </summary>
        Active = 0,
        /// <summary>
        /// For InActive Record Please Enter  (I)
        /// </summary>
        InActive = 1,
        /// <summary>
        /// For Cancelled Record Please Enter  (C)
        /// </summary>
        Cancelled = 2
    }
}