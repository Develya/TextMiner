using AppCore.BLL.Model;
using AppCore.DAL;
using CorpusService.BLL.Control;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
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
            DBInMemStringDistanceDAO dbInMemoryStringDistanceDAO = new();

            dbInMemoryStringDistanceDAO.AddStringDistance("lol", "hello", 2);

            foreach (StringDistance distance in dbInMemoryStringDistanceDAO.FindAllStringDistances())
            {
                Console.WriteLine(distance.Right);
            }
        }
    }
}
