using AppCore.BLL.Model;
using ApppCore.DAL;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCore.DAL
{
    // For SQLite

    public class DBInMemDocumentDAO : IDocumentDAO
    {
        private InMemoryDatabase db;
        public DBInMemDocumentDAO(InMemoryDatabase db)
        {
            this.db = db;
        }

        public DBInMemDocumentDAO() { }

        public void AddDocument(Document document)
        {
            string insert = "insert into Document(DocumentID, Text) VALUES (?, ?)";

            SQLiteCommand cmd = db.Conn.CreateCommand();
            cmd.CommandText = insert;
            cmd.Parameters.AddWithValue("DocumentID", null);
            cmd.Parameters.AddWithValue("Text", document.Text);
            cmd.ExecuteNonQuery();
        }

        public virtual IList<Document> FindAllDocuments()
        {
            SQLiteCommand cmd = new SQLiteCommand("select * from Document;", db.Conn);

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
