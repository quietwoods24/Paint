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
    public class Circle : Shape2D
    {

        protected double diameter = 0;
        protected double x = 0;
        protected double y = 0;


        public double X { get { return x; } set { x = value; } }
        public double Y { get { return y; } set { y = value; } }
        public double Diameter { get { return diameter; } set { diameter = value; } }

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
        public Circle() : base()
        {
            // https://stackoverflow.com/questions/13947997/how-to-deserialize-class-without-calling-a-constructor
            // Do nothing
        }

        protected static Point2D[] RecountPoints(double x, double y, double d)
        {
            var Points = new Point2D[1];
            Points[0] = new Point2D(x, y);

            return Points;
        }

        protected void RecountPoints()
        {
            Points = RecountPoints(x, y, diameter);
        }

        public Circle(double x, double y, double d)
            : base(RecountPoints(x, y, d))
        {
            X = x;
            Y = y;
            Diameter = d;

            RecountPoints();
        }

        public override void Move(double xOffset, double yOffset)
        {
            x += xOffset;
            y += yOffset;

            RecountPoints();
        }

        public override void Zoom(double zoomFactor, double zFW = 1, double zFH = 1)
        {
            if (zoomFactor <= 0)
            {
                string errorMessage = $"ERROR: Zoom factor must be > 0: {zoomFactor}";
                Console.WriteLine(errorMessage);
                return;
            }

            diameter *= zoomFactor;

            RecountPoints();
        }


        public override string ToString()
        {
            string[] fields =
            {
                $"{GetType().Name}",
                $"Id : {Id}",
                $"Coords: ({x:0.###}, {y:0.###})",
                $"Stroke color: {StrokeColor}",
                $"Fill color: {FillColor}",
                $"Stroke width: {StrokeWidth:0.###}"
            };
            return String.Join(delimeter, fields);
        }

        public override bool MouseHover(double mouseX, double mouseY)
        {
            return (x <= mouseX && mouseX <= x + diameter) &&
                   (y <= mouseY && mouseY <= y + diameter);
        }

        public override void Draw(PaintEventArgs e)
        {
            SolidBrush brush = new SolidBrush(FillColor);
            e.Graphics.FillEllipse(brush, (float)x, (float)y, (float)diameter, (float)diameter);

            Pen pen = new Pen(StrokeColor, StrokeWidth);
            Pen penSelected = new Pen(selectedColor, selectedWidth);
            e.Graphics.DrawEllipse(selected ? penSelected : pen, (float)x, (float)y, (float)diameter, (float)diameter);
        }
    }
}
