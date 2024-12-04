using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Model;
using IATM;
using System.Data.SqlClient;
using System.Data;
using DBUtility;

namespace ATMDAL
{
  public  class seemoneyDAL:Iseemoney
    {
        SqlHelper dbhelper = new SqlHelper();
        public string see(string AccountNumber)
        {
            string Balance ="";
            string sql = "select*from Accounts where Status=0 and AccountNumber= @AccountNumber";
            SqlParameter[] sp = new SqlParameter[] {
            new SqlParameter("@AccountNumber",SqlDbType.NVarChar){Value=AccountNumber},
            };
            DataTable dt = dbhelper.GetDataTable(dbhelper._dbConnectionString, CommandType.Text, sql, sp);
            //存在账户
            if (dt.Rows.Count > 0)
            {
                Balance= dt.Rows[0]["Balance"].ToString();

            }
            
            return Balance;
          

        }
    }
}
