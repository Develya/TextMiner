using AppCore.BLL.Model;
using ApppCore.DAL;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace AppCore.DAL
{
    public class DBInMemStringDistanceDAO : IStringDistanceDAO
    {
        private InMemoryDatabase DB;
        public DBInMemStringDistanceDAO(InMemoryDatabase db)
        {
            this.DB = db;
        }

        public void AddStringDistance(StringDistance stringDistance)
        {
            string insert = "INSERT INTO StringDistances(StringDistanceID, LeftShingle, RightShingle, Value) VALUES (?, ?, ?, ?)";

            SQLiteCommand cmd = DB.Conn.CreateCommand();

            cmd = DB.Conn.CreateCommand();
            cmd.CommandText = insert;
            cmd.Parameters.AddWithValue("StringDistanceID", null);
            cmd.Parameters.AddWithValue("LeftShingle", stringDistance.Left);
            cmd.Parameters.AddWithValue("RightShingle", stringDistance.Right);
            cmd.Parameters.AddWithValue("Value", stringDistance.Value);
            cmd.ExecuteNonQuery();
        }
        public IList<StringDistance> FindAllStringDistances()
        {
            SQLiteCommand cmd = new SQLiteCommand("SELECT * FROM StringDistances", DB.Conn);

            SQLiteDataReader reader = cmd.ExecuteReader();

            IList<StringDistance> stringDistances = new List<StringDistance>();
            while (reader.Read())
            {
                stringDistances.Add(new StringDistance(reader["LeftShingle"].ToString(), reader["RightShingle"].ToString(), Double.Parse(reader["Value"].ToString())));
            }

            return stringDistances;
        }
    }
}
