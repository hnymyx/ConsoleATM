using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
   
  public  class AccountModel
    {
        public int AccountNumber { get; set; }
        public string ClientName { get; set; }
        public string Password { get; set; }
        public string NewPassword { get; set; }
        public double Balance { get; set; }
        public string IdNumber { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public int State { get; set; }
     
    }
    public class DepositModel
    {
        public string AccountNumber { get; set; }
        public decimal Amount { get; set; }
        public string Description  { get; set; }
    

    }
}
