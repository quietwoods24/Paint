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

    // https://learn.microsoft.com/en-us/dotnet/standard/base-types/custom-numeric-format-strings#the-0-custom-specifier
    // Output format for real numbers (coordinates, thickness, etc.)
    // "0.###";

    // Do not overlap System.Drawing PointF Struct 
    // https://learn.microsoft.com/en-us/dotnet/api/system.drawing.pointf
    // double, not int, because otherwise, when scaling through integer
    // rounding, errors will accumulate, we may even get 0 in X and Y.


    //public class Point3D : PointD
    //{
    //    public override double X { set; get; }
    //    public override double Y { set; get; }
    //    public override double Z { set; get; }

    //    public Point3D(double x, double y, double z)
    //    {
    //        X = x;
    //        Y = y;
    //        Z = z;
    //    }

    //    public override string ToString() =>
    //        $"({X:0.###}, {Y:0.###}, {Z:0.###})";
    //}

    public abstract class Shape
    {
        protected const double EPSILON = 1.0e-7;
        protected const string delimeter = "; ";

        protected const int clickTolerance = 10;
        protected const int markerSize = 2;
        protected double clickdX = 0;
        protected double clickdY = 0;
        protected bool selected = false;
        // Pen of the selected shape
        protected Color selectedColor = Color.MediumPurple;
        protected float selectedWidth = 2;



        // https://learn.microsoft.com/en-us/dotnet/api/system.drawing.color
        // https://learn.microsoft.com/en-us/dotnet/api/system.drawing.pen.width
        public int Id { get; set; }
        public virtual string ShapeInfo { get; set; } = "";
        public virtual Color StrokeColor { get; set; } = Color.Black;
        public virtual Color FillColor { get; set; } = Color.Transparent;
        public virtual float StrokeWidth { get; set; } = 2.0F;

        public virtual int rotationAngle { get; set; } = 0;
        public virtual Point2D[] points { get; set; }

        public abstract void Move(double xOffset, double yOffset);
        public abstract void Zoom(double zoomFactor);
        public abstract void Draw(PaintEventArgs e);


        public abstract void MouseMoveTo(double newX, double newY);
        public abstract void StartMouseMove(double mouseX, double mouseY);
        public abstract void StopMouseMove(object sender, MouseEventArgs e);
        public abstract bool MouseHover(double mouseX, double mouseY);
        public abstract void Select();
        public abstract void Deselect();


        protected abstract double Distance(PointD p1, PointD p2);
        public abstract double GetPerimeter();
        public abstract double GetArea();
        public abstract override string ToString();
         

        // Indexer 
        public abstract PointD this[int index] { set; get; }
    }
}
