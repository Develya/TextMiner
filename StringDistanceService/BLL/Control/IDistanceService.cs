using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDS.BLL.Control
{
    public interface IDistanceService
    {
        public double getDistance(string first, string second);
    }
}
