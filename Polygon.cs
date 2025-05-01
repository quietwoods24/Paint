using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Newtonsoft.Json;

namespace Paint
{
    public class Polygon : Shape2D
    {
        public Polygon(params Point2D[] points) : base(points)
        {
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

    public class RegularPolygon : Shape2D
    {
        protected int    n   = 1;
        protected double r   = 0;
        protected double phi = 0;
        protected double x   = 0;
        protected double y   = 0;


        [JsonIgnore]
        public override Point2D[] points { get; set; }


        public int    N   { get { return n;   } set { n   = value; RecountPoints(); } }
        public double R   { get { return r;   } set { r   = value; RecountPoints(); } }
        public double Phi { get { return phi; } set { phi = value; RecountPoints(); } }
        public double X   { get { return x;   } set { x   = value; RecountPoints(); } }
        public double Y   { get { return y;   } set { y   = value; RecountPoints(); } }


        [JsonConstructor]
        public RegularPolygon() : base()
        {
        }

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

        protected void RecountPoints()
        {
            points = RecountPoints(n, r, phi, x, y);
        }


        public RegularPolygon(int sideCount, double radius, double startAngle, double centerX, double centerY)
            : base(RecountPoints(sideCount, radius, startAngle, centerX, centerY))
        {
            if (sideCount < 3)
            {
                string errorMessage = $"ERROR: Side count < 3: {sideCount}";
                Console.WriteLine(errorMessage);
                return;
            }

            if (radius <= EPSILON)
            {
                string errorMessage = $"ERROR: Radius <= 0: {radius}";
                Console.WriteLine(errorMessage);
                return;
            }

            n = sideCount;
            r = radius;
            phi = startAngle;
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

            return 2.0 * n * Math.Sin(Math.PI / n) * r;
        }


        public override double GetArea()
        {
            if (n < EPSILON)
                return -1;

            return n / 2.0 * Math.Sin(2 * Math.PI / n) * r * r;
        }


        public override string ToString()
        {
            string[] fields =
            {
                $"{GetType().Name}",
                $"Side count: {n}",
                $"Radius: {r:0.###}",
                $"Start angle: {phi:0.###}",
                $"Side count: {n}",
                $"Center: ({x:0.###}, {x:0.###})",
                $"Area: {GetArea():0.###}",
                $"Perimeter: {GetPerimeter():0.###}"

            };
            return String.Join(delimeter, fields);
        }
    }
}
