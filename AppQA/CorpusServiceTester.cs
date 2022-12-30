using CorpusService.BLL.Control;
using AppCore.DAL;
using AppCore.BLL.Model;
using ApppCore.DAL;
using DocumentDistanceService.BLL.Control;

namespace AppQA
{
    public class CorpusServiceTester
    {
        [Fact]
        public void TestFindAllSimilarDocuments()
        {
            // Arrange
            double threshold = 0d;
            double actual = 0;
            double expected = 0;
            
            IList<Document> docs = new List<Document>();
            Document doc1 = new Document("bonjour");
            Document doc2 = new Document("bonjoure");
            docs.Add(doc1);
            docs.Add(doc2);

            IDocumentDAO fakeDocumentDAO = Substitute.For<DBInMemDocumentDAO>();
            fakeDocumentDAO.FindAllDocuments().Returns(docs);

            IDocumentDistanceDAO documentDistanceDAO = new DBInMemDocumentDistanceeDAO(InMemoryDatabase.GetInstance());
            JaccardDocumentDistanceService algorithm = new ();
            
            CorpusController corpusController = new ();
            
            // Act
            IList<DocumentDistance> distances = corpusController.FindAllSimilarDocuments(threshold, algorithm.GetDistance, fakeDocumentDAO, documentDistanceDAO);
            actual = distances.First().SimilarityPercentage;

            // Assert
            Assert.Equal(actual, expected);

        }
    }
}

// Pourquoi ça marche pas ? :(