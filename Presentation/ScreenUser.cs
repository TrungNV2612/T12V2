using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T12V2.DTO;

namespace T12V2.Presentation
{
    internal class ScreenUser : Screen
    {
        public int Id { get; set; }
        public ScreenUser()
        {
        }
        public void PrintUserScreen()
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
                Console.WriteLine("\t2.Update Password");
                Console.WriteLine("\t3.Logout");
                Console.WriteLine("\t4.Exit");
                Console.Write("Select (1-4): ");
                selected = Convert.ToInt16(Console.ReadLine());

                switch (selected)
                {
                    case 1:
                        Console.Clear();
                        PrintFindScreen();
                        break;
                    case 2:
                        Console.Clear();
                        PrintUpdateScreen();
                        break;
                    case 3:
                        Console.Clear();
                        PrintLoginScreen();
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine("------------BACK----------");
                        break;
                    default:
                        Console.WriteLine("Invalid");
                        break;
                }
            } while (selected != 4);
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
                        //PrintLoginScreen();
                        break;
                    case 5:
                        Console.Clear();
                        Console.WriteLine("--BACK--");
                        break;
                    default:
                        Console.WriteLine("Invalid");
                        break;
                }
            } while (selected != 5);
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


        private void DisplayUsers(List<User> users)
        {
            foreach (User user in users)
            {
                Console.WriteLine(user);
            }
        }

        private void PrintUpdateScreen()
        {
            User? userUpdate = userManager.FindId(Id);
            Console.WriteLine(" Enter new password to update: ");
            string newPass = Console.ReadLine();
            userManager.Update(userUpdate, newPass);
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

    }
}
