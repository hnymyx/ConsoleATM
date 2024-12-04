using Model;
using ATMBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleATM
{
    class savemoneyUI
    {
        public void SaveMoney()
        {
            DepositModel u = new DepositModel();
            SaveMoneyBll saveBll = new SaveMoneyBll();
            Console.WriteLine("请输入要存入的银行卡号：");
            string id = Console.ReadLine();
            u.AccountNumber= id;
            Console.WriteLine("请输入要存入的金额：");
            decimal money = Convert.ToDecimal(Console.ReadLine());
            u.Amount = money;
            Console.WriteLine("请填写备注信息：");
            u.Description = Console.ReadLine();
            bool flg = saveBll.Deposit(u);
            if (flg)
            {
                Console.WriteLine("存款成功");
                System.Threading.Thread.Sleep(2000);
                Console.Clear();
                MainUI main = new MainUI();
                main.mainui();
            }
            else
            {
                Console.WriteLine("存入失败！卡号{0}不存在！", id);
            }
        }
    }
}
