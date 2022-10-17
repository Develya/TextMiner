using AppCore.BLL.Model;
using AppCore.DAL;
using CorpusService.BLL.Control;
using StringDistanceService.BLL.Control;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Document = AppCore.BLL.Model.Document;

namespace AppDriver.FEL
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Executing TextMiner...");
            StringDistanceController stringDistanceController = new StringDistanceController();

            Console.WriteLine(stringDistanceController.CalculateLevenshteinDistance("chess", "chello"));






            /*
            IDocumentDAO inFileDocumentDAO = new InFileDocumentDAO();
            IDocumentDAO inMemoryDocumentDAO = new InMemoryDocumentDAO();

            CorpusController corpusControllerInFile = new(inFileDocumentDAO);
            CorpusController corpusControllerInMemory = new(inMemoryDocumentDAO);

            Console.WriteLine();
            Console.WriteLine("New document in file repository output to AppCore\\BLL\\Model\\text.txt");
            Console.WriteLine();

            // Testing InFileDocumentDAO
            IList<Document> documentsFile = corpusControllerInFile.FindAllDocuments();
            // Commented out to prevent flooding documents.csv
            // corpusController.AddNewDocument(" I spent a lot of time on that project! ", inFileDocumentDAO);

            // Testing InMemoryDocumentDAO
            IList<Document> documentsMemory = inMemoryDocumentDAO.FindAllDocuments();
            corpusControllerInMemory.AddNewDocument(" I spent a lot of time on that project! ");
            // If it is used in next tests, then it works perfectly.

            Console.WriteLine();
            Console.WriteLine("Normalization test output to AppCore\\BLL\\Model\\text.txt");
            Console.WriteLine();

            // Testing Normalization (output to file to showcase the removal of the whitespaces at the end of the documents)
            const string FILEPATH = "C:\\Users\\paint\\source\\repos\\TextMiner\\AppCore\\BLL\\Model\\text.txt";
            File.Delete(FILEPATH);
            foreach (Document document in documentsFile)
                File.AppendAllText(FILEPATH, Environment.NewLine + document.Normalize());

            Console.WriteLine();
            Console.WriteLine("Shingles test (word based with k=2)");

            // Testing Shingles (word based)
            foreach (Document document in documentsFile)
            {
                document.Shinglize(2, "WORD");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine(document.text);
                Console.WriteLine("===");
                foreach (Shingle shingle in document.Shingles)
                    Console.WriteLine(shingle.sequence);
            }

            Console.WriteLine();
            Console.WriteLine("Shingles test (character based with k=2)");

            // Testing Shingles (character based)
            foreach (Document document in documentsFile)
            {
                document.Shinglize(2, "CHARACTER");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine(document.text);
                Console.WriteLine("===");
                foreach (Shingle shingle in document.Shingles)
                    Console.WriteLine(shingle.sequence);
            }
            */
        }
    }
}
