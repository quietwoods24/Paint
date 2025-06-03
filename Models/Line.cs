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
    //Line is a class that inherits Shape2D and is responsible for creating a line.

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

        public void PointMove(double newX, double newY)
        {
            x2 = newX - clickdX;
            y2 = newY - clickdY;

            RecountPoints();
        }

        public override void StartMouseMove(double mouseX, double mouseY)
        {
            // Move point
            if (PointMouseHover(mouseX, mouseY))
            {
                clickdX = mouseX - x2;
                clickdY = mouseY - y2;
            }
            // Move whole line
            else {
                clickdX = mouseX - x1;
                clickdY = mouseY - y1;
            }
        }

        public override void MouseMoveTo(double newX, double newY)
        {
            if (PointMouseHover(newX, newY)) {
                PointMove(newX, newY);
            }
            else
                Move(newX - clickdX - x1, newY - clickdY - y1); ;
        }

        public bool PointMouseHover(double mouseX, double mouseY) {
            double dx = mouseX - x2;
            double dy = mouseY - y2;
            return dx * dx + dy * dy <= Math.Pow((clickTolerance * 2), 2);
        }

        public override void Zoom(double zoomX, double zoomY, bool isZoomInPlace = false)
        {
            if (zoomX <= 0)
            {
                string errorMessage = $"ERROR: Zoom factor must be > 0: {zoomX}";
                Console.WriteLine(errorMessage);
                // throw new ArgumentOutOfRangeException(errorMessage);
                return;
            }

            if(isZoomInPlace) { 
                x1 *= zoomX;
                y1 *= zoomX;
                x2 *= zoomX;
                y2 *= zoomX;
            }
            else {
                x2 *= zoomX;
                y2 *= zoomY;
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
                $"Stroke width: {StrokeWidth:0.###}"
            };
            return String.Join(delimeter, fields);
        }

    }
}
