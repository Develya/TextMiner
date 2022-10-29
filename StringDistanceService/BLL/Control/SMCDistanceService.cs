using AppCore.DAL;
using AppCore.BLL.Model;
using StringDistanceService.BLL.Control;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDS.BLL.Control
{
    public class SMCDistanceService : IDistanceService
    {
        private IStringDistanceDAO Dao;
        public SMCDistanceService(IStringDistanceDAO dao)
        {
            this.Dao = dao;
        }

        public double GetDistance(string first, string second)
        {
            double distance = 0.0;
            IList<char> allLetters = new List<char>();

            foreach (char c in first.ToUpper())
            {
                if (!allLetters.Contains(c))
                    allLetters.Add(c);
            }

            foreach (char c in second.ToUpper())
            {
                if (!allLetters.Contains(c))
                    allLetters.Add(c);
            }

            var allLettersAlphabetic = allLetters.OrderBy(letter => letter);

            IList<int> firstBinary = new List<int>();
            IList<int> secondBinary = new List<int>();

            foreach (char c in allLettersAlphabetic)
            {
                if (first.ToUpper().Contains(c))
                    firstBinary.Add(1);
                else
                    firstBinary.Add(0);
            }

            foreach (char c in allLettersAlphabetic)
            {
                if (second.ToUpper().Contains(c))
                    secondBinary.Add(1);
                else
                    secondBinary.Add(0);
            }

            int compteur = 0;
            int m00orm11 = 0;
            int m01 = 0;
            int m10 = 0;

            while (compteur < firstBinary.Count() && compteur < secondBinary.Count())
            {
                if (firstBinary[compteur] == secondBinary[compteur])
                    m00orm11++;

                if (firstBinary[compteur] == 0 && secondBinary[compteur] == 1)
                    m01++;

                if (firstBinary[compteur] == 1 && secondBinary[compteur] == 0)
                    m10++;

                compteur++;
            }

            distance = (double) m00orm11 / (double) (m00orm11 + m01 + m10);
            Dao.AddStringDistance(new StringDistance(first, second, distance));
            return distance;
        }
    }
}
