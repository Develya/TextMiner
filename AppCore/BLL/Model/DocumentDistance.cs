using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCore.BLL.Model
{
    public class DocumentDistance
    {
        public Document Left { get; set; }
        public Document Right { get; set; }
        public double Value { get; set; }

        public DocumentDistance(Document left, Document right, double value)
        {
            this.Left = left;
            this.Right = right;
            this.Value = value;
        }
    }
}
