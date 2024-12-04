using Model;
using ATMDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleFactory;
using IATM;

namespace ATMBLL
{
   public class seemoneyBll
    {
        public string see(string card)
        {
            ClientsFactory factory = new ClientsFactory();
            Iseemoney client = factory.SeeMoney();
            string  result = client.see(card);
            return result;

        }
    }
}
