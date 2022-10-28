using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApppCore.DAL
{
    public class InMemoryDatabase
    {
        public SQLiteConnection Conn { get; set; }
        public InMemoryDatabase()
        {
            this.Conn = new SQLiteConnection("Data Source=:memory:;Version=3;New=True;");

            Conn.Open();
            SQLiteCommand cmd = Conn.CreateCommand();

            string createTable = "CREATE TABLE StringDistances (" +
                "StringDistanceID int PRIMARY KEY," +
                "LeftShingle varchar(1000) NULL," +
                "RightShingle varchar(1000) NULL," +
                "Value real NOT NULL" +
                ");";

            cmd.CommandText = createTable;
            cmd.ExecuteNonQuery();

            createTable = "CREATE TABLE DocumentDistances (" +
                "DocumentDistanceID int PRIMARY KEY," +
                "LeftDocumentID int NOT NULL," +
                "RightDocumentID int NOT NULL," +
                "Value real NOT NULL," +
                "FOREIGN KEY (LeftDocumentID) REFERENCES Documents(DocumentID)," +
                "FOREIGN KEY (RightDocumentID) REFERENCES Documents(DocumentID)" +
                ");";

            cmd.CommandText = createTable;
            cmd.ExecuteNonQuery();

            createTable = "CREATE TABLE Shingle (" +
                "ShingleID int PRIMARY KEY," +
                "DocumentID int NOT NULL," +
                "Sequence real NOT NULL," +
                "k int NOT NULL," +
                "Type varchar(15) NOT NULL," +
                "FOREIGN KEY (DocumentID) REFERENCES Documents(DocumentID)" +
                ");";

            cmd.CommandText = createTable;
            cmd.ExecuteNonQuery();

            createTable = "create table Document (" +
                "DocumentID int PRIMARY KEY," +
                "Text varchar(5000) NOT NULL" +
                ");";

            cmd.CommandText = createTable;
            cmd.ExecuteNonQuery();

            createTable = "create table DocumentShingleLink (" +
                "DocumentShingleLinkID int PRIMARY KEY" +
                "DocumentID int NOT NULL," +
                "ShingleID int NOT NULL," +
                "FOREIGN KEY (DocumentID) REFERENCES Document(DocumentsID)" +
                ");";
        }
    }
}
