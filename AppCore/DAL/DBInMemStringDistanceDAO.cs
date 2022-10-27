using AppCore.BLL.Model;
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
        private SQLiteConnection Conn;
        public DBInMemStringDistanceDAO()
        {
            this.Conn = new SQLiteConnection("Data Source=:memory:;Version=3;New=True;");

            Conn.Open();

            string createTable = "CREATE TABLE StringDistances (Id int PRIMARY KEY, Left varchar(1000) NOT NULL, Right varchar(1000) NOT NULL, Value real NOT NULL)";

            SQLiteCommand cmd = Conn.CreateCommand();
            cmd.CommandText = createTable;
            cmd.ExecuteNonQuery();
        }

        public void AddStringDistance(String leftKShingle, String rightKShingle, double value)
        {
            string insert = "INSERT INTO StringDistances(ID, Left, Right, Value) VALUES (?, ?, ?, ?)";

            SQLiteCommand cmd = Conn.CreateCommand();

            cmd = Conn.CreateCommand();
            cmd.CommandText = insert;
            cmd.Parameters.AddWithValue("ID", null);
            cmd.Parameters.AddWithValue("Left", leftKShingle);
            cmd.Parameters.AddWithValue("Right", rightKShingle);
            cmd.Parameters.AddWithValue("Value", value);
            cmd.ExecuteNonQuery();

            Conn.Close();
        }
        public IList<StringDistance> FindAllStringDistances()
        {
            this.Conn.Open();

            SQLiteCommand cmd = new SQLiteCommand("SELECT * FROM StringDistances", Conn);

            SQLiteDataReader reader = cmd.ExecuteReader();

            IList<StringDistance> stringDistances = new List<StringDistance>();
            while (reader.Read())
            {
                stringDistances.Add(new StringDistance(reader["Left"].ToString(), reader["Right"].ToString(), Double.Parse(reader["Value"].ToString())));
            }

            return stringDistances;
        }
    }
}
