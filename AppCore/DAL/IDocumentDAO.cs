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
        public void AddDocument(String text);
        public IList<Document> FindAllDocuments();
    }
}