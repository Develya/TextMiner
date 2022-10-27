using AppCore.BLL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCore.DAL
{
    public interface IStringDistanceDAO
    {
        public void AddStringDistance(String leftKShingle, String rightKShingle, double value);

        public IList<StringDistance> FindAllStringDistances();
    }
}
