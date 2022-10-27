using SDS.BLL.Control;
using System;

namespace SDS
{
    class AppDriver
    {
        static void Main(string[] args)
        {
            Console.WriteLine("StringDistanceService in progress...");
            string first = "Winkler";
            string second= "WELFARE";

            //IDistanceService hds = new HammingDistanceService();
            //double distance = hds.getDistance(first, second);
            //Console.WriteLine($"Distance is: {distance}"); // string interpolation

            JaroDistanceService jds = new JaroDistanceService();
            double distance= jds.getDistance(second,first);
            Console.WriteLine($"Distance is: {distance}");
            
            Console.ReadKey();

        }
    }
}
