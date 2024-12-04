using ATMBLL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleATM
{
  public  class cutdownmoneyUI
    {
        public void CutMoney()
        {
            DepositModel u = new DepositModel();
            cutdownmoneyBll cutBll = new cutdownmoneyBll();
            Console.WriteLine("请输入要取款的银行卡号：");
            string id = Console.ReadLine();
            u.AccountNumber = id;
            Console.WriteLine("请输入要取的金额：");
            u.Amount = Convert.ToDecimal(Console.ReadLine());
            u.Description = "测试数据"+DateTime.Now.ToString();
            bool flag= cutBll.cutMoney(u);
            if (flag)
            {
                Console.WriteLine("取款成功！");
                System.Threading.Thread.Sleep(2000);
                Console.Clear();
                MainUI main = new MainUI();
                main.mainui();
            }
            else
            {
                Console.WriteLine("存入失败！");
            }
        }
    }
}
