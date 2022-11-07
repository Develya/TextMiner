using AppCore.BLL.Model;
using AppCore.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorpusService.BLL.Control
{
    public class CorpusController
    {
        public delegate double DistanceAlgorithm(Document doc1, Document doc2);

        public void AddNewDocument(String text, IDocumentDAO documentDAO)
        {
            Document doc = new Document(text);
            documentDAO.AddDocument(doc);
        }

        public IList<Document> FindAllDocuments(IDocumentDAO documentDAO)
        {
            return documentDAO.FindAllDocuments();
        }

        public IList<DocumentDistance> FindAllSimilarDocuments(double threshold, DistanceAlgorithm distance, IDocumentDAO documentDAO)
        {
            IList<Document> documents = this.FindAllDocuments(documentDAO);
            IList<DocumentDistance> distances = new List<DocumentDistance>();

            documents.ToList().ForEach(document => {
                documents.ToList().ForEach(document2 => {
                    if (document.Text != document2.Text)
                    {
                        bool pairAlreadyCompared = false;
                        distances.ToList().ForEach(distance => { 
                            if (distance.Left.Text == document2.Text && distance.Right.Text == document.Text)
                                pairAlreadyCompared = true;
                        });
                        if (!pairAlreadyCompared)
                            distances.Add(new DocumentDistance(document, document2, distance(document, document2)));
                    }
                });
            });

            return distances;
        }
    }
}
