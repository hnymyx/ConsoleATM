using Model;
using IATM;
using DBUtility;
using System;
using System.Data;
using System.Data.SqlClient;
namespace ATMDAL
{
    public class loginDAL:ILogin
    {
         SqlHelper sqlHelper=new SqlHelper();
        public bool checkUserAndPwd(UsersModel login)
        {
            //操作数据库查询数据库用户表是否存在
            bool flag=false;
            string sql = "select *from Users where Username=@Username and PasswordHash=@PasswordHash";
            SqlParameter[] sp = new SqlParameter[] {
            new SqlParameter("@Username",System.Data.SqlDbType.NVarChar){Value=login.Username },
              new SqlParameter("@PasswordHash",System.Data.SqlDbType.NVarChar){Value=login.PasswordHash }
            };
            try
            {
                object result = sqlHelper.ExecuteScalar(sqlHelper._dbConnectionString, CommandType.Text, sql, sp);
                if (result != DBNull.Value)
                {
                    int count = Convert.ToInt32(result);
                    if (count > 0)
                    {
                        flag = true;

                    }
                    else
                    {
                        flag = false;

                    }
                   
                }
            }
            catch (SqlException ex)
            {
                //记录日志

            }
            return flag;
          
       
          
        }
    }
}
