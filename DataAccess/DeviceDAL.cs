using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T12V2.DTO;

namespace T12V2.DataAccess
{
    internal class DeviceDAL
    {
        SqlConnection conn;
        public DeviceDAL()
        {
            conn = new DbConnector().GetConnection();
            conn.Open();
        }
        public Device? SelectById(int id)
        {
            Device device = null;
            string sql = "SELECT * FROM DEVICE WHERE id = @0";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("0", id);

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                device = new Device();
                device.Id = (int)reader["id"];
                device.Name = (string)reader["name"];
                device.Quantity = (int)reader["quantity"];
            }
            reader.Close();
            return device;
        }

        public List<Device> SelectByKey(string key)
        {
            List<Device> list = new List<Device>();
            string sql = "SELECT * FROM DEVICE WHERE name like @0";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("0", key);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Device device = new Device();
                device.Id = (int)reader["id"];
                device.Name = (string)reader["name"];
                device.Quantity = (int)reader["quantity"];
                list.Add(device);
            }
            reader.Close();
            return list;
        }

        public int Insert(Device device)
        {
            string sql = "INSERT INTO  DEVICE(name, quantity) VALUES (@0,@1)";
            SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("0", device.Name);
            cmd.Parameters.AddWithValue("1", device.Quantity);
            return cmd.ExecuteNonQuery();
        }

        public int Update(Device device, string field, string newValue)
        {
            string sql = $"UPDATE DEVICE SET {field} = @1 WHERE id=@0";
            SqlCommand command = new SqlCommand(sql, conn);
            command.Parameters.AddWithValue("@0", device.Id);
            command.Parameters.AddWithValue("@1", newValue);
            return command.ExecuteNonQuery();
        }
        public int Update(Device device, string field, int newValue)
        {
            string sql = $"UPDATE DEVICE SET {field} = @1 WHERE id=@0";
            SqlCommand command = new SqlCommand(sql, conn);
            command.Parameters.AddWithValue("@0", device.Id);
            command.Parameters.AddWithValue("@1", newValue);
            return command.ExecuteNonQuery();
        }
        public int Delete(int id)
        {
            string sql = "DELETE FROM DEVICE WHERE id=@0";
            SqlCommand command = new SqlCommand(sql, conn);
            command.Parameters.AddWithValue("@0", id);
            return command.ExecuteNonQuery();
        }
    }
}
