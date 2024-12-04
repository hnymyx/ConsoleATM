using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATMOracleDAL;
using IATM;
using ATMDAL;

namespace ConsoleFactory
{
    public class IoginFactory
    {
        public ILogin checkUserAndPwd()
        {
            string database = "sql";
            ILogin login = null;
            switch (database)
            {
                case "sql":
                    login = new loginDAL();
                    return login;
                case "oracel":
                    login = new loginOracleDAL();
                    return login;
                default:
                    throw new ArgumentException("unknow type!");

            }

        }
    }
}
