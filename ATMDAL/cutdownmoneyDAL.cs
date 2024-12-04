using Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using IATM;
using DBUtility;
using System.Data;
using System.Data.SqlClient;

namespace ATMDAL
{
  public  class cutdownmoneyDAL:Icutdownmoney
    {
        SqlHelper dbhelper = new SqlHelper();
        public bool cutMoney(DepositModel acount)
        {
            bool success = false;
            string sql = "select*from Accounts where Status=0 and AccountNumber= @AccountNumber";
            SqlParameter[] sp = new SqlParameter[] {
            new SqlParameter("@AccountNumber",SqlDbType.NVarChar){Value=acount.AccountNumber},
            };
            DataTable dt = dbhelper.GetDataTable(dbhelper._dbConnectionString, CommandType.Text, sql, sp);
            //存在账户
            if (dt.Rows.Count > 0)
            {
                decimal monney = Convert.ToDecimal(dt.Rows[0]["Balance"])- acount.Amount; 
                if (monney >= 0)//减除以后余额不为空
                {
                    string updateSql = "update Accounts set Balance=@Balance where AccountNumber=@AccountNumber";
                    SqlParameter[] sp1 = new SqlParameter[] {
                    new SqlParameter("@Balance",SqlDbType.Decimal){Value=monney},
                      new SqlParameter("@AccountNumber",SqlDbType.NVarChar){Value=acount.AccountNumber}
                    };
                    int rowsAffected = dbhelper.ExecuteNonQuery(dbhelper._dbConnectionString, CommandType.Text, updateSql, sp1);
                    if (rowsAffected > 0)//成功后插入交易表数据
                    {
                        string insertSql = " INSERT INTO Transactions (AccountNumber, TransactionType, Amount, Description)VALUES (@AccountNumber,@TransactionType, @Amount, @Description);";
                        SqlParameter[] sp2 = new SqlParameter[] {
                        new SqlParameter("@AccountNumber",SqlDbType.NVarChar){Value=acount.AccountNumber},
                         new SqlParameter("@TransactionType",SqlDbType.NVarChar){Value="cut"},
                          new SqlParameter("@Amount",SqlDbType.NVarChar){Value=acount.Amount},
                           new SqlParameter("@Description",SqlDbType.NVarChar){Value=acount.Description}
                    
                        };
                        int rows = dbhelper.ExecuteNonQuery(dbhelper._dbConnectionString, CommandType.Text, insertSql, sp2);
                        if (rows > 0)
                        {

                            success=true;
                        }

                    }

                }

            }
            return success;
        }

    }
}
