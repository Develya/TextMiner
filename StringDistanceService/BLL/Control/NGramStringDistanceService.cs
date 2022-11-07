using AppCore.BLL.Model;
using AppCore.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDS.BLL.Control
{
    public class NGramStringDistanceService
    {
        private IStringDistanceDAO Dao;
        public NGramStringDistanceService(IStringDistanceDAO dao)
        {
            this.Dao = dao;
        }
        public double GetDistance(string first, string second)
        {
            double distance = 0f;
            int n = 2;

            IList<Shingle> shinglesOfFirst = CharacterBasedShinglization(first, n);
            IList<Shingle> shinglesOfSecond = CharacterBasedShinglization(second, n);
            IList<Shingle> commonShingles = new List<Shingle>();

            IList<int> firstBinary = new List<int>();
            IList<int> secondBinary = new List<int>();

            foreach (Shingle shingle in shinglesOfFirst)
            {
                if (shinglesOfSecond.Contains(shingle) && !commonShingles.Contains(shingle))
                    commonShingles.Add(shingle);
            }

            foreach (Shingle shingle in shinglesOfSecond)
            {
                if (shinglesOfFirst.Contains(shingle) && !commonShingles.Contains(shingle))
                    commonShingles.Add(shingle);
            }

            foreach (Shingle shingle in commonShingles)
            {
                if (shinglesOfFirst.Contains(shingle))
                    firstBinary.Add(1);
                else
                    firstBinary.Add(0);
            }

            foreach (Shingle shingle in commonShingles)
            {
                if (shinglesOfSecond.Contains(shingle))
                    secondBinary.Add(1);
                else
                    secondBinary.Add(0);
            }

            int totalOf1s = 0;

            foreach(int number in firstBinary)
            {
                if (number == 1)
                    totalOf1s++;
            }

            foreach (int number in secondBinary)
            {
                if (number == 1)
                    totalOf1s++;
            }

            distance = (double) commonShingles.Count() * 2 - (double) totalOf1s;
            Dao.AddStringDistance(new StringDistance(first, second, distance));
            return distance;

        }

        private IList<Shingle> CharacterBasedShinglization(string word, int n)
        {
            List<char> chars = new List<char>();
            IList<Shingle> shingles = new List<Shingle>();
            chars.AddRange(word);
            // For every character in document
            for (int i = 0; i < chars.Count; i++)
            {
                String temp = "";

                int j = 0;
                // iterates k times as long as it does not exceed the length of the document
                while ((j < n) && (i + n <= chars.Count))
                {
                    temp = temp + chars[i + j];
                    j++;
                }
                // Verify that the number of characters corresponds the number of characters needed (ex: if k=2, then we need 2 characters)
                if (temp.Length == n)
                    shingles.Add(new Shingle(temp.ToUpper(), n));
            }
            return shingles;
        }
    }
}
