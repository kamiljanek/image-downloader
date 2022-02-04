using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace WeatherArchives
{
    internal class DataBase
    {
        string dbo_URLs = "URLs";
        string dbo_OwnersData = "OwnersData";
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=WeatherArchivesDB;Integrated Security=True;";
        string DBquery;

        public void ModifyTables()
        {
            CleanDB(dbo_URLs);
            CleanDB(dbo_OwnersData);
            DBquery = $"INSERT INTO {dbo_OwnersData}(FolderPath) VALUES ('{Values.completeFolderPath}')";
            DataModification(DBquery);


            foreach (var item in ForecastLists.completeURLList)
            {
                DBquery = $"INSERT INTO {dbo_URLs}(URL) VALUES ('{item}')";
                DataModification(DBquery);
            }
        }
        private void DataModification(string DBquery)
        {
            using (SqlConnection sCon = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(DBquery, sCon);
                sCon.Open();
                cmd.ExecuteNonQuery();
                sCon.Close();
            }
        }
        private void CleanDB(string TableName)
        {
            string cleanTable = $"TRUNCATE TABLE {TableName};";
            DataModification(cleanTable);
        }
    }
}
