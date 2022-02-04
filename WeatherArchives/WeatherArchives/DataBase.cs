using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace WeatherArchives
{
    internal class DataBase
    {
       
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=WeatherArchivesDB;Integrated Security=True;";
        string DBquery;

        public void ModifyTables()
        {
            ClearTableDB(Values.dbo_URLs);
            ClearTableDB(Values.dbo_OwnersData);
            DBquery = $"INSERT INTO {Values.dbo_OwnersData}(FolderPath) VALUES ('{Values.completeFolderPath}')";
            DataModification(DBquery);


            foreach (var item in ForecastLists.completeURLList)
            {
                DBquery = $"INSERT INTO {Values.dbo_URLs}(URL) VALUES ('{item}')";
                DataModification(DBquery);
            }
        }
        private void DataModification(string query)
        {
            using (SqlConnection sCon = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, sCon);
                sCon.Open();
                cmd.ExecuteNonQuery();
                sCon.Close();
            }
        }
        private void ClearTableDB(string TableName)
        {
            string cleanTable = $"TRUNCATE TABLE {TableName};";
            DataModification(cleanTable);
        }
    }
}
