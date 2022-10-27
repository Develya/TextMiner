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
        private IDocumentDAO documentDAO;

        public CorpusController(IDocumentDAO documentDAO)
        {
            this.documentDAO = documentDAO;
        }

        public void AddNewDocument(int id, String text)
        {
            this.documentDAO.AddDocument(text);
        }

        public IList<Document> FindAllDocuments()
        {
            return this.documentDAO.FindAllDocuments();
        }
    }
}
