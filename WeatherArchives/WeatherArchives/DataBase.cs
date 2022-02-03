using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace WeatherArchives
{
    internal class DataBase
    {
        string connectionString = $"Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=WeatherArchivesDB;Integrated Security=True;";
        public void Save()
        {
            string DBquery = $"INSERT INTO URLs(URL) VALUES ('whaaaaaaaat')";
            DataModification(DBquery);
        }
        private void DataModification(string DBquery)
        {
            using (SqlConnection sCon = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(DBquery,sCon);
                sCon.Open();
                cmd.ExecuteNonQuery();
                sCon.Close();
            }
        }
    }
}
