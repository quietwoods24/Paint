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
    public class Line : Shape2D
    {
        protected double x1 = 0;
        protected double y1 = 0;
        protected double x2 = 0;
        protected double y2 = 0;

        public override Color FillColor => Color.Transparent;
        public double X1 { get { return x1; } set { x1 = value; RecountPoints(); } }
        public double Y1 { get { return y1; } set { y1 = value; RecountPoints(); } }
        public double X2 { get { return x2; } set { x2 = value; RecountPoints(); } }
        public double Y2 { get { return y2; } set { y2 = value; RecountPoints(); } }

        public override string ShapeInfo
        {
            get
            {
                string shName = $"Name: {GetType().Name},  ";
                string shStrCol = $"Stroke color: {StrokeColor.Name},  ";
                string shFillCol = $"Fill color: {Color.Transparent.Name},  ";
                string shStrW = $"Stroke width: {StrokeWidth}";
                return shName + shStrCol + shFillCol + shStrW;
            }
        }


        // https://learn.microsoft.com/en-us/dotnet/standard/serialization/system-text-json/immutability
        // https://www.newtonsoft.com/json/help/html/JsonConstructorAttribute.htm
        [JsonConstructor]
        public Line() : base()
        {
            // https://stackoverflow.com/questions/13947997/how-to-deserialize-class-without-calling-a-constructor
            // Do nothing
        }


        protected static Point2D[] RecountPoints(double x1, double y1, double x2, double y2)
        {
            var Points = new Point2D[2];
            Points[0] = new Point2D(x1, y1);
            Points[1] = new Point2D(x2, y2);

            return Points;
        }

        protected void RecountPoints()
        {
            Points = RecountPoints(x1, y1, x2, y2);
        }


        public Line(double x1, double y1, double x2, double y2)
            : base(RecountPoints(x1, y1, x2, y2))
        {
            X1 = x1;
            Y1 = y1;
            X2 = x2;
            Y2 = y2;

            RecountPoints();
        }


        public override void Move(double xOffset, double yOffset)
        {

            x1 += xOffset;
            y1 += yOffset;
            x2 += xOffset;
            y2 += yOffset;

            RecountPoints();
        }


        public override void Zoom(double zoomFactor, double zFW = 1, double zFH = 1, bool ZoomWholeImg = false)
        {
            if (zoomFactor <= 0)
            {
                string errorMessage = $"ERROR: Zoom factor must be > 0: {zoomFactor}";
                Console.WriteLine(errorMessage);
                // throw new ArgumentOutOfRangeException(errorMessage);
                return;
            }

            x1 *= zoomFactor;
            y1 *= zoomFactor;
            x2 *= zoomFactor;
            y2 *= zoomFactor;

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
                $"Stroke width: {StrokeWidth:0.###}"
            };
            return String.Join(delimeter, fields);
        }

    }
}
