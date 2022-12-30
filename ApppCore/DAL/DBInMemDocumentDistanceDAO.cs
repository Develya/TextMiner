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
    public class DBInMemDocumentDistanceeDAO : IDocumentDistanceDAO
    {

        // For SQLite

        private InMemoryDatabase DB;
        private SQLiteCommand cmd = null;

        public DBInMemDocumentDistanceeDAO(InMemoryDatabase db)
        {
            this.DB = db;
        }

        public DBInMemDocumentDistanceeDAO() { }

        public void AddDocumentDistance(DocumentDistance documentDistance)
        {
            string insert = "INSERT INTO DocumentDistances(DocumentDistanceID, LeftDocumentID, RightDocumentID, Value) VALUES (?, ?, ?, ?)";

            this.cmd = DB.Conn.CreateCommand();

            this.cmd = DB.Conn.CreateCommand();
            this.cmd.CommandText = insert;
            this.cmd.Parameters.AddWithValue("DocumentDistanceID", null);
            this.cmd.Parameters.AddWithValue("LeftDocument", documentDistance.Left);
            this.cmd.Parameters.AddWithValue("RightDocument", documentDistance.Right);
            this.cmd.Parameters.AddWithValue("Value", documentDistance.SimilarityPercentage);
            this.cmd.ExecuteNonQuery();
        }

        public IList<DocumentDistance> FindAllDocumentDistances()
        {
            this.cmd = new SQLiteCommand("SELECT * FROM DocumentDistances", DB.Conn);

            SQLiteDataReader reader = this.cmd.ExecuteReader();

            IList<DocumentDistance> documentDistances = new List<DocumentDistance>();
            while (reader.Read())
            {
                // Retrieve left document text from db
                this.cmd = new SQLiteCommand($"SELECT 1 FROM Document WHERE DocumentID = {reader["RightDocument"]}", DB.Conn);
                SQLiteDataReader reader2 = this.cmd.ExecuteReader();
                reader2.Read();
                String leftDocumentText = reader2["Text"].ToString();

                // Retrieve right document text from db
                this.cmd = new SQLiteCommand($"SELECT 1 FROM Document WHERE DocumentID = {reader["RightDocument"]}", DB.Conn);
                reader2 = this.cmd.ExecuteReader();
                reader2.Read();
                String rightDocumentText = reader2["Text"].ToString();

                documentDistances.Add(new DocumentDistance(new Document(leftDocumentText), new Document(rightDocumentText), Double.Parse(reader["Value"].ToString())));
            }

            return documentDistances;
        }
    }
}
