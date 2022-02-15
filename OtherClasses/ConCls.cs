using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
using System.Data.SqlClient;

public class ConCls
{

    #region Connection Object
    public SqlConnection Sqlconn, Sqlconn_SP;
    public SqlCommand SqlCmd = new SqlCommand();
    public string strCustmErr = "", strOrgErr = "";
    public int errNo;
    public ConCls()
    {        
        Sqlconn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["EcommerceConStr"].ConnectionString);
        Sqlconn_SP = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["EcommerceConStr"].ConnectionString);
    }


    public void OpenConnection()
    {
        Sqlconn.Open();
        SqlCmd.Connection = Sqlconn;
    }

    public void CloseConnection()
    {
        Sqlconn.Close();
    }

    public int excuteSql(string strSql)
    {
        int rtn = 0;
        try
        {
            SqlCmd.Connection = Sqlconn;
            SqlCmd.Connection.Open();
            SqlCmd.CommandType = CommandType.Text;
            SqlCmd.CommandText = strSql;
            rtn = SqlCmd.ExecuteNonQuery();
            SqlCmd.Connection.Close();
        }
        catch (SqlException ex)
        {
            strOrgErr = ex.Message;
            errNo = ex.ErrorCode;
            if (errNo == 2627)
            {
                strCustmErr = "Record already exists !!.";
            }
            else
                strCustmErr = ex.Message;

            SqlCmd.Connection.Close();
        }
        finally
        {
            SqlCmd.Connection.Close();
        }
        return rtn;
    }

    public int execute_SP(string strSql)
    {
        int success = 0;
        DataTable dt = new DataTable("webDataTable");
        try
        {
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.CommandText = strSql;
            SqlCmd.Connection = Sqlconn;
            da.SelectCommand = SqlCmd;
            da.Fill(dt);
            if (dt.Rows[0]["Success"].ToString() == "0")
            {
                success = 0;

                //dt.Rows[0]["ErrorNumber"].ToString()
                //dt.Rows[0]["ErrorSeverity"].ToString()
                //dt.Rows[0]["ErrorState"].ToString()
                //dt.Rows[0]["ErrorProcedure"].ToString()
                //dt.Rows[0]["ErrorLine"].ToString()
                //dt.Rows[0]["ErrorMessage"].ToString()
                if (dt.Rows[0]["ErrorNumber"].ToString() == "2627")
                {
                    strOrgErr = dt.Rows[0]["ErrorMessage"].ToString();
                    strCustmErr = "Record already exists !!.";
                }
                else
                {
                    strCustmErr = dt.Rows[0]["ErrorMessage"].ToString();
                    strOrgErr = dt.Rows[0]["ErrorMessage"].ToString();
                }
            }
            else
                success = 1;

            return success;
        }
        catch (Exception ex)
        {
            //throw new Exception(ex.Message);
            strOrgErr = ex.Message;
            return success;
        }
    }

    public int ExecuteSql_Trans(string strSql)
    {
        try
        {
            SqlCmd.CommandType = CommandType.Text;
            SqlCmd.CommandText = strSql;
            return SqlCmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            //throw new Exception(ex.Message);
            strOrgErr = ex.Message;
            return 0;
        }
    }


    public DataTable getDataTable(string strSql)
    {
        DataTable dt = new DataTable("webDataTable");
        try
        {
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCmd.CommandType = CommandType.Text;
            SqlCmd.CommandText = strSql;
            SqlCmd.Connection = Sqlconn;
            da.SelectCommand = SqlCmd;
            da.Fill(dt);
            return dt;
        }
        catch (Exception ex)
        {
            //throw new Exception(ex.Message);
            strOrgErr = ex.Message;
            return null;
        }
    }

    public SqlDataReader getDataRow(string strSql)
    {
        SqlDataReader rtn = null;
        try
        {
            SqlCmd.Connection = Sqlconn;
            SqlCmd.Connection.Open();
            SqlCmd.CommandType = CommandType.Text;
            SqlCmd.CommandText = strSql;
            rtn = SqlCmd.ExecuteReader();
            SqlCmd.Connection.Close();
        }
        catch (SqlException ex)
        {
            strOrgErr = ex.Message;
            SqlCmd.Connection.Close();
        }
        finally
        {
            SqlCmd.Connection.Close();
        }
        return rtn;
    }

    public DataTable getDataTable(string strSql, DataSet ds, string dtNm)
    {
        DataTable dt = new DataTable("webDataTable");
        try
        {
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCmd.CommandType = CommandType.Text;
            SqlCmd.CommandText = strSql;
            SqlCmd.Connection = Sqlconn;
            da.SelectCommand = SqlCmd;
            da.Fill(ds, dtNm);
            return ds.Tables[dtNm];
        }
        catch (SqlException ex)
        {
            //throw new Exception(ex.Message);
            strOrgErr = ex.Message;
            return null;
        }
    }

    public DataSet getDataSet(string strSql)
    {
        DataSet ds = new DataSet("webDataSet");
        try
        {
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCmd.CommandType = CommandType.Text;
            SqlCmd.CommandText = strSql;
            SqlCmd.Connection = Sqlconn;
            da.SelectCommand = SqlCmd;
            da.Fill(ds);
        }
        catch (SqlException ex)
        {
            strOrgErr = ex.Message;
            SqlCmd.Connection.Close();
        }
        return ds;
    }

    public string getAll(string tabname, string colName, string ddlvalue, string strWhere)
    {
        if (ddlvalue == "0")
        {
            return String.Empty;
        }
        else
        {
            //if (str == String.Empty)
            //{
            //    str = " where " + "" + tabname + "" + "." + " " + colName + "=" + ddlvalue + "";
            //}
            //else
            //{
            strWhere = " and  " + "" + tabname + "" + "." + colName + "  = " + ddlvalue + "";
            //}
            return strWhere;
        }
    }

    #endregion

    //public void maintainErrLogInErrorLogFile(string strErrorlog)
    //{
    //    try
    //    {
    //        if (File.Exists(Application.StartupPath + "\\errorLog.txt"))
    //        {
    //            using (StreamWriter sw = File.AppendText(Application.StartupPath + "\\errorLog.txt"))
    //            {
    //                sw.WriteLine(">>>>>>>>>>>(" + DateTime.Now.ToString() + ")" + strErrorlog + "\n");
    //                sw.Close();
    //            }
    //        }
    //        else
    //        {
    //            using (StreamWriter sw = File.CreateText(Application.StartupPath + "\\errorLog.txt"))
    //            {
    //                sw.WriteLine(">>>>>>>>>>>(" + DateTime.Now.ToString() + ")" + strErrorlog + "\n");
    //                sw.Close();
    //            }
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        //MessageBox.Show(ex.Message);
    //    }
    //}

}
