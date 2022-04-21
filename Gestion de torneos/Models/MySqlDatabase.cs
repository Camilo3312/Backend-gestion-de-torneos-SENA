using MySql.Data.MySqlClient;
using Nancy.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace work4hours_modules_backend.Models
{
    public class MySqlDatabase
    {
        public MySqlConnection connection;

        public MySqlDatabase()
        {
            connection = new MySqlConnection("datasource=by0bnxgyq7rt95lympsw-mysql.services.clever-cloud.com; port=3306; username=uh7xuem2hmsgrrzi; password=gKmkErl1gpvlz7teISDL;database=by0bnxgyq7rt95lympsw");
        }
        public string executeSql(string sql)
        {
            string result = "";
            try
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand(sql, connection);
                int rows = cmd.ExecuteNonQuery();

                if (rows > -1)
                {
                    result = "Correct";
                }
                else
                {
                    result = "Incorrect";
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                result = ex.Message;

            }
            return result;
        }

        public string ConvertDataTabletoString(string sql)
        {
            DataTable dt = new DataTable();
            using (connection)
            {
                using (MySqlCommand cmd = new MySqlCommand(sql, connection))
                {
                    connection.Open();
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    adapter.Fill(dt);
                    JavaScriptSerializer serializer = new JavaScriptSerializer();
                    List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
                    Dictionary<string, object> row;
                    foreach (DataRow dr in dt.Rows)
                    {
                        row = new Dictionary<string, object>();
                        foreach (DataColumn col in dt.Columns)
                        {
                            row.Add(col.ColumnName, dr[col]);
                        }
                        rows.Add(row);
                    }
                    return serializer.Serialize(rows);
                }
            }
        }
    }
}
