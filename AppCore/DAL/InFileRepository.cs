using AppCore.BLL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorpusService.DAL
{
    public class InFileRepository
    {
        public String FilePath = "C:\\Users\\paint\\source\\repos\\TextMiner\\AppCore\\DAL\\documents.csv";
        public IList<Document> documents;

        // Loading file data in memory
        public InFileRepository()
        {
            this.documents = new List<Document>();

            IEnumerable<String> lines = File.ReadAllLines(this.FilePath).Skip(1);
            
            foreach (String line in lines)
            {
                String[] allColumns = line.Split(";");

                this.documents.Add(new Document(allColumns[0]));
            }
        }
    }
}
