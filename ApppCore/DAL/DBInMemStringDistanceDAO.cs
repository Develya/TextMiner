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
    public class DBInMemDocumentDistanceDAO : IStringDistanceDAO
    {

        // For SQLite

        private InMemoryDatabase DB;
        private SQLiteCommand cmd = null;

        public DBInMemDocumentDistanceDAO(InMemoryDatabase db)
        {
            this.DB = db;
        }

        public void AddStringDistance(StringDistance stringDistance)
        {
            string insert = "INSERT INTO StringDistances(StringDistanceID, LeftShingle, RightShingle, Value) VALUES (?, ?, ?, ?)";

            this.cmd = DB.Conn.CreateCommand();

            this.cmd = DB.Conn.CreateCommand();
            this.cmd.CommandText = insert;
            this.cmd.Parameters.AddWithValue("StringDistanceID", null);
            this.cmd.Parameters.AddWithValue("LeftShingle", stringDistance.Left);
            this.cmd.Parameters.AddWithValue("RightShingle", stringDistance.Right);
            this.cmd.Parameters.AddWithValue("Value", stringDistance.Value);
            this.cmd.ExecuteNonQuery();
        }

        public IList<StringDistance> FindAllStringDistances()
        {
            this.cmd = new SQLiteCommand("SELECT * FROM StringDistances", DB.Conn);

            SQLiteDataReader reader = this.cmd.ExecuteReader();

            IList<StringDistance> stringDistances = new List<StringDistance>();
            while (reader.Read())
            {
                stringDistances.Add(new StringDistance(reader["LeftShingle"].ToString(), reader["RightShingle"].ToString(), Double.Parse(reader["Value"].ToString())));
            }

            return stringDistances;
        }
    }
}
