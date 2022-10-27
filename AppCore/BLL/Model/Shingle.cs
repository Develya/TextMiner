using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCore.BLL.Model
{
    public class Shingle
    {
        // A sequence of k continous characters
        public String sequence { get; set; }
        int k; 
        public Shingle(string sequence, int k)
        {
            this.sequence = sequence;
            this.k = k;
        }
    }
}
