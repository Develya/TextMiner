using AppCore.DAL;
using AppCore.BLL.Model;
using StringDistanceService.BLL.Control;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.ExceptionServices;

namespace StringDistanceService.BLL.Control
{
    public class SMCStringDistanceService : IStringDistanceService
    {
        public SMCStringDistanceService()
        {
        }

        public double GetDistance(string first, string second)
        {
            double distance = 0.0;
            IList<char> allLetters = SMCStringDistanceService.GetAllLetters(first, second);

            var allLettersAlphabetic = allLetters.OrderBy(letter => letter).ToList();

            IList<int>[] binaries = SMCStringDistanceService.CalculateBinary(first, second, allLettersAlphabetic);

            int compteur = 0;
            int m00orm11 = 0;
            int m01 = 0;
            int m10 = 0;

            
            while (compteur < binaries[0].Count() && compteur < binaries[1].Count())
            {
                if (binaries[0][compteur] == binaries[1][compteur])
                    m00orm11++;

                if (binaries[0][compteur] == 0 && binaries[1][compteur] == 1)
                    m01++;

                if (binaries[0][compteur] == 1 && binaries[1][compteur] == 0)
                    m10++;

                compteur++;
            }

            distance = (double) m00orm11 / (double) (m00orm11 + m01 + m10);
            return distance * 100;
        }

        private static IList<char> GetAllLetters(string first, string second)
        {
            IList<char> allLetters = new List<char>();

            first.ToUpper().ToList().ForEach(letter => {
                if (!allLetters.Contains(letter)) allLetters.Add(letter);
            });

            second.ToUpper().ToList().ForEach(letter => { 
                if (!allLetters.Contains(letter)) allLetters.Add(letter);
            });

            return allLetters;
        }

        private static IList<int>[] CalculateBinary(string first, string second, IList<char> allLettersAlphabetic)
        {
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

            return new IList<int>[] { firstBinary, secondBinary };
        }
    }
}
