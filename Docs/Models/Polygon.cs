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
    public class Polygon : Shape2D
    {
        public Polygon(params Point2D[] points) : base(points)
        {
            // Do nothing
        }

    }

    public class Rand_Rectangle : Shape2D
    {


        protected double x1 = 0;
        protected double y1 = 0;
        protected double x2 = 0;
        protected double y2 = 0;

        public double X1 { get { return x1; } set { x1 = value; RecountPoints(); } }
        public double Y1 { get { return y1; } set { y1 = value; RecountPoints(); } }
        public double X2 { get { return x2; } set { x2 = value; RecountPoints(); } }
        public double Y2 { get { return y2; } set { y2 = value; RecountPoints(); } }


        // https://learn.microsoft.com/en-us/dotnet/standard/serialization/system-text-json/immutability
        // https://www.newtonsoft.com/json/help/html/JsonConstructorAttribute.htm
        [JsonConstructor]
        public Rand_Rectangle() : base()
        {
            // https://stackoverflow.com/questions/13947997/how-to-deserialize-class-without-calling-a-constructor
            // Do nothing
        }


        protected static Point2D[] RecountPoints(double x1, double y1, double x2, double y2)
        {
            var points = new Point2D[4];
            points[0] = new Point2D(x1, y1);
            points[1] = new Point2D(x2, y1);
            points[2] = new Point2D(x2, y2);
            points[3] = new Point2D(x1, y2);

            return points;
        }

        protected void RecountPoints()
        {
            points = RecountPoints(x1, y1, x2, y2);
        }

                
        public Rand_Rectangle(double X1, double Y1, double W, double H)
            : base(RecountPoints(X1, Y1, X1 + W, Y1 + H))
        {
            x1 = X1;
            y1 = Y1;
            x2 = X1 + W;
            y2 = Y1 + H;

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


        public override void Zoom(double zoomFactor)
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
            foreach (Point2D point in points)
            {
                strPoints.Add(point.ToString());
            }

            string[] fields =
            {
                $"{GetType().Name}",
                $"Points: {String.Join(", ", strPoints)}",
                $"Stroke color: {StrokeColor}",
                $"Fill color: {FillColor}",
                $"Stroke width: {StrokeWidth:0.###}"
            };
            return String.Join(delimeter, fields);
        }


    }

    public class Line : Shape2D
    {
        protected double x1 = 0;
        protected double y1 = 0;
        protected double x2 = 0;
        protected double y2 = 0;

        public double X1 { get { return x1; } set { x1 = value; RecountPoints(); } }
        public double Y1 { get { return y1; } set { y1 = value; RecountPoints(); } }
        public double X2 { get { return x2; } set { x2 = value; RecountPoints(); } }
        public double Y2 { get { return y2; } set { y2 = value; RecountPoints(); } }


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
            var points = new Point2D[2];
            points[0] = new Point2D(x1, y1);
            points[1] = new Point2D(x2, y2);

            return points;
        }

        protected void RecountPoints()
        {
            points = RecountPoints(x1, y1, x2, y2);
        }


        public Line(double X1, double Y1, double X2, double Y2)
            : base(RecountPoints(X1, Y1, X2, Y2))
        {
            x1 = X1;
            y1 = Y1;
            x2 = X2;
            y2 = Y2;

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


        public override void Zoom(double zoomFactor)
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
            foreach (Point2D point in points)
            {
                strPoints.Add(point.ToString());
            }

            string[] fields =
            {
                $"{GetType().Name}",
                $"Points: {String.Join(", ", strPoints)}",
                $"Stroke color: {StrokeColor}",
                $"Stroke width: {StrokeWidth:0.###}"
            };
            return String.Join(delimeter, fields);
        }

        public override void Draw(PaintEventArgs e)
        {
            PointF[] shapePoints = new PointF[points.Length];

            // Copy the array of points Point2D to the array of points PointF
            for (int i = 0; i < points.Length; i++)
            {
                shapePoints[i] = new PointF((float)points[i].X, (float)points[i].Y);
            }

            // Draw a polygon stroke
            // Create a pen
            Pen pen = new Pen(StrokeColor, StrokeWidth);
            Pen penSelected = new Pen(selectedColor, selectedWidth);
            e.Graphics.DrawLine(selected ? penSelected : pen, (float)points[0].X, (float)points[0].Y, (float)points[1].X, (float)points[1].Y);

            // Draw markers
            if (selected)
            {
                double SumX = 0;
                double SumY = 0;

                for (int i = 0; i < points.Length; i++)
                {
                    int markerX = (int)points[i].X;
                    int markerY = (int)points[i].Y;

                    SumX += points[i].X;
                    SumY += points[i].Y;

                    if (i == 0)
                        e.Graphics.DrawEllipse(new Pen(Color.Blue, selectedWidth), markerX - markerSize, markerY - markerSize, 2 * markerSize, 2 * markerSize);
                    else
                        e.Graphics.DrawEllipse(penSelected, markerX - markerSize, markerY - markerSize, 2 * markerSize, 2 * markerSize);
                }


                averageX = (float)(SumX / points.Length);
                averageY = (float)(SumY / points.Length);
                e.Graphics.DrawEllipse(penSelected, (float)averageX - markerSize, (float)averageY - markerSize, 2 * markerSize, 2 * markerSize);

            }
                        
        }

    }

    public class Circle : Shape2D
    {
        
        protected double DIAMETER = 0;
        protected double x = 0;
        protected double y = 0;
        //protected string name = "";


        // https://learn.microsoft.com/en-us/dotnet/standard/serialization/system-text-json/ignore-properties
        // https://www.newtonsoft.com/json/help/html/PropertyJsonIgnore.htm
        [JsonIgnore]
        public override Point2D[] points { get; set; }


        public double X { get { return x; } set { x = value; RecountPoints(); } }
        public double Y { get { return y; } set { y = value; RecountPoints(); } }
        //public string Name { get { return name; } set { name = value; } }


        // https://learn.microsoft.com/en-us/dotnet/standard/serialization/system-text-json/immutability
        // https://www.newtonsoft.com/json/help/html/JsonConstructorAttribute.htm
        [JsonConstructor]
        public Circle() : base()
        {
            // https://stackoverflow.com/questions/13947997/how-to-deserialize-class-without-calling-a-constructor
            // Do nothing
        }


        protected static Point2D[] RecountPoints(double x, double y)
        {
            var points = new Point2D[1];
            points[0] = new Point2D(x, y);

            return points;
        }

        protected void RecountPoints()
        {
            points = RecountPoints(x, y);
        }


        public Circle(double centerX, double centerY, double d)
            : base(RecountPoints(centerX, centerY))
        {
            x = centerX;
            y = centerY;
            DIAMETER = d;

            RecountPoints();
        }


        public override void Move(double xOffset, double yOffset)
        {
            x += xOffset;
            y += yOffset;

            RecountPoints();
        }


        public override void Zoom(double zoomFactor)
        {
            if (zoomFactor <= 0)
            {
                string errorMessage = $"ERROR: Zoom factor must be > 0: {zoomFactor}";
                Console.WriteLine(errorMessage);
                return;
            }

            x *= zoomFactor;
            y *= zoomFactor;
            DIAMETER *= zoomFactor;

            RecountPoints();
        }


        public override string ToString()
        {
            string[] fields =
            {
                $"Coords: ({x:0.###}, {y:0.###})",
                $"Stroke color: {StrokeColor}",
                $"Fill color: {FillColor}",
                $"Stroke width: {StrokeWidth:0.###}"
            };
            return String.Join(delimeter, fields);
        }

        public override bool MouseHover(double mouseX, double mouseY)
        {
            return (x <= mouseX && mouseX <= x + DIAMETER) &&
                   (y <= mouseY && mouseY <= y + DIAMETER);
        }


        public override void Draw(PaintEventArgs e)
        {

            SolidBrush brush = new SolidBrush(FillColor);
            e.Graphics.FillEllipse(brush, (float)x, (float)y, (float)DIAMETER, (float)DIAMETER);

            Pen pen = new Pen(StrokeColor, StrokeWidth);
            Pen penSelected = new Pen(selectedColor, selectedWidth);
            e.Graphics.DrawEllipse(selected ? penSelected : pen, (float)x, (float)y, (float)DIAMETER, (float)DIAMETER);

        }
    }    

    public class FilledPolygon : Shape2D
    {
        public override Color FillColor { get; set; }

        public FilledPolygon(Color fillColor, params Point2D[] points) : base(points)
        {
            FillColor = fillColor;
        }
        public override string ToString()
        {
            string[] fields =
            {
                base.ToString(),
                $"Fill color: {FillColor}"
            };
            return String.Join(delimeter, fields);
        }
    }


    // https://en.wikipedia.org/wiki/Regular_polygon
    public class RegularPolygon : Shape2D
    {
        // n - number of sides
        // r - radius of the described circle
        // phi - initial angle (offset of the first angle)
        // x, y - coordinates of the center of the described circle
        protected int    n   = 1;
        protected double r   = 0;
        protected double alpha = 0;
        protected double x   = 0;
        protected double y   = 0;


        // https://learn.microsoft.com/en-us/dotnet/standard/serialization/system-text-json/ignore-properties
        // https://www.newtonsoft.com/json/help/html/PropertyJsonIgnore.htm
        [JsonIgnore]
        public override Point2D[] points { get; set; }


        public int    N   { get { return n;   } set { n   = value; RecountPoints(); } }
        public double R   { get { return r;   } set { r   = value; RecountPoints(); } }
        public double Alpha { get { return alpha; } set { alpha = value; RecountPoints(); } }
        public double X   { get { return x;   } set { x   = value; RecountPoints(); } }
        public double Y   { get { return y;   } set { y   = value; RecountPoints(); } }


        // https://learn.microsoft.com/en-us/dotnet/standard/serialization/system-text-json/immutability
        // https://www.newtonsoft.com/json/help/html/JsonConstructorAttribute.htm
        [JsonConstructor]
        public RegularPolygon() : base()
        {
            // https://stackoverflow.com/questions/13947997/how-to-deserialize-class-without-calling-a-constructor
            // For correct deserialization of JSON
            // Do nothing
        }


        // To call the basic constructor (Shape2D) with non-empty points
        protected static Point2D[] RecountPoints(int n, double r, double phi, double x, double y)
        {
            if (n < 3 || r < 0)
                return new Point2D[0];

            var points = new Point2D[n];
            for (int i = 0; i < n; i++)
            {
                double angle = phi + 2 * Math.PI * i / n;
                points[i] = new Point2D(
                    x + r * Math.Cos(angle),
                    y + r * Math.Sin(angle));
            }

            return points;

        }

        // For internal use only
        protected void RecountPoints()
        {
            points = RecountPoints(n, r, alpha, x, y);

        }


        public RegularPolygon(int sideCount, double radius, double startAngle, double centerX, double centerY)
            : base(RecountPoints(sideCount, radius, startAngle, centerX, centerY))
        {
            if (sideCount < 3)
            {
                string errorMessage = $"ERROR: Side count < 3: {sideCount}";
                Console.WriteLine(errorMessage);
                // throw new ArgumentOutOfRangeException(errorMessage);
                return;
            }

            if (radius <= EPSILON)
            {
                string errorMessage = $"ERROR: Radius <= 0: {radius}";
                Console.WriteLine(errorMessage);
                // throw new ArgumentOutOfRangeException(errorMessage);
                return;
            }

            n = sideCount;
            r = radius;
            alpha = startAngle;
            x = centerX;
            y = centerY;

            RecountPoints();
        }
        

        public override void Move(double xOffset, double yOffset)
        {
            x += xOffset;
            y += yOffset;

            RecountPoints();
        }


        public override void Zoom(double zoomFactor)
        {
            if (zoomFactor <= 0)
            {
                string errorMessage = $"ERROR: Zoom factor must be > 0: {zoomFactor}";
                Console.WriteLine(errorMessage);
                // throw new ArgumentOutOfRangeException(errorMessage);
                return;
            }

            r *= zoomFactor;
            x *= zoomFactor;
            y *= zoomFactor;

            RecountPoints();
        }


        public override double GetPerimeter()
        {
            if (n < EPSILON)
                return -1;

            // According to the formula, r is the radius of the described circle
            return 2.0 * n * Math.Sin(Math.PI / n) * r;
        }


        public override double GetArea()
        {
            if (n < EPSILON)
                return -1;

            // According to the formula, r is the radius of the described circle
            return n / 2.0 * Math.Sin(2 * Math.PI / n) * r * r;
        }


        public override string ToString()
        {
            string[] fields =
            {
                //base.ToString(),
                $"{GetType().Name}",
                $"Side count: {n}",
                $"Radius: {r:0.###}",
                $"Start angle: {alpha:0.###}",
                $"Side count: {n}",
                $"Center: ({x:0.###}, {x:0.###})",
                $"Stroke color: {StrokeColor}",
                $"Fill color: {FillColor}",
                $"Stroke width: {StrokeWidth:0.###}"
            };
            return String.Join(delimeter, fields);
        }
    }
}
