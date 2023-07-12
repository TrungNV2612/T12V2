using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T12V2.DataAccess;
using T12V2.DTO;

namespace T12V2.BusinessLogic
{
    internal class DeviceManager
    {
        DeviceDAL deviceDAL;
        public DeviceManager()
        {
            deviceDAL = new DeviceDAL();
        }

        public List<Device> Find(string key)
        {

            int id;
            bool success = int.TryParse(key, out id);
            if (success)
            {
                List<Device> devices = new List<Device>();
                Device? device = deviceDAL.SelectById(id);
                devices.Add(device);
                return devices;
            }
            else
            {
                return deviceDAL.SelectByKey(key);
            }
        }

        public int AddNew(Device device)
        {
            return deviceDAL.Insert(device);
        }

        public Device FindId(int id)
        {
            return deviceDAL.SelectById(id);
        }
        public int Update(Device device, string field, string newValue)
        {
            return deviceDAL.Update(device, field, newValue);
        }
        public int Update(Device device, string field, int newValue)
        {
            return deviceDAL.Update(device, field, newValue);
        }

        public int Delete(int id)
        {
            return deviceDAL.Delete(id);
        }

    }
}
