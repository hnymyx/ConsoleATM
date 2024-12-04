using ATMBLL;
using Common;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleATM
{
    class LoginUI
    {
        loginBLL loginbll = new loginBLL();
        EncryptionHelper EncryptionHelper = new EncryptionHelper();
        int faileNum = 0;
         int succ = 0;
        public void login() {
            while (succ == 0)
            {

                int w = Console.WindowWidth / 3;
                Console.SetCursorPosition(w, 3);
                Console.WriteLine("欢迎登录银行柜员机管理系统！");
                int x = Console.WindowWidth / 4;
                int y = Console.WindowHeight / 4;
                Console.SetCursorPosition(x, y);
                Console.WriteLine("用户名：");
                Console.SetCursorPosition(x, y + 2);
                Console.WriteLine("密码：");
                Console.SetCursorPosition(x + 8, y);
                string name = Console.ReadLine();
                Console.SetCursorPosition(x + 8, y + 2);
                string pwd = Console.ReadLine();
                UsersModel model = new UsersModel();
                model.Username = name;
                model.PasswordHash = EncryptionHelper.EncryptString(name);
              bool flag=loginbll.checkUserAndPwd(model);

              if (flag)
                {
                    Console.SetCursorPosition(x, y + 4);
                    Console.Write("登录中  * ");
                    for (int i = 0; i < 3; i++)
                    {
                        System.Threading.Thread.Sleep(1000);
                        Console.Write("  * ");
                    }
                    Console.WriteLine("登录成功！ ");
                    Console.SetCursorPosition(x, y + 6);
                    Console.WriteLine("两秒后跳转至主页面！");
                    succ++;
                    System.Threading.Thread.Sleep(2000);
                    Console.Clear();
                    MainUI main = new MainUI();
                    main.mainui();
                }
                else
                {
                    faileNum++;

                    Console.SetCursorPosition(x, y + 4);
                    Console.Write("登录中  * ");
                    for (int i = 0; i < 3; i++)
                    {
                        System.Threading.Thread.Sleep(1000);
                        Console.Write("  * ");
                    }
                    Console.WriteLine("登录失败！");
                    Console.SetCursorPosition(x, y + 6);
                    Console.Clear();
                    if (faileNum == 3)
                    {
                        Environment.Exit(0);

                    }
                }
            }

        
        
        
        
        }
    }
}
