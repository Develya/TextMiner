using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringDistanceService.BLL.Control
{
    public class HammingStringDistanceService : IStringDistanceService
    {
        /// <summary>
        /// Method <c>getDistance</c> returns number of different positions in
        /// both tokens
        ///  <param name="first" type="string"></param>
        ///  <param name="second" type="string"></param>
        /// <returns name="distance" type="doubke">distance between provided tokens</returns>
        /// </summary>
        public double GetDistance(string first, string second)
        {
            double distance = 0.0d;
            int counter = 0;
            while ((counter < first.Length) && (counter < second.Length)) {
                if (Char.ToUpper(first[counter]) != Char.ToUpper(second[counter]))
                    distance++;
                counter++;
            }
            return distance + (first.Length - counter) + (second.Length - counter); 
        }
    }
}
