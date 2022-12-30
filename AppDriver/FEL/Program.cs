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
using ApppCore.DAL;
using DocumentDistanceService.BLL.Control;

namespace AppDriver.FEL
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Executing TextMiner...");
           // InMemoryDatabase db = InMemoryDatabase.GetInstance();
            //DBInMemDocumentDistanceDAO dbInMemoryStringDistanceDAO = new(db);
            //DBInMemDocumentDAO dBInMemDocumentDAO = new(db);

            //IDocumentDistanceService jaccard = new JaccardDocumentDistanceService();
            // CorpusController corpusController = new CorpusController();

            //Document doc1 = new Document("bonjour je suis fuckall");
            //Document doc2 = new Document("bonjour je suis cool");

            // corpusController.AddNewDocument(doc1.Text, dBInMemDocumentDAO);
            // corpusController.AddNewDocument(doc2.Text, dBInMemDocumentDAO);

            // corpusController.FindAllSimilarDocuments(0, jaccard.GetDistance, dBInMemDocumentDAO).ToList().ForEach(distance => Console.WriteLine(distance.ToString()));
            NGramStringDistanceService ngram = new NGramStringDistanceService();
            Console.WriteLine(ngram.GetDistance("patate", "patate"));
        }
    }
}
