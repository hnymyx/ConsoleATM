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
   public  class AccountBll
    {
      
       public bool OpenAccount(ClientsModel user)
        {
            ClientsFactory factory = new ClientsFactory();
            IAccount client = factory.OpenAccount();
            bool flag = client.OpenAccount(user);
            return flag;
            
        }

    
    }
}
