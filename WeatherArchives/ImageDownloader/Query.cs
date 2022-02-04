using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherArchives;

namespace ImageDownloader
{
    internal class Query
    {
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=WeatherArchivesDB;Integrated Security=True;";
        string DBquery;

        internal List<string> URLListGenerator()
        {
            var URLs = new List<string>();
            string query = $"SELECT {Values.dbo_URLs}";
            DataRowCollection dataRow = QueryDB(query);
            foreach (DataRow item in dataRow)
            {
                URLs.Add(item["URL"].ToString());
            }
            return URLs;
        }
        internal string FilePathGenerator()
        {
            string query = $"SELECT {Values.dbo_OwnersData}";
            DataRowCollection dataRow = QueryDB(query);

            return dataRow[0]["FolderPath"].ToString();
        }
        internal DataRowCollection QueryDB(string query)
        {
            using (SqlConnection sCon = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query);
                DataSet ds = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(ds);
                return ds.Tables[0].Rows;
            }
        }
    }
}
