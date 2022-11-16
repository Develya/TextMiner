using AppCore.BLL.Model;
using AppCore.DAL;
using StringDistanceService.BLL.Control;
using CorpusService.BLL.Control;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Document = AppCore.BLL.Model.Document;
using SDS.BLL.Control;
using ApppCore.DAL;
using DocumentDistanceService.BLL.Control;

namespace AppDriver.FEL
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Executing TextMiner...");
            InMemoryDatabase db = new InMemoryDatabase();
            DBInMemStringDistanceDAO dbInMemoryStringDistanceDAO = new(db);
            DBInMemDocumentDAO dBInMemDocumentDAO = new(db);

            IDocumentDistanceService jaccard = new JaccardDocumentDistanceService();
            IStringDistanceService hamming = new HammingStringDistanceService();
            // CorpusController corpusController = new CorpusController();

            Document doc1 = new Document("hello i LOVE");
            Document doc2 = new Document("hello i HATE");

            // corpusController.AddNewDocument(doc1.Text, dBInMemDocumentDAO);
            // corpusController.AddNewDocument(doc2.Text, dBInMemDocumentDAO);

            // corpusController.FindAllSimilarDocuments(0, jaccard.GetDistance, dBInMemDocumentDAO).ToList().ForEach(distance => Console.WriteLine(distance.ToString()));

            Console.WriteLine(jaccard.GetDistance(doc1, doc2));
            Console.WriteLine(hamming.GetDistance("hey", "ooo"));
        }
    }
}
