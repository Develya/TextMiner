using AppCore.BLL.Model;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCore.DAL
{
    public class DBInMemDocumentDAO : IDocumentDAO
    {
        private SQLiteConnection Conn;
        public DBInMemDocumentDAO()
        {
            this.Conn = new SQLiteConnection("Data Source=:memory:;Version=3;New=True;");
        }

        public void AddDocument(String text)
        {
            Conn.Open();

            SQLiteCommand cmd = new SQLiteCommand(
                "create table Documents (" + 
                "ID int primary key not null," +
                "Text varchar(1000) not null",
                Conn
                );

            cmd.ExecuteNonQuery();

            string insert = "insert into Documents(ID, Text) VALUES (?, ?)";

            cmd = Conn.CreateCommand();
            cmd.CommandText = insert;
            cmd.Parameters.AddWithValue("ID", null);
            cmd.Parameters.AddWithValue("Text", text);
            cmd.ExecuteNonQuery();

            Conn.Close();
        }
        public IList<Document> FindAllDocuments()
        {
            this.Conn.Open();

            SQLiteCommand cmd = new SQLiteCommand("select * from Documents;");

            SQLiteDataReader reader = cmd.ExecuteReader();

            IList<Document> documents = new List<Document>();
            while(reader.Read())
            {
                documents.Add(new Document(reader["Text"].ToString()));
            }

            return documents;
        }
    }
}
