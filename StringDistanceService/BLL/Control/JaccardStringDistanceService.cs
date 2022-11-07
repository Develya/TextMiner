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
        private IStringDistanceDAO Dao;

        public JaccardStringDistanceService(IStringDistanceDAO dao)
        {
            this.Dao = dao;
        }

        public double GetDistance(string first, string second)
        {
            double distance = 0.0;
            IList<char> commonLetters = new List<char>();

            foreach (char c in first.ToUpper())
            {
                if (second.ToUpper().Contains(c) && !commonLetters.Contains(c))
                {
                    commonLetters.Add(c);
                }
            }

            foreach (char c in second.ToUpper())
            {
                if (first.ToUpper().Contains(c) && !commonLetters.Contains(c))
                {
                    commonLetters.Add(c);
                }
            }

            distance = 1 - ((double) commonLetters.Count() / (double) (first.Length + second.Length));
            this.Dao.AddStringDistance(new StringDistance(first, second, distance));
            return distance;
        }
    }
}
