using AppCore.BLL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentDistanceService.BLL.Control
{
    public class MinHashDocumentDistanceService : IDocumentDistanceService
    {
        public MinHashDocumentDistanceService()
        {
        }

        public double GetDistance(Document doc1, Document doc2)
        {
            double distance = 0d;
            doc1.Normalize();
            doc2.Normalize();
            doc1.Shinglize(1, "WORD");
            doc2.Shinglize(1, "WORD");
            IList<string> allWord = GetAllWord(doc1, doc2);
            IList<String> allWordAlphabetic = allWord.OrderBy(word => word).ToList();
            IList<int>[] allBinaries = Binaries(doc1, doc2, allWordAlphabetic);
            Hachage(allWordAlphabetic);
            return distance;
        }

        public IList<String> GetAllWord(Document doc1, Document doc2)
        {
            IList<String> AllWord = new List<String>();
            doc1.ToString().ToUpper().Split().ToList().ForEach(word => {
                if (!AllWord.Contains(word)) AllWord.Add(word);
            });

            doc2.ToString().ToUpper().Split().ToList().ForEach(word =>
            {
                if (!AllWord.Contains(word)) AllWord.Add(word);
            });
            return AllWord;
        }

        public IList<int>[] Binaries(Document doc1, Document doc2, IList<string> allWordAlphabetic)
        {
            IList<int> firstBinaries = new List<int>();
            IList<int> secondBinaries = new List<int>();
            int cpt = 0;
            doc1.ToString().Split().ToList().ForEach(word =>
            {
                if (word.Contains(allWordAlphabetic[cpt]))
                    firstBinaries[cpt] = 1;
                else
                    firstBinaries[cpt] = 0;
                cpt++;
            });
            cpt = 0;
            doc2.ToString().Split().ToList().ForEach(word =>
            {
                if (word.Contains(allWordAlphabetic[cpt]))
                    secondBinaries[cpt] = 1;
                else
                    secondBinaries[cpt] = 0;
                cpt++;
            });
            return new IList<int>[] { firstBinaries, secondBinaries };
        }

        public IDictionary<String, int[]> Hachage(IList<String> allWordAlphabetic)
        {
            IDictionary<String, int[]> hachage = new Dictionary<String, int[]>();
            int cpt = 0;
            int h1, h2;
            foreach (String word in allWordAlphabetic)
            {
                h1 = cpt + 1 % 7;
                h2 = 3 * cpt + 1 % 7;
                hachage.Add(word, new int[] { h1, h2 });
            }
            return hachage;
        }
    }
}

// c'est trop dur :(