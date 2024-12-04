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
using System.Data.SqlClient;
using System.Data;
using System.Xml.Linq;

namespace ATMDAL
{
  public  class AccountDAL: IAccount
    {
        SqlHelper dbhelper = new SqlHelper();
        public bool OpenAccount(ClientsModel clients)
        {
          
            bool result = false; 
            try
            {
                SqlParameter[] sp1 = new SqlParameter[] {
            new SqlParameter("@Name",SqlDbType.NVarChar){Value=clients.Name},
              new SqlParameter("@Password",SqlDbType.NVarChar){Value=clients.Password},
               new SqlParameter("@IDNumber",SqlDbType.NVarChar){Value=clients.IDNumber},
              new SqlParameter("@PhoneNumber",SqlDbType.NVarChar){Value=clients.PhoneNumber},
                new SqlParameter("@Address",SqlDbType.NVarChar){Value=clients.Address},
                new SqlParameter("@result", SqlDbType.Int) { Direction =ParameterDirection.Output }
            };
             
                int values = dbhelper.ExecuteNonQueryProc(dbhelper._dbConnectionString, "InsertClientWithAccount", sp1);

                if (values > 0)
                {
                    result = true;
                }
            }catch(SqlException ex)
            {
                //日志 
            }
                
           return result;
        }
    
    }
}
