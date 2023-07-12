using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T12V2.BusinessLogic;
using T12V2.DTO;

namespace T12V2.Presentation
{
    internal class Screen
    {
        public UserManager? userManager;
        public DeviceManager deviceManager;
        public ScreenManager screenManager;
        public ScreenUser screenUser;
        public int id;
        public Screen()
        {
            userManager = new UserManager();
            deviceManager = new DeviceManager();
        }

        public void PrintLoginScreen()
        {
            bool checkLogin = false;

            do
            {
                Console.WriteLine("===== USER MANAGE =====");
                Console.WriteLine("=====       LOGIN     =====");
                Console.Write("Username: ");
                string uname = Console.ReadLine();
                Console.Write("Password: ");
                string pwd = Console.ReadLine();
                // --> Check Login
                User? user = userManager.Login(uname, pwd);
                if (user == null)
                {
                    Console.WriteLine("Login fail! Wrong uname or password");
                }
                else
                {

                    userManager.CloseConn();
                    checkLogin = true;
                    Console.WriteLine("Login success!");
                    // Dieu huong
                    if (user.Role == UserRole.MANAGER)
                    {
                        screenManager = new ScreenManager();
                        screenManager.PrintManagerScreen();
                    }
                    else if (user.Role == UserRole.USER)
                    {
                        screenUser = new ScreenUser();
                        screenUser.Id = user.Id;
                        screenUser.PrintUserScreen();
                    }
                }
            } while (!checkLogin);

        }

    }
}
