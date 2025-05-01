using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Paint
{
    public class Shape2D: Shape
    {
        public Shape2D()
        {
        }


        public Shape2D(params Point2D[] shapePoints) {

            if (shapePoints.Length < 3)
            {
                string errorMessage = $"ERROR: Points count < 3: {shapePoints.Length}";
                Console.WriteLine(errorMessage);
                return;
            }

            for (int i = 0; i < shapePoints.Length - 1; i++)
                for (int j = i + 1; j < shapePoints.Length; j++)
                    if (Math.Abs(shapePoints[i].X - shapePoints[j].X) < EPSILON &&
                        Math.Abs(shapePoints[i].Y - shapePoints[j].Y) < EPSILON)
                    {
                        string errorMessage = $"ERROR: point[{i}] == point[{j}]: {shapePoints[i].ToString()} == {shapePoints[j].ToString()}";
                        Console.WriteLine(errorMessage);
                        return;
                    }

            points = new Point2D[shapePoints.Length];
            for (int i = 0; i < shapePoints.Length; i++)
            {
                points[i] = new Point2D(shapePoints[i].X, shapePoints[i].Y);
            }
        }


        public override void Move(double xOffset, double yOffset)
        {
            foreach (Point2D point in points)
            {
                point.X += xOffset;
                point.Y += yOffset;
            }
        }
        

        public override void Zoom(double zoomFactor)
        {
            if (zoomFactor <= 0)
            {
                string errorMessage = $"ERROR: Zoom factor must be > 0: {zoomFactor}";
                Console.WriteLine(errorMessage);
                return;
            }

            foreach (Point2D point in points)
            {
                point.X *= zoomFactor;
                point.Y *= zoomFactor;
            }
        }


        public override void Draw(PaintEventArgs e)
        {
            if (points.Length < 3)
                return;

            PointF[] shapePoints = new PointF[points.Length];
            for (int i = 0; i < points.Length; i++)
            {
                shapePoints[i] = new PointF((float)points[i].X, (float)points[i].Y);
            }

            Pen pen = new Pen(StrokeColor, StrokeWidth);
            Pen penSelected = new Pen(selectedColor, selectedWidth);
            
            e.Graphics.DrawPolygon(selected ? penSelected : pen, shapePoints);

            if (FillColor != Color.Transparent)
            {
                SolidBrush brush = new SolidBrush(FillColor);
                e.Graphics.FillPolygon(brush, shapePoints);
            }

            if (selected)
            {
                for (int i = 0; i < points.Length; i++)
                {
                    int markerX = (int)points[i].X;
                    int markerY = (int)points[i].Y;
                    e.Graphics.DrawEllipse(penSelected, markerX - markerSize, markerY - markerSize, 2 * markerSize, 2 * markerSize);
                }
            }
        }


        public override void MouseMoveTo(double newX, double newY)
        {
            Move(newX + clickdX - points[0].X, newY + clickdY - points[0].Y);
        }


        public override void StartMouseMove(double mouseX, double mouseY)
        {
            clickdX = points[0].X - mouseX;
            clickdY = points[0].Y - mouseY;
        }


        public override void StopMouseMove(object sender, MouseEventArgs e)
        {
            clickdX = 0;
            clickdY = 0;
        }


        protected bool PointOverLine(double x, double y, double px, double py, double qx, double qy, int tolerancePixels)
        {
            double k;
            if ((((px <= qx) && ((px - tolerancePixels) <= x) && (x <= (qx + tolerancePixels)))
                 ||
                 ((qx < px) && ((qx - tolerancePixels) <= x) && (x <= (px + tolerancePixels))))
                &&
               (((py <= qy) && ((py - tolerancePixels) <= y) && (y <= (qy + tolerancePixels)))
                 ||
                 ((qy < py) && ((qy - tolerancePixels) <= y) && (y <= (py + tolerancePixels)))))
            {
            if (Math.Abs(qx - px) > EPSILON)
                {
                k = (qy - py) * 1.0 
                        ((qx - px) * 1.0);
                k = Math.Abs(k * x - y + py - k * px) / Math.Pow(1.0 + k * k, 0.5);
                return (tolerancePixels >= k);
                }
            else
                {
                return (tolerancePixels >= Math.Abs(x - px));
                }
            }
            else
                return false;
        }


        public override bool MouseHover(double mouseX, double mouseY)
        {
            for (int i = 0; i < points.Length; i++)
                if (PointOverLine(
                        mouseX, mouseY, 
                        points[i].X, points[i].Y, 
                        points[(i + 1) % points.Length].X, points[(i + 1) % points.Length].Y, clickTolerance)
                    )
                    return true;

            return false;
        }


        public override void Select()
        {
            selected = true;
        }


        public override void Deselect()
        {
            selected = false;
        }


        protected double TriangleArea(double a, double b, double c)
        {
            if ((a < b + c) && (b < a + c) && (c < a + b))
            {
                double p = (a + b + c) / 2;
                double S = Math.Sqrt(p * (p - a)
                                       * (p - b)
                                       * (p - c));
                return S;
            }
            else
            {
                string errorMessage = $"ERROR: A triangle cannot be constructed: {a}, {b}, {c}.";
                Console.WriteLine(errorMessage);
                return -1;
            }
        }

        protected override double Distance(PointD p1, PointD p2)
        {
            return Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2) + Math.Pow(p1.Z - p2.Z, 2));
        }
        
        public override double GetPerimeter()
        {
            double result = 0;
            for (int i = 0; i < points.Length; i++)
            {
                result += Distance(points[i], points[(i + 1) % points.Length]);
            }
            return result;
        }

        public override double GetArea()
        {
            double result = 0;
            int n_1 = points.Length - 1;
            for (int i = 0; i < points.Length; i++)
            {
                int ip1 = (i == n_1) ? 0  : i + 1; 
                int im1 = (i == 0  ) ? n_1: i - 1; 
                result += points[i].X * (points[ip1].Y - points[im1].Y);
            }
            return 0.5 * Math.Abs(result);
        }

        public override string ToString() {
            List<string> strPoints = new List<string>();
            foreach (Point2D point in points) {
                strPoints.Add(point.ToString());
            }

            string[] fields =
            {
                $"{GetType().Name}",
                $"Points: {String.Join(", ", strPoints)}",
                $"Area: {GetArea():0.###}",
                $"Perimeter: {GetPerimeter():0.###}"
            }; 
            return String.Join(delimeter, fields);
        }

        public override PointD this[int index]
        {
            set
            {
                if (0 <= index && index < points.Length)
                {
                    points[index].X = value.X;
                    points[index].Y = value.Y;
                    points[index].Z = value.Z;
                }
                else
                {
                    string errorMessage = $"ERROR: Index must be in range [0; {points.Length}): {index}";
                    Console.WriteLine(errorMessage);
                }
            }
            get
            {
                if (0 <= index && index < points.Length)
                {
                    return points[index];
                }
                else
                {
                    string errorMessage = $"ERROR: Index must be in range [0; {points.Length}): {index}";
                    Console.WriteLine(errorMessage);
                    return null; 
                }
            }
        }
    }
}

