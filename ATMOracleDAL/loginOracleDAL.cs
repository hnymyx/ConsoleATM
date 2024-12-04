using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IATM;
using Model;

namespace ATMOracleDAL
{
    public class loginOracleDAL:ILogin
    {
        public bool checkUserAndPwd(UsersModel login)
        {
            //操作数据库查询数据库用户表是否存在
            bool success = false;

            //从数据库查
            if (login.Username == "admin" && login.PasswordHash == "123456")
            {
                success = true;
            }
            return success;

        }
    }
}
