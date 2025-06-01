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
    //Point2D is a class that inherits PointD and implements it.It is the 
    //basis for creating an array of points necessary for drawing a shape.



    // https://learn.microsoft.com/en-us/dotnet/standard/base-types/custom-numeric-format-strings#the-0-custom-specifier
    // Output format for real numbers (coordinates, thickness, etc.)
    // "0.###";

    // Do not overlap System.Drawing PointF Struct 
    // https://learn.microsoft.com/en-us/dotnet/api/system.drawing.pointf
    // double, not int, because otherwise, when scaling through integer
    // rounding, errors will accumulate, we may even get 0 in X and Y.

    public class Point2D : PointD
    {
        public override double X { set; get; }
        public override double Y { set; get; }
        public override double Z { set; get; } = 0;

        public Point2D(double x, double y)
        {
            X = x;
            Y = y;
        }
        public override string ToString() =>
            $"({X:0.###}, {Y:0.###})";
    }
}
