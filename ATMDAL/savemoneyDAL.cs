using IATM;
using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using DBUtility;

namespace ATMDAL
{
    public class savemoneyDAL: Isavemoney
    {
        SqlHelper dbhelper = new SqlHelper();
        public bool  Deposit(DepositModel entity)
        {
            bool result = false;
            try
            {
                SqlParameter[] sp1 = new SqlParameter[] {
            new SqlParameter("@AccountNumber",SqlDbType.NVarChar){Value=entity.AccountNumber},
              new SqlParameter("@Amount",SqlDbType.Decimal){Value=entity.Amount},
               new SqlParameter("@Description",SqlDbType.NVarChar){Value=entity.Description}
           
            };
                // 添加输出参数

                // 执行存储过程并处理输出参数
               
                int values = dbhelper.ExecuteNonQueryProc(dbhelper._dbConnectionString, "Deposit", sp1);

                if (values > 0)
                {
                    result = true;
                }
            }
            catch (SqlException ex)
            {
                //日志 
            }

            return result;

        }
      
    }
}
