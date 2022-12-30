using AppCore.BLL.Model;
using AppCore.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApppCore.DAL
{
    public class InMemoryDatabase
    {
        // SQLite in memory database

        public SQLiteConnection Conn { get; set; }
        private SQLiteCommand cmd = null;
        private static InMemoryDatabase instance = null;
        private IDocumentDAO documentDAO;

        private InMemoryDatabase() { this.Initialize(); }

        public static InMemoryDatabase GetInstance()
        {
            if (InMemoryDatabase.instance == null) InMemoryDatabase.instance = new InMemoryDatabase();
            return InMemoryDatabase.instance;
        }

        private void Initialize()
        {
            // Initialize database

            this.documentDAO = new DBInMemDocumentDAO(this);

            this.Conn = new SQLiteConnection("Data Source=:memory:;Version=3;New=True;");

            Conn.Open();
            this.cmd = Conn.CreateCommand();

            string createTable = "CREATE TABLE StringDistances (" +
                "StringDistanceID int PRIMARY KEY," +
                "LeftShingle varchar(1000) NULL," +
                "RightShingle varchar(1000) NULL," +
                "Value real NOT NULL" +
                ");";

            this.cmd.CommandText = createTable;
            this.cmd.ExecuteNonQuery();

            createTable = "CREATE TABLE DocumentDistances (" +
                "DocumentDistanceID int PRIMARY KEY," +
                "LeftDocumentID int NOT NULL," +
                "RightDocumentID int NOT NULL," +
                "Value real NOT NULL," +
                "FOREIGN KEY (LeftDocumentID) REFERENCES Documents(DocumentID)," +
                "FOREIGN KEY (RightDocumentID) REFERENCES Documents(DocumentID)" +
                ");";

            this.cmd.CommandText = createTable;
            this.cmd.ExecuteNonQuery();

            createTable = "CREATE TABLE Shingle (" +
                "ShingleID int PRIMARY KEY," +
                "DocumentID int NOT NULL," +
                "Sequence real NOT NULL," +
                "k int NOT NULL," +
                "Type varchar(15) NOT NULL," +
                "FOREIGN KEY (DocumentID) REFERENCES Documents(DocumentID)" +
                ");";

            this.cmd.CommandText = createTable;
            this.cmd.ExecuteNonQuery();

            createTable = "create table Document (" +
                "DocumentID int PRIMARY KEY," +
                "Text varchar(5000) NOT NULL" +
                ");";

            this.cmd.CommandText = createTable;
            this.cmd.ExecuteNonQuery();

            documentDAO.AddDocument(new Document("heh une bonne note svp ?"));
            documentDAO.AddDocument(new Document("heh une très bonne note svp ?"));
        }
    }
}
