using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppCore.BLL.Model;

namespace DocumentDistanceService.BLL.Control
{
    public class JaccardDocumentDistanceService : IDocumentDistanceService
    {
        public JaccardDocumentDistanceService() { }

        public double GetDistance(Document doc1, Document doc2)
        {
            doc1.Normalize();
            doc1.Shinglize(2, "WORD");
            doc2.Normalize();
            doc2.Shinglize(2, "WORD");

            IList<string> commonShingles = JaccardDocumentDistanceService.FindAllCommonShingles(doc1.Shingles, doc2.Shingles);
            HashSet<string> uniqueShingles = JaccardDocumentDistanceService.FindAllUniqueShingles(doc1.Shingles, doc2.Shingles);

            return  (double) commonShingles.Count / (double) uniqueShingles.Count;
        }

        private static IList<string> FindAllCommonShingles(IList<Shingle> doc1Shingles, IList<Shingle> doc2Shingles)
        {
            var allShingles = doc1Shingles.Concat(doc2Shingles);
            var allCommonShingles = doc1Shingles
                .Select(s1 => s1.sequence).ToList()
                .Intersect(doc2Shingles.Select(s2 => s2.sequence).ToList())
                .ToList();

            return allCommonShingles;
        }

        private static HashSet<string> FindAllUniqueShingles(IList<Shingle> doc1Shingles, IList<Shingle> doc2Shingles)
        {
            HashSet<string> uniqueShingles = new HashSet<string>();
            var allShingles = doc1Shingles.Concat(doc2Shingles);

            var allShinglesSequences = from s in allShingles
                                       select s.sequence;

            allShinglesSequences.ToList().ForEach(s => {
                if (!uniqueShingles.Contains(s))
                    uniqueShingles.Add(s);
            });
            


            return uniqueShingles;
        }
    }
}
