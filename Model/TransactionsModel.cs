using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class TransactionsModel
    {
        public int TransactionID { get; set; }
        public int AccountID { get; set; }
        public int AccountNumber { get; set; }
        
        public string TransactionType { get; set; }
        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Description { get; set; }
      
     
    }
}
