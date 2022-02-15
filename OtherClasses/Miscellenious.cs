using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

using System.Data.Entity;
using System.Data;
using System.Reflection;

public class Miscellenious
{
    static public string GetRandomKey(int len = 6)
    {
        try
        {
            Random random = new Random();
            //string combination = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            string combination = "0123456789";
            StringBuilder captcha = new StringBuilder();
            for (int i = 0; i < len; i++)
                captcha.Append(combination[random.Next(combination.Length)]);

            return captcha.ToString();

        }
        catch
        {
            return "9211";
        }
    }

    static public List<string> GetRandomColorCode(int numColors = 10)
    {
        try
        {            
            var colors = new List<string>();
            var random = new Random(); // Make sure this is out of the loop!
            for (int i = 0; i < numColors; i++)
            {
                colors.Add(String.Format("#{0:X6}", random.Next(0x1000000)));
            }

            return colors;
        }
        catch
        {
            return null;
        }
    }

    

    #region MyRegion
    public static List<T> ConvertDataTable<T>(DataTable dt)
    {
        List<T> data = new List<T>();
        foreach (DataRow row in dt.Rows)
        {
            T item = GetItem<T>(row);
            data.Add(item);
        }
        return data;
    }
    private static T GetItem<T>(DataRow dr)
    {
        Type temp = typeof(T);
        T obj = Activator.CreateInstance<T>();

        foreach (DataColumn column in dr.Table.Columns)
        {
            foreach (PropertyInfo pro in temp.GetProperties())
            {
                if (pro.Name == column.ColumnName)
                    pro.SetValue(obj, dr[column.ColumnName], null);
                else
                    continue;
            }
        }
        return obj;
    }
    #endregion

    public static DataTable ToDataTable<T>(List<T> items)
    {
        DataTable dataTable = new DataTable(typeof(T).Name);
        //Get all the properties by using reflection   
        PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
        foreach (PropertyInfo prop in Props)
        {
            //Setting column names as Property names  
            dataTable.Columns.Add(prop.Name);
        }
        foreach (T item in items)
        {
            var values = new object[Props.Length];
            for (int i = 0; i < Props.Length; i++)
            {

                values[i] = Props[i].GetValue(item, null);
            }
            dataTable.Rows.Add(values);
        }

        return dataTable;
    }

}