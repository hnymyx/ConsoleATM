using ATMBLL;
using Common;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleATM
{
    class UpdatePasswordUI
    {

          public void UpdatePassword()
        {
            EncryptionHelper EncryptionHelper = new EncryptionHelper();
            ClientsModel client = new ClientsModel();
            Console.WriteLine("请输入身份证号：");

            client.IDNumber =Console.ReadLine();

             Console.WriteLine("请输入原始密码：");

            client.Password  = Console.ReadLine();

             Console.WriteLine("请输入修改过后的密码");
           
            client.NewPassword = Console.ReadLine();
           
            UpdatePasswordBll updatePwd = new UpdatePasswordBll();
            bool flag= updatePwd.updatePassword(client);
            if (flag)
            {
                Console.WriteLine("更新密码成功！");
                System.Threading.Thread.Sleep(2000);
                Console.Clear();
                MainUI main = new MainUI();
                main.mainui();
            }
            else
            {
                Console.WriteLine("更新密码错误！");
                System.Threading.Thread.Sleep(2000);
                Console.Clear();
                MainUI main = new MainUI();
                main.mainui();
            }
        }
       
    }
}
