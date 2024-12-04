using ATMDAL;
using ConsoleFactory;
using IATM;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleFactory;
using IATM;
namespace ATMBLL
{
  public  class UpdatePasswordBll
    {
      public bool updatePassword(ClientsModel cm)
        {
            ClientsFactory factory = new ClientsFactory();
            IupdatePwd client = factory.updatePassword();
            bool flag = client.updatePassword(cm);
            return flag;
       
          
        }
    }
}
