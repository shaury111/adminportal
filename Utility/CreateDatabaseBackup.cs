using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ecommerce.Utility
{
    public class CreateDatabaseBackup
    {
        ConCls con = new ConCls();
        public int CreateDB_Backup(string filePath, string DbNm)
        {
            try
            {

                string strQ = @"BACKUP DATABASE [" + DbNm + "] TO DISK = N'" + filePath + @"'
                        WITH NOFORMAT, NOINIT, NAME = N'dbDatabase_backup', SKIP, NOREWIND, NOUNLOAD, STATS = 10";
                return con.excuteSql(strQ);
            }
            catch
            {
                return 0;
            }

        }
    }
}