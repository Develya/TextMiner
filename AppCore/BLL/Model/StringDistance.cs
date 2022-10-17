using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCore.BLL.Model
{
    public class StringDistance
    {
        public String Left { get; set; }
        public String Right { get; set; }
        public double Value { get; set; }

        public StringDistance(string left, string right, double value)
        {
            Left = left;
            Right = right;
            Value = value;
        }
    }
}
