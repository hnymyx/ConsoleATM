using ATMBLL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleATM
{
    class SeeMoneyUI
    {
        public void see()
        {
           
            Console.WriteLine("请输入要查看的银行卡号:");
            string cardid = Console.ReadLine();
            seemoneyBll see = new seemoneyBll();
            string money = see.see(cardid);
            if (Convert.ToDecimal(money) > 0)
            {
                Console.WriteLine("银行卡号为{1}的余额为：{0}。", money, cardid);
                System.Threading.Thread.Sleep(2000);
                Console.Clear();
                MainUI main = new MainUI();
                main.mainui();
            }
            else
            {
                Console.WriteLine("卡号不存在或密码错误！");
                System.Threading.Thread.Sleep(2000);
                Console.Clear();
                MainUI main = new MainUI();
                main.mainui();
            }
        }
    }
}
