using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATMDAL;
using ATMOracleDAL;
using IATM;

namespace ConsoleFactory
{
    public class ClientsFactory
    {
        public IupdatePwd updatePassword()
        {
            string database = "sql";
            IupdatePwd client = null;
            switch (database)
            {
                case "sql":
                    client = new updatePwdDAL();
                    return client;
                case "oracel":
                    client = new updatePwdDAL();
                    return client;
                default:
                    throw new ArgumentException("unknow type!");

            }

        }
        public IAccount OpenAccount() {
            string database = "sql";
            IAccount account = null;
            switch (database)
            {
                case "sql":
                    account = new AccountDAL();
                    return account;
                case "oracel":
                    account = new AccountDAL();
                    return account;
                default:
                    throw new ArgumentException("unknow type!");

            }
        }
        public Isavemoney Deposit()
        {
            string database = "sql";
            Isavemoney deposit = null;
            switch (database)
            {
                case "sql":
                    deposit = new savemoneyDAL();
                    return deposit;
                case "oracel":
                    deposit = new savemoneyDAL();
                    return deposit;
                default:
                    throw new ArgumentException("unknow type!");

            }
        }
        public Icutdownmoney cutMoney()
        {
            string database = "sql";
            Icutdownmoney ct = null;
            switch (database)
            {
                case "sql":
                    ct = new cutdownmoneyDAL();
                    return ct; 
                case "oracel":
                    ct = new cutdownmoneyDAL();
                    return ct;
                default:
                    throw new ArgumentException("unknow type!");

            }
        }
        public Iseemoney SeeMoney()
        {
            string database = "sql";
            Iseemoney ct = null;
            switch (database)
            {
                case "sql":
                    ct = new seemoneyDAL();
                    return ct;
                case "oracel":
                    ct = new seemoneyDAL();
                    return ct;
                default:
                    throw new ArgumentException("unknow type!");

            }
        }


    }
}
