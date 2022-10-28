using AppCore.BLL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCore.DAL
{
    public interface IDocumentDAO
    {
        void AddDocument(Document document);
        IList<Document> FindAllDocuments();
    }
}