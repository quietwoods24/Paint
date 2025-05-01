using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Paint
{

    public class Pyramid : Shape2D
    {
        public Point3D Vertex { set; get; }

        public Pyramid(Point3D vertex, params Point2D[] points) : base(points)
        {
            Vertex = vertex;
        }


        public override void Move(double xOffset, double yOffset)
        {
            base.Move(xOffset, yOffset);

            Vertex.X += xOffset;
            Vertex.Y += yOffset;
        }


        public override void Zoom(double zoomFactor)
        {
            if (zoomFactor <= 0)
            {
                string errorMessage = $"ERROR: Zoom factor must be > 0: {zoomFactor}";
                Console.WriteLine(errorMessage);
                return;
            }

            base.Zoom(zoomFactor);

            Vertex.X *= zoomFactor;
            Vertex.Y *= zoomFactor;
            Vertex.Z *= zoomFactor;
        }

        public static double XCabinetProjection(Point3D point)
        {
            return point.X + 0.5 * point.Z * Math.Cos(-Math.PI * 1 / 4);
        }


        public static double YCabinetProjection(Point3D point)
        {
            return point.Y + 0.5 * point.Z * Math.Sin(-Math.PI * 1 / 4);
        }


        public override void Draw(PaintEventArgs e)
        {
            if (points.Length <= 0)
                return;

            base.Draw(e);


            Pen pen = new Pen(StrokeColor, 1);
            Pen penSelected = new Pen(selectedColor, selectedWidth);

            float vertexX = (float)XCabinetProjection(Vertex);
            float vertexY = (float)YCabinetProjection(Vertex);

            for (int i = 0; i < points.Length; i++)
            {
                e.Graphics.DrawLine(selected ? penSelected : pen,
                    vertexX, vertexY,
                    (float)points[i].X, (float)points[i].Y);
            }

            e.Graphics.DrawEllipse(selected ? penSelected : pen, (int)vertexX - markerSize, (int)vertexY - markerSize, 2 * markerSize, 2 * markerSize);
        }


        public override double GetPerimeter()
        {
            double result = base.GetPerimeter();

            for (int i = 0; i < points.Length; i++)
            {
                result += Distance(Vertex, points[i]);
            }
            return result;
        }


        public override double GetArea()
        {
            double result = base.GetArea();

            for (int i = 0; i < points.Length; i++)
            {
                int j = (i + 1) % points.Length;
                double a = Distance(Vertex, points[i]);
                double b = Distance(Vertex, points[j]);
                double c = Distance(points[i], points[j]);
                result += TriangleArea(a, b, c);
            }
            return result;
        }


        public override string ToString()
        {
            string[] fields =
            {
                base.ToString(),
                $"Vertex: {Vertex.ToString()}"
            };
            return String.Join(delimeter, fields);
        }
    }


    public class Prism : Pyramid
    {
        public Prism(Point3D vertex, params Point2D[] points) : base(vertex, points)
        {
        }


        public override void Draw(PaintEventArgs e)
        {
            if (points.Length <= 0)
                return;

            PointF[] upperBasePoints = new PointF[points.Length];
            PointF[] lowerBasePoints = new PointF[points.Length];

            double dX = Vertex.X - points[0].X;
            double dY = Vertex.Y - points[0].Y;

            for (int i = 0; i < points.Length; i++)
            {
                lowerBasePoints[i] = new PointF((float)points[i].X, (float)points[i].Y);

                var iVertex = new Point3D(points[i].X + dX, points[i].Y + dY, Vertex.Z);
                upperBasePoints[i] = new PointF((float)XCabinetProjection(iVertex), (float)YCabinetProjection(iVertex));
            }

            Pen pen = new Pen(StrokeColor, (float)StrokeWidth);
            Pen penSelected = new Pen(selectedColor, selectedWidth);

            e.Graphics.DrawPolygon(selected ? penSelected : pen, lowerBasePoints);

            pen.Width = 1;
            e.Graphics.DrawPolygon(selected ? penSelected : pen, upperBasePoints);

            for (int i = 0; i < points.Length; i++)
            {
                e.Graphics.DrawLine(selected ? penSelected : pen, lowerBasePoints[i], upperBasePoints[i]);

                e.Graphics.DrawEllipse(selected ? penSelected : pen,
                    (int)lowerBasePoints[i].X - markerSize, (int)lowerBasePoints[i].Y - markerSize, 2 * markerSize, 2 * markerSize);
            }
            e.Graphics.DrawEllipse(selected ? penSelected : pen,
                (int)upperBasePoints[0].X - markerSize, (int)upperBasePoints[0].Y - markerSize, 2 * markerSize, 2 * markerSize);
        }


        public override double GetPerimeter()
        {
            double result = 2 * (new Shape2D(points)).GetPerimeter();

            result += points.Length * Distance(Vertex, points[0]);

            return result;
        }


        public override double GetArea()
        {
            double result = 2 * (new Shape2D(points)).GetArea();

            double dX = Vertex.X - points[0].X;
            double dY = Vertex.Y - points[0].Y;
            for (int i = 0; i < points.Length; i++)
            {
                int j = (i + 1) % points.Length;
                double a = Distance(points[i], points[j]);
                double b = Distance(Vertex, points[0]);
                Point3D vertexPj = new Point3D(points[j].X + dX, points[j].Y + dY, Vertex.Z);
                double d = Distance(points[i], vertexPj); 
                result += 2 * TriangleArea(a, b, d);
            }
            return result;
        }
    }
}

