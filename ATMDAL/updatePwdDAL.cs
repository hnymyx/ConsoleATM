using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Model;
using IATM;
using System.Data;
using System.Data.SqlClient;
using DBUtility;

namespace ATMDAL
{
   public class updatePwdDAL:IupdatePwd
    {
        SqlHelper dbhelper = new SqlHelper();
        public bool updatePassword(ClientsModel client)
        {
            bool succes=false;
            try
            {
                string updateSql = "update Clients set Password=@Password where IDNumber=@IDNumber";
                SqlParameter[] sp = new SqlParameter[] {
            new SqlParameter("@Password",SqlDbType.NVarChar){Value=client.NewPassword},
              new SqlParameter("@IDNumber",SqlDbType.NVarChar){Value=client.IDNumber},
            };
                int rowsAffected = dbhelper.ExecuteNonQuery(dbhelper._dbConnectionString, CommandType.Text, updateSql, sp);
                if (rowsAffected > 0)
                {
                    succes = true;

                }
            }
            catch (SqlException ex) { 
            //记录日志
            }
            return succes;
           


        }
    }
}
