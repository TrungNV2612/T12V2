using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T12V2.DTO;

namespace T12V2.Presentation
{
    internal class ScreenManager : Screen
    {
        public ScreenManager()
        {

        }
        public void PrintManagerScreen()
        {
            int selected = 0;
            do
            {
                Console.WriteLine("***USER MANAGER***");
                Console.WriteLine("\t1.Manage User");
                Console.WriteLine("\t2.Manage Device");
                Console.WriteLine("\t3.Logout");
                Console.WriteLine("\t4.Exit");
                Console.Write("Select (1-4): ");
                selected = Convert.ToInt16(Console.ReadLine());
                switch (selected)
                {
                    case 1:
                        Console.Clear();
                        PrintUserManagerScreen();
                        break;
                    case 2:
                        Console.Clear();
                        PrintDeviceManagerScreen();
                        break;
                    case 3:
                        Console.Clear();
                        PrintLoginScreen();
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine("------------END----------");
                        break;
                    default:
                        Console.WriteLine("Invalid");
                        break;
                }
            } while (selected != 4);
        }


        public void PrintUserManagerScreen()
        {
            int selected = 0;

            do
            {
                Console.WriteLine("***USER MANAGER***");
                Console.WriteLine("\t1.Search User by Name or ID");
                Console.WriteLine("\t2.Add New User");
                Console.WriteLine("\t3.Update User");
                Console.WriteLine("\t4.Remove User");
                Console.WriteLine("\t5.Logout");
                Console.WriteLine("\t6.Exit");
                Console.Write("Select (1-6): ");
                selected = Convert.ToInt16(Console.ReadLine());

                switch (selected)
                {
                    case 1:
                        Console.Clear();
                        PrintFindScreen();
                        break;
                    case 2:
                        Console.Clear();
                        PrintAddScreen();
                        break;
                    case 3:
                        Console.Clear();
                        PrintUpdateScreen();
                        break;
                    case 4:
                        Console.Clear();
                        PrintDeleteScreen();
                        break;
                    case 5:
                        Console.Clear();
                        PrintLoginScreen();
                        break;
                    case 6:
                        Console.Clear();
                        Console.WriteLine("------------BACK----------");
                        break;
                    default:
                        Console.WriteLine("Invalid");
                        break;
                }
            } while (selected != 6);
        }
        public void PrintDeviceManagerScreen()
        {
            int selected = 0;
            do
            {
                Console.WriteLine("***Device MANAGER***");
                Console.WriteLine("\t1.Search Device by Name or ID");
                Console.WriteLine("\t2.Add New Device");
                Console.WriteLine("\t3.Update Device");
                Console.WriteLine("\t4.Remove Device");
                Console.WriteLine("\t5.Logout");
                Console.WriteLine("\t6.Exit");
                Console.Write("Select (1-6): ");
                selected = Convert.ToInt16(Console.ReadLine());
                switch (selected)
                {
                    case 1:
                        Console.Clear();
                        PrintDeviceFindScreen();
                        break;
                    case 2:
                        Console.Clear();
                        PrintDeviceAddScreen();
                        break;
                    case 3:
                        Console.Clear();
                        PrintDeviceUpdateScreen();
                        break;
                    case 4:
                        Console.Clear();
                        PrintDeviceDeleteScreen();
                        break;
                    case 5:
                        Console.Clear();
                        PrintLoginScreen();
                        break;
                    case 6:
                        Console.Clear();
                        Console.WriteLine("------------BACK----------");
                        break;
                    default:
                        Console.WriteLine("Invalid");
                        break;
                }
            } while (selected != 6);
        }


        private void PrintFindScreen()
        {

            Console.WriteLine("***USER SEARCHING***");
            Console.Write("enter Id or name/email: ");
            string key = Console.ReadLine();

            List<User> users = userManager.Find(key);
            if (users.Count > 0)
            {
                DisplayUsers(users);
            }
            else
            {
                Console.WriteLine("Data not found!");
            }
        }
        private void PrintAddScreen()
        {
            Console.Write("Userame: ");
            string username = Console.ReadLine();
            Console.Write("Fullname: ");
            string fullname = Console.ReadLine();
            Console.Write("Is Manger y/n:");
            UserRole role = UserRole.USER;
            if (Console.ReadLine().ToUpper() == "Y")
            {
                role = UserRole.MANAGER;
            }
            Console.Write("Password:");
            string password = Console.ReadLine();
            userManager.AddNew(new User(0, username, fullname, password, role));
        }

        private void DisplayUsers(List<User> users)
        {
            foreach (User user in users)
            {
                Console.WriteLine(user);
            }
        }

        private void PrintUpdateScreen()
        {
            Console.WriteLine(" Enter ID to update");
            int id = Convert.ToInt32(Console.ReadLine());
            User? userUpdate = userManager.FindId(id);
            Console.WriteLine(" Enter field to update: username, fullname or password");
            string field = Console.ReadLine();
            Console.WriteLine(" Enter new string to update: ");
            string newString = Console.ReadLine();
            userManager.Update(userUpdate, field, newString);
        }



        private void PrintDeleteScreen()
        {
            Console.WriteLine(" Enter ID to delete");
            int id = Convert.ToInt32(Console.ReadLine());
            User? userDelete = userManager.FindId(id);
            userManager.Delete(userDelete);
        }


        /// Manage Device
        private void PrintDeviceFindScreen()
        {
            Console.WriteLine("***Device SEARCHING***");
            Console.Write("enter Id or name: ");
            string key = Console.ReadLine();
            List<Device> devs = deviceManager.Find(key);
            if (devs.Count > 0)
            {
                DisplayDevices(devs);
            }
            else
            {
                Console.WriteLine("Data not found!");
            }
        }
        private void DisplayDevices(List<Device> devices)
        {
            foreach (Device dev in devices)
            {
                Console.WriteLine(dev);
            }
        }
        private void PrintDeviceAddScreen()
        {
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Quantity: ");
            int quantity = Convert.ToInt16(Console.ReadLine());
            deviceManager.AddNew(new Device(0, name, quantity));
        }

        private void PrintDeviceUpdateScreen()
        {
            Console.WriteLine(" Enter ID to update");
            int id = Convert.ToInt32(Console.ReadLine());
            Device? deviceUpdate = deviceManager.FindId(id);
            Console.WriteLine(" Enter field to update: name or quantity");
            string field = Console.ReadLine();
            Console.WriteLine(" Enter new value to update: ");
            //string newValue = Console.ReadLine();
            if (field == "quantity")
            {
                int newValue = Convert.ToInt16(Console.ReadLine());
                deviceManager.Update(deviceUpdate, field, newValue);
            }
            else if (field == "name")
            {
                string newValue = Console.ReadLine();
                deviceManager.Update(deviceUpdate, field, newValue);
            }

        }
        private void PrintDeviceDeleteScreen()
        {
            Console.WriteLine(" Enter ID to delete");
            int id = Convert.ToInt32(Console.ReadLine());
            deviceManager.Delete(id);
        }
    }
}
