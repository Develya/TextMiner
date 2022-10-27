using AppCore.BLL.Model;
using AppCore.DAL;
using CorpusService.BLL.Control;
using StringDistanceService.BLL.Control;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Document = AppCore.BLL.Model.Document;

namespace AppDriver.FEL
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Executing TextMiner...");
            DBInMemStringDistanceDAO dBinMemoryStringDistanceDAO = new();
            StringDistanceController stringDistanceController = new();

            Console.WriteLine(stringDistanceController.CalculateLevenshteinDistance("chess", "chello", dBinMemoryStringDistanceDAO));
            
            foreach (StringDistance stringDistance in StringDistanceController.FindAllStringDistances(dBinMemoryStringDistanceDAO))
            {
                Console.WriteLine(stringDistance.Value);
            }
            
        }
    }
}
