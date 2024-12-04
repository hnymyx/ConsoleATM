using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Model;

namespace ConsoleATM
{
    class Program
    {
        static void Main(string[] args)
        {
            LoginUI login = new LoginUI();
            login.login();
            // LoginModel loginModel = new LoginModel();
            // loginModel.Name = "xxxx";
            // loginModel.Pwd= "password";
            //string jsonStr=JsonHelper.SerializeObject(loginModel);
            // Console.WriteLine(jsonStr);
            // string jsonString = "{\"Name\":\"zhangsan\",\"Pwd\":\"11111\"}";
            // LoginModel login =JsonHelper.DeserializeJsonToObject<LoginModel>(jsonString); 
            // Console.WriteLine("name:{0}-pwd:{1}", login.Name,login.Pwd);
            //EncryptionHelper en=new EncryptionHelper();
            //string str = "zhangsan";
            //string encry=en.EncryptString(str);
            //Console.WriteLine(encry);
            //string dec=en.DecryptString(encry);
            //Console.WriteLine("解密数据 ：{0}", dec);

        }
    }
}
