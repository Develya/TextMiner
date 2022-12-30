using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCore.BLL.Model
{
    public class DocumentDistance
    {
        public int DocumentDistanceID { get; set; }
        public Document Left { get; set; }
        public Document Right { get; set; }
        public double SimilarityPercentage { get; set; }
        public static int currentID = 1;

        public DocumentDistance(Document left, Document right, double value)
        {
            this.Left = left;
            this.Right = right;
            this.SimilarityPercentage = value;
            this.DocumentDistanceID = DocumentDistance.currentID;
            DocumentDistance.currentID++;
        }

        public override string ToString()
        {
            return this.Left.Text + ";" + this.Right.Text + ";" + this.SimilarityPercentage;
        }
    }
}
