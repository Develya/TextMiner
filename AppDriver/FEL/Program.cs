using AppCore.BLL.Model;
using AppCore.DAL;
using StringDistanceService.BLL.Control;
using CorpusService.BLL.Control;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Document = AppCore.BLL.Model.Document;
using SDS.BLL.Control;
using ApppCore.DAL;

namespace AppDriver.FEL
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Executing TextMiner...");
            InMemoryDatabase db = new InMemoryDatabase();
            DBInMemStringDistanceDAO dbInMemoryStringDistanceDAO = new(db);

            IDistanceService smc = new SMCDistanceService(dbInMemoryStringDistanceDAO);

            Console.WriteLine(smc.GetDistance("chien", "chat"));
        }
    }
}
