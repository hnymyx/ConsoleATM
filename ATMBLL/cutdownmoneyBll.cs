using ConsoleFactory;
using IATM;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMBLL
{
   public class cutdownmoneyBll
    {
        public bool cutMoney(DepositModel account)
        {
            ClientsFactory factory = new ClientsFactory();
            Icutdownmoney client = factory.cutMoney();
            bool flag = client.cutMoney(account);
            return flag;
         
        }
    }
}
