using AppCore.BLL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCore.DAL
{
    public class InMemoryRepository
    {
        public IList<Document> documents;

        public InMemoryRepository()
        {
            this.documents = new List<Document>();
            this.documents.Add(new Document(" I like the potatoes. "));
            this.documents.Add(new Document(" I like the towers! "));
        }
    }
}
