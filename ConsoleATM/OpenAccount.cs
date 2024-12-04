using ATMBLL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleATM
{
    class OpenAccount
    {

        AccountBll accountBll = new AccountBll();
        public void adduser()
        {
            Console.Clear();
            ClientsModel account = new ClientsModel();
   
            Console.Write("请输入用户名：(1-8个字符):");
            account.Name = Console.ReadLine();

            Console.Write("请输入用户密码：(1-6个字符):");
            account.Password= Console.ReadLine();

            Console.Write("请输入用户银行卡号：");
            account.IDNumber = Console.ReadLine();

            Console.Write("请输入用户电话：");
            account.PhoneNumber = Console.ReadLine();

            Console.Write("请输入地址: ");
             account.Address = Console.ReadLine();
          
              try  
                    {
                        bool accountNumber = accountBll.OpenAccount(account);
                        Console.WriteLine("Account successfully opened.");
                        System.Threading.Thread.Sleep(2000);
                        Console.Clear();
                        MainUI main = new MainUI();
                        main.mainui();
                    }  
                    catch (Exception ex)  
                    {  
                        Console.WriteLine("Error: {ex.Message}",ex);  
                    }  
          

          
        }
    }
}
