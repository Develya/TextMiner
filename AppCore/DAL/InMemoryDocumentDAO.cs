using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppCore.BLL.Model;

namespace AppCore.DAL
{
    public class InMemoryDocumentDAO : IDocumentDAO
    {
        InMemoryRepository repository;

        public InMemoryDocumentDAO()
        {
            this.repository = new InMemoryRepository();
        }

        public void AddDocument(String text)
        {
            this.repository
                .documents
                .Add(new BLL.Model.Document(text));
        }

        public IList<Document> FindAllDocuments()
        {
            return this.repository.documents;
        }
    }
}
