using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringDistanceService.BLL.Control
{
    public class HammingStringDistanceService : IStringDistanceService
    {
        // Distance between two strings of equal length is the number of positions
        // at which the corresponding symbols are different. 

        public double GetDistance(string first, string second)
        {
            double distance = 0.0;
            int i = 0;

            // Calculates the number of positions where characters are different
            while ((i < first.Length) && (i < second.Length)) {
                if (Char.ToUpper(first[i]) != Char.ToUpper(second[i]))
                    distance++;
                i++;
            }

            return distance * 100; 
        }
    }
}
