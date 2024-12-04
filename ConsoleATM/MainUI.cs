using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleATM
{
   public  class MainUI
    {
       public void mainui()
       {
           int w = Console.WindowWidth / 3;

           Console.SetCursorPosition(w, 2);
           Console.WriteLine("欢迎进入银行柜员机管理系统！");



           Console.SetCursorPosition(w / 3, 7);
           Console.WriteLine("0:退出");

           Console.SetCursorPosition(w, 7);
           Console.WriteLine("1:修改密码");

           Console.SetCursorPosition(w * 2, 7);
           Console.WriteLine("2:开户");

           Console.SetCursorPosition(w / 3, 9);
           Console.WriteLine("3:存款");

           Console.SetCursorPosition(w, 9);
           Console.WriteLine("4:取款");

           Console.SetCursorPosition(w * 2, 9);
           Console.WriteLine("5:查询");

           Console.SetCursorPosition(w / 3, 11);
           Console.WriteLine("6:销户");
           Console.SetCursorPosition(w, 11);
           Console.WriteLine("7:挂失");
           Console.SetCursorPosition(w * 2, 11);
           Console.WriteLine("8:冻结");
           Console.SetCursorPosition(w / 3, 13);
           Console.WriteLine("9:转账");
           Console.SetCursorPosition(w, 13);
           Console.WriteLine("10:解冻");
           Console.SetCursorPosition(w * 2, 13);
           Console.WriteLine("11:解挂");


           Console.SetCursorPosition(w / 3, 17);

           Console.WriteLine("请选择操作：");
           Console.SetCursorPosition(w, 17);

           int i = Convert.ToInt32(Console.ReadLine());

           //设 state i=0表示正常 i=1冻结 i=2 挂失 i=3 销户
           switch (i)
           { 
                   //退出
               case 0:
                   Environment.Exit(0);
                   break;
                 //修改密码
               case 1:
                   UpdatePasswordUI up = new UpdatePasswordUI();
                   up.UpdatePassword();
                   break;
                 //开户
               case 2:
                   OpenAccount account = new OpenAccount();
                   account.adduser();
                   break;
                   //存款
               case 3:
                    savemoneyUI save = new savemoneyUI();
                    save.SaveMoney();
                   break;
                   //取款
               case 4:
                   cutdownmoneyUI cut = new cutdownmoneyUI();
                   cut.CutMoney();
                   break;
                   //查询
               case 5:
                   SeeMoneyUI see = new SeeMoneyUI();
                   see.see();
                   break;
                   //销户
               case 6:
                   Console.WriteLine(i);
                   break;
                   //挂失
               case 7:
                   Console.WriteLine(i);
                   break;
                    //冻结
               case 8:
                   Console.WriteLine(i);
                   break;
                   //转账
               case 9:
                   Console.WriteLine(i);
                   break;
                   //解冻
               case 10:
                   Console.WriteLine(i);
                   break;
                   //解挂
               case 11:
                   Console.WriteLine(i);
                   break;
               default:
                   Console.WriteLine("输入有误,请重新输入！");
                   break;
           }
           



       }
    }
}
