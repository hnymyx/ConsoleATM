using ATMDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using ConsoleFactory;
using IATM;

namespace ATMBLL
{
   public class loginBLL
    {
       loginDAL logindal = new loginDAL();
       public bool checkUserAndPwd(UsersModel user) {

            IoginFactory factory = new IoginFactory();
            ILogin login = factory.checkUserAndPwd();
             bool flag=login.checkUserAndPwd(user);
             return flag;
       }
    }
}
