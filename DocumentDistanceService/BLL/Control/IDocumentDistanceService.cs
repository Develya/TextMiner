using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppCore.BLL.Model;

namespace DocumentDistanceService.BLL.Control
{
    public interface IDocumentDistanceService
    {
        double GetDistance(Document doc1, Document doc2);
    }
}
