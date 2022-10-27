using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDS.BLL.Control
{
    class JaroDistanceService : IDistanceService
    {
        public double getDistance(string first, string second)
        {
            double distance = 0.0d;
            string firstToken = getMatchingCharacters(first, second);
            string secondToken = getMatchingCharacters(second, firstToken);  
            double countNonMatching = countNonMatchingCharacters(firstToken, secondToken); //n
            double countMatching = firstToken.Length; //m
            
            if (countMatching == 0)
                distance = 0;
            else
                distance = 0.33 * (countMatching/first.Length + 
                                countMatching/second.Length 
                                + (countMatching- countNonMatching)/countMatching);
            return distance;
        }



        private string getMatchingCharacters(string first, string second)
        {
            ICollection<char> buffer = new HashSet<char>();
            foreach (char f in first)
                foreach (char s in second)
                    if (Char.ToUpper(f) == Char.ToUpper(s))
                        buffer.Add(f);
                       
            StringBuilder matchingCharacters = new StringBuilder();
            foreach (char c in buffer)
                matchingCharacters.Append(c);

            return matchingCharacters.ToString();
        }

        public double countNonMatchingCharacters(string first, string second)
        {
            double distance = 0.0d;
            int counter = 0;
            while ((counter < first.Length) && (counter < second.Length))
            {
                if (Char.ToUpper(first[counter]) != Char.ToUpper(second[counter]))
                    distance++;
                counter++;
            }
            return distance + (first.Length - counter) + (second.Length - counter);
        }
    }
}
