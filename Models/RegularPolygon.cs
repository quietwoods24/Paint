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
    //RegularPolygon is a class that inherits Shape2D and is responsible for
    //creating shapes - regular polygons.



    // https://en.wikipedia.org/wiki/Regular_polygon
    public class RegularPolygon : Shape2D
    {
        // n - number of sides
        // r - radius of the described circle
        // phi - initial angle (offset of the first angle)
        // x, y - coordinates of the center of the described circle
        protected int n = 1;
        protected double r = 0;
        protected double alpha = 0;
        protected double x = 0;
        protected double y = 0;


        // https://learn.microsoft.com/en-us/dotnet/standard/serialization/system-text-json/ignore-properties
        // https://www.newtonsoft.com/json/help/html/PropertyJsonIgnore.htm
        [JsonIgnore]
        public override Point2D[] Points { get; set; }


        public int N { get { return n; } set { n = value; RecountPoints(); } }
        public double R { get { return r; } set { r = value; RecountPoints(); } }
        public double Alpha { get { return alpha; } set { alpha = value; RecountPoints(); } }
        public double X { get { return x; } set { x = value; RecountPoints(); } }
        public double Y { get { return y; } set { y = value; RecountPoints(); } }


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
        public RegularPolygon() : base()
        {
            // https://stackoverflow.com/questions/13947997/how-to-deserialize-class-without-calling-a-constructor
            // For correct deserialization of JSON
            // Do nothing
        }


        // To call the basic constructor (Shape2D) with non-empty Points
        protected static Point2D[] RecountPoints(int n, double r, double phi, double x, double y)
        {
            if (n < 3 || r < 0)
                return new Point2D[0];

            var Points = new Point2D[n];
            for (int i = 0; i < n; i++)
            {
                double angle = Math.PI * phi / 180.0 + 2 * Math.PI * i / n;
                Points[i] = new Point2D(
                    x + r * Math.Cos(angle),
                    y + r * Math.Sin(angle));
            }

            return Points;
        }


        // For internal use only
        protected void RecountPoints()
        {
            Points = RecountPoints(n, r, alpha, x, y);
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


        public override void Zoom(double zoomX, double zoomY, bool isZoomInPlace)
        {
            if (zoomX <= 0)
            {
                string errorMessage = $"ERROR: Zoom factor must be > 0: {zoomX}";
                Console.WriteLine(errorMessage);
                // throw new ArgumentOutOfRangeException(errorMessage);
                return;
            }
            if (isZoomInPlace)
                r *= zoomX;
            else {
                r *= zoomX;
                x *= zoomX;
                y *= zoomX;
            }

            RecountPoints();
        }


        public override string ToString()
        {
            string[] fields =
            {
                //base.ToString(),
                $"{GetType().Name}",
                $"Id : {Id}",
                $"Side count: {n}",
                $"Radius: {r:0.###}",
                $"Start angle: {alpha:0.###}",
                $"Center: ({x:0.###}, {x:0.###})",
                $"Stroke color: {StrokeColor}",
                $"Fill color: {FillColor}",
                $"Stroke width: {StrokeWidth:0.###}"
            };
            return String.Join(delimeter, fields);
        }
    }
}
