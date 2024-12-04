using ATMDAL;
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
   public class SaveMoneyBll
    {
        public bool Deposit(DepositModel entity)
        {
            ClientsFactory factory = new ClientsFactory();
            Isavemoney client = factory.Deposit();
            bool flag = client.Deposit(entity);
            return flag;
          
        }
    }
}
