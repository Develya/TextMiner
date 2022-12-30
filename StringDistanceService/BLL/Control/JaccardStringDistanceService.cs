using AppCore.BLL.Model;
using AppCore.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringDistanceService.BLL.Control
{
    public class JaccardStringDistanceService : IStringDistanceService
    {
        public JaccardStringDistanceService() { }

        public double GetDistance(string first, string second)
        {
            double distance;
            IList<char> commonLetters = JaccardStringDistanceService.FindCommonLetters(first, second);

            distance = 1 - ((double) commonLetters.Count / (double) (first.Length + second.Length));
            return distance * 100;
        }

        private static IList<char> FindCommonLetters(string first, string second)
        {
            IList<char> commonLetters = new List<char>();

            // Common letters from first string to second string
            foreach (char c in first.ToUpper())
            {
                if (second.ToUpper().Contains(c) && !commonLetters.Contains(c))
                {
                    commonLetters.Add(c);
                }
            }

            // Common letters from second string to first string
            foreach (char c in second.ToUpper())
            {
                if (first.ToUpper().Contains(c) && !commonLetters.Contains(c))
                {
                    commonLetters.Add(c);
                }
            }

            return commonLetters;
        }
    }
}
