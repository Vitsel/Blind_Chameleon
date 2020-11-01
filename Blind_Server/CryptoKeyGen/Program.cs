using System;
using System.Data;
using System.Security.Cryptography;
using MySql.Data.MySqlClient;

namespace CryptoKeyGen
{
    class Program
    {
        const string ServerIP = "54.84.228.2";
        static void Main(string[] args)
        {
            RijndaelManaged aes = new RijndaelManaged()
            {
                KeySize = 256,
                Mode = CipherMode.CBC,
                Padding = PaddingMode.PKCS7
            };
            aes.GenerateKey();
            aes.GenerateIV();

            MySqlConnection connection = new MySqlConnection("Server = " + ServerIP + "; Port = 3306; Database = document_center; Uid = root; Pwd = kit2020");
            try
            {
                connection.Open();
                string command = "SELECT MAX(expire_date) FROM crypto_key;";
                MySqlDataAdapter adapter = new MySqlDataAdapter(command, connection);
                DataSet data = new DataSet();
                adapter.Fill(data);

                if (data.Tables[0].Rows.Count != 1)
                    return;

                string tmp = data.Tables[0].Rows[0]["MAX(expire_date)"].ToString();
                DateTime date = new DateTime();
                if (tmp == string.Empty)
                    date = DateTime.Now;
                else
                    date = DateTime.Parse(tmp);
                string apply_date = date.ToString("yyyy-MM-dd");
                date = date.AddYears(1);
                string expire_date = date.ToString("yyyy-MM-dd");

                command = "INSERT INTO crypto_key VALUES( @key, @iv, '" + apply_date + "', '" + expire_date + "', 30);";
                MySqlCommand commander = new MySqlCommand(command, connection);
                commander.Parameters.AddWithValue("key", aes.Key);
                commander.Parameters.AddWithValue("iv", aes.IV);
                if (commander.ExecuteNonQuery() != 1)
                    return;
            }
            catch (Exception ex)
            { };
            if (connection.State != ConnectionState.Closed)
                connection.Close();
        }
    }
}
