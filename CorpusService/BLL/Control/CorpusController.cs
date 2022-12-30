using AppCore.BLL.Model;
using AppCore.DAL;
using ApppCore.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorpusService.BLL.Control
{
    public class CorpusController
    {
        // Manage documents

        public delegate double DistanceAlgorithm(Document doc1, Document doc2);

        public CorpusController() { }

        public Document AddNewDocument(String text, IDocumentDAO documentDAO)
        {
            Document doc = new Document(text);
            documentDAO.AddDocument(doc);
            return doc;
        }

        public IList<Document> FindAllDocuments(IDocumentDAO documentDAO)
        {
            return documentDAO.FindAllDocuments();
        }

        public virtual IList<DocumentDistance> FindAllSimilarDocuments(double threshold, DistanceAlgorithm distance, IDocumentDAO documentDAO, IDocumentDistanceDAO documentDistanceDAO)
        {

            // Find all similar documents in the documents corpus and add all distances 

            IList<Document> documents = this.FindAllDocuments(documentDAO);
            IList<DocumentDistance> allDistances = new List<DocumentDistance>();

            documents.ToList().ForEach(document => {
                documents.ToList().ForEach(document2 => {
                    if (document.Text != document2.Text)
                    {
                        bool pairAlreadyCompared = false;
                        allDistances.ToList().ForEach(distance => { 
                            if (distance.Left.Text == document2.Text && distance.Right.Text == document.Text)
                                pairAlreadyCompared = true;
                        });
                        if (!pairAlreadyCompared)
                            allDistances.Add(new DocumentDistance(document, document2, distance(document, document2)));
                    }
                });
            });

            IList<DocumentDistance> validDocumentDistances = CorpusController.VerifyThreshold(allDistances, threshold);

            validDocumentDistances.ToList().ForEach(distance => documentDistanceDAO.AddDocumentDistance(distance));

            return validDocumentDistances;
        }

        private static IList<DocumentDistance> VerifyThreshold(IList<DocumentDistance> documentDistances, double threshold)
        {
            List<DocumentDistance> validDocumentDistances = new();

            documentDistances.ToList().ForEach(distance => {
                if (distance.SimilarityPercentage >= threshold)
                {
                    validDocumentDistances.Add(distance);
                }
            });

            return validDocumentDistances;
        }
    }
}
