using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Added manually for Drawing
using System.Drawing;
using System.Windows.Forms;

namespace Paint
{
    //PointD is a base abstract class, which is the basis for the Point2D class.



    public abstract class PointD
    {
        public abstract double X { set; get; }
        public abstract double Y { set; get; }
        public abstract double Z { set; get; }

        public abstract override string ToString();
    }
}
