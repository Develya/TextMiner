using AppCore.BLL.Model;
using AppCore.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringDistanceService.BLL.Control
{
    public class LevenshteinStringDistanceService : IStringDistanceService
    {
        private IStringDistanceDAO Dao;
        public LevenshteinStringDistanceService(IStringDistanceDAO dao)
        {
            this.Dao = dao;
        }

        public double GetDistance(string first, string second)
        {
            int distance = LevenshteinDistance(first, second);
            this.Dao.AddStringDistance(new StringDistance(first, second, distance));
            return distance * 100;
        }

        public int LevenshteinDistance(string first, string second)
        {
            if (String.IsNullOrEmpty(first))
                return second.Length;
            if (String.IsNullOrEmpty(second))
                return first.Length;

            int bothFirstCharactersAreTheSame = (first[0] != second[0]) ? 1 : 0;
            return new int[]
            {
                LevenshteinDistance(first[1..], second[1..]) + bothFirstCharactersAreTheSame,
                LevenshteinDistance(first[1..], second) + 1,
                LevenshteinDistance(first, second[1..]) + 1
            }.Min();
        }
    }
}
