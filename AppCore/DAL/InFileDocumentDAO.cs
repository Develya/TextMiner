using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppCore.BLL.Model;
using CorpusService.DAL;

namespace AppCore.DAL
{
    public class InFileDocumentDAO : IDocumentDAO
    {
        InFileRepository repository;

        public InFileDocumentDAO()
        {
            this.repository = new InFileRepository();
        }

        // Adds new line to CSV datastore
        public void AddDocument(String text)
        {
            File.AppendAllText(repository.FilePath, Environment.NewLine + text);
        }

        public IList<Document> FindAllDocuments()
        {
            return this.repository.documents;
        }
    }
}
