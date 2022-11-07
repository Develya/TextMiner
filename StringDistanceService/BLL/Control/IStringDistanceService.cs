using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringDistanceService.BLL.Control
{
    public interface IStringDistanceService
    {
        public double GetDistance(string first, string second);
    }
}
