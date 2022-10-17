using AppCore.BLL.Model;
using AppCore.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringDistanceService.BLL.Control
{
    public class StringDistanceController
    {
        public StringDistanceController() { }

        static int Minimum(int a, int b, int c) => (a = a < b ? a : b) < c ? a : c;

        // Mathis
        public int CalculateLevenshteinDistance(string shingle1, string shingle2)
        {
            if (String.IsNullOrEmpty(shingle1))
                return shingle2.Length;
            if (String.IsNullOrEmpty(shingle2))
                return shingle1.Length;
            
            int bothFirstCharactersAreTheSame = (shingle1[0] != shingle2[0]) ? 1 : 0;
            return new int[]
            {
            CalculateLevenshteinDistance(shingle1[1..], shingle2[1..]) + bothFirstCharactersAreTheSame,
            CalculateLevenshteinDistance(shingle1[1..], shingle2) + 1,
            CalculateLevenshteinDistance(shingle1, shingle2[1..]) + 1
            }.Min();
        }

        public double CalculateSMCDistance()
        {
            return 0f;
        }

        // Francis
        public int CalculateHammingDistance()
        {
            return 0;
        }

        public double CalculateJaroDistance()
        {
            return 0f;
        }
    }
}
