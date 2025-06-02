using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Added manually for Drawing
using System.Drawing;
using System.Windows.Forms;
// https://www.newtonsoft.com/json
using Newtonsoft.Json;

namespace Paint
{
    //RectangleMy is a class that inherits Shape2D and is responsible for creating 
    //a rectangle shape.



    public class RectangleMy : Shape2D
    {

        protected double x = 0;
        protected double y = 0;
        protected double w = 0;
        protected double h = 0;

        public double X { get { return x; } set { x = value; RecountPoints(); } }
        public double Y { get { return y; } set { y = value; RecountPoints(); } }

        public double W { get { return w; } set { w = value; RecountPoints(); } }
        public double H { get { return h; } set { h = value; RecountPoints(); } }

        public override string ShapeInfo
        {
            get
            {
                string shName = $"Name: {GetType().Name},  ";
                string shStrCol = $"Stroke color: {StrokeColor.Name},  ";
                string shFillCol = $"Fill color: {FillColor.Name},  ";
                string shStrW = $"Stroke width: {StrokeWidth}";
                return shName + shStrCol + shFillCol + shStrW;
            }
        }


        // https://learn.microsoft.com/en-us/dotnet/standard/serialization/system-text-json/immutability
        // https://www.newtonsoft.com/json/help/html/JsonConstructorAttribute.htm
        [JsonConstructor]
        public RectangleMy() : base()
        {
            // https://stackoverflow.com/questions/13947997/how-to-deserialize-class-without-calling-a-constructor
            // Do nothing
        }


        protected static Point2D[] RecountPoints(double x, double y, double w, double h)
        {
            var Points = new Point2D[4];
            Points[0] = new Point2D(x, y);
            Points[1] = new Point2D(x + w, y);
            Points[2] = new Point2D(x + w, y + h);
            Points[3] = new Point2D(x, y + h);


            return Points;
        }

        protected void RecountPoints()
        {
            Points = RecountPoints(x, y, w, h);
        }


        public RectangleMy(double x, double y, double w, double h)
            : base(RecountPoints(x, y, w, h))
        {
            X = x;
            Y = y;
            W = w;
            H = h;

            RecountPoints();
        }

        public override void Move(double xOffset, double yOffset)
        {
            x += xOffset;
            y += yOffset;

            RecountPoints();
        }

        public override void Zoom(double zoomX, double zoomY, bool isZoomInPlace)
        {
            if (zoomX <= 0)
            {
                string errorMessage = $"ERROR: Zoom factor must be > 0: {zoomX}";
                Console.WriteLine(errorMessage);
                // throw new ArgumentOutOfRangeException(errorMessage);
                return;
            }
            if (zoomY <= 0)
            {
                string errorMessage = $"ERROR: Zoom factor must be > 0: {zoomX}";
                Console.WriteLine(errorMessage);
                // throw new ArgumentOutOfRangeException(errorMessage);
                return;
            }

            if (isZoomInPlace)
            {
                w *= zoomX;
                h *= zoomY;
            }
            else
            {
                x *= zoomX;
                y *= zoomX;
                w *= zoomX;
                h *= zoomX;
            }
            
            RecountPoints();
        }


        public override string ToString()
        {
            List<string> strPoints = new List<string>();
            foreach (Point2D point in Points)
            {
                strPoints.Add(point.ToString());
            }

            string[] fields =
            {
                $"{GetType().Name}",
                $"Id : {Id}",
                $"Points: {String.Join(", ", strPoints)}",
                $"Stroke color: {StrokeColor}",
                $"Fill color: {FillColor}",
                $"Stroke width: {StrokeWidth:0.###}"
            };
            return String.Join(delimeter, fields);
        }

    }
}
