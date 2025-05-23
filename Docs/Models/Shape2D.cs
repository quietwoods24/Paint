﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
// Added manually for Drawing
using System.Drawing;
using System.Windows.Forms;

namespace Paint
{
    public class Shape2D: Shape
    {
        public double averageX;
        public double averageY;
        public float currPhi = 0;
        public Shape2D()
        {
            // https://stackoverflow.com/questions/13947997/how-to-deserialize-class-without-calling-a-constructor
            // For correct deserialization of JSON
            // Do nothing
        }


        public Shape2D(params Point2D[] shapePoints) {

            // Checking for the number of points < 3
            if (shapePoints.Length < 3)
            {
                string errorMessage = $"ERROR: Points count < 3: {shapePoints.Length}";
                Console.WriteLine(errorMessage);
                // throw new ArgumentOutOfRangeException(errorMessage);
                return;
            }

            // Check for point matching
            for (int i = 0; i < shapePoints.Length - 1; i++)
                for (int j = i + 1; j < shapePoints.Length; j++)
                    if (Math.Abs(shapePoints[i].X - shapePoints[j].X) < EPSILON &&
                        Math.Abs(shapePoints[i].Y - shapePoints[j].Y) < EPSILON)
                    {
                        string errorMessage = $"ERROR: point[{i}] == point[{j}]: {shapePoints[i].ToString()} == {shapePoints[j].ToString()}";
                        Console.WriteLine(errorMessage);
                        // throw new Exception(errorMessage);
                        return;
                    }

            // We do not check for overlapping pages. We allow the following option

            // We do not check whether all three points lie on the same line. We allow this option

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
                // throw new ArgumentOutOfRangeException(errorMessage);
                return;
            }

            foreach (Point2D point in points)
            {
                point.X *= zoomFactor;
                point.Y *= zoomFactor;
            }
        }

        public override void Rotation(float phi) {


            //https://uk.wikipedia.org/wiki/wiki/Обертання_(математика)
            // Rotation angle must be not 0 (so we don't need to rotate)
            if (phi != 0)
            {
                float new_phi = phi - currPhi;

                currPhi = phi;

                double SumX = 0;
                double SumY = 0;

                for (int i = 0; i < points.Length; i++) { 
                    SumX += points[i].X;
                    SumY += points[i].Y;
                }

                double average_x = SumX / points.Length;
                double average_y = SumY / points.Length;
                double Rot_Coord_X = average_x;
                double Rot_Coord_Y = average_y;

                //double Rot_Coord_X = points[0].X;
                //double Rot_Coord_Y = points[0].Y;

                // Go through all points of a figure and recalculate them
                // according to the new angle

                for (int i = 0; i < points.Length; i++)
                {
                    // Calculate distance from point of rotation
                    // to the rotating point at X and Y 
                    double P_X = points[i].X - Rot_Coord_X;
                    double P_Y = points[i].Y - Rot_Coord_Y;

                    // Using formula for rotation recalculate new "rotated"
                    // coordinates X and Y

                    // Math.Cos() and Math.Sin() uses radians
                    points[i].X = Rot_Coord_X + P_X * Math.Cos(Math.PI * new_phi / 180.0) - P_Y * Math.Sin(Math.PI * new_phi / 180.0);
                    points[i].Y = Rot_Coord_Y + P_X * Math.Sin(Math.PI * new_phi / 180.0) + P_Y * Math.Cos(Math.PI * new_phi / 180.0);
                }
                rotationAngle = currPhi;
            }
            

        }



        public override void Draw(PaintEventArgs e)
        {            
            if (points.Length < 3)
                return;

            

            // https://learn.microsoft.com/en-us/dotnet/api/system.drawing.pointf
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
            
            e.Graphics.DrawPolygon(selected ? penSelected : pen, shapePoints);

            // Fill the polygon
            if (FillColor != Color.Transparent)
            {
                // Create a pen
                SolidBrush brush = new SolidBrush(FillColor);
                e.Graphics.FillPolygon(brush, shapePoints);
            }

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


        public override void MouseMoveTo(double newX, double newY)
        {
            double SumX = 0;
            double SumY = 0;

            for (int i = 0; i < points.Length; i++)
            {
                SumX += points[i].X;
                SumY += points[i].Y;
            }

            double average_x = SumX / points.Length;
            double average_y = SumY / points.Length;

            Move(newX + clickdX - average_x, newY + clickdY - average_y);
        }


        public override void StartMouseMove(double mouseX, double mouseY)
        {
            double SumX = 0;
            double SumY = 0;

            for (int i = 0; i < points.Length; i++)
            {
                SumX += points[i].X;
                SumY += points[i].Y;
            }

            double average_x = SumX / points.Length;
            double average_y = SumY / points.Length;

            clickdX = average_x - mouseX;
            clickdY = average_y - mouseY;
        }


        public override void StopMouseMove(object sender, MouseEventArgs e)
        {
            clickdX = 0;
            clickdY = 0;
        }


        // Returns true if the point (x, y) is on the line (px, py)---(qx,qy) +/- pixels of tolerance
        protected bool PointOverLine(double x, double y, double px, double py, double qx, double qy, int tolerancePixels)
        {
            double k;
            // Check if the point falls within the rectangle (px, py)-(qx,qy) +/- neighborhood
            if ((((px <= qx) && ((px - tolerancePixels) <= x) && (x <= (qx + tolerancePixels)))
                 ||
                 ((qx < px) && ((qx - tolerancePixels) <= x) && (x <= (px + tolerancePixels))))
                &&
               (((py <= qy) && ((py - tolerancePixels) <= y) && (y <= (qy + tolerancePixels)))
                 ||
                 ((qy < py) && ((qy - tolerancePixels) <= y) && (y <= (py + tolerancePixels)))))
            {
            // if the line is inclined or horizontal, then...
            if (Math.Abs(qx - px) > EPSILON)
                {
                // calculate the angular coefficient of the line for the equation y = kx + b
                k = (qy - py) * 1.0 / ((qx - px) * 1.0);
                // calculate the distance from the point to the line (save to the same variable k)
                k = Math.Abs(k * x - y + py - k * px) / Math.Pow(1.0 + k * k, 0.5);
                // if the distance to the segment is less than tolerancePixels, then...
                return (tolerancePixels >= k);
                }
            // otherwise - if the line is vertical, then...
            else
                {
                // if the distance to the segment is less than tolerancePixels, then...
                return (tolerancePixels >= Math.Abs(x - px));
                }
            }
            else
                return false;
        }


        // Checks if the click hit the Shape
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
                // Half-perimeter
                double p = (a + b + c) / 2;
                // Geron's formula
                double S = Math.Sqrt(p * (p - a)
                                       * (p - b)
                                       * (p - c));
                return S;
            }
            else
            {
                string errorMessage = $"ERROR: A triangle cannot be constructed: {a}, {b}, {c}.";
                Console.WriteLine(errorMessage);
                //throw new Exception(errorMessage);
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
                // (i+1) % N - for the case of a loop => the first point is connected to the last
                result += Distance(points[i], points[(i + 1) % points.Length]);
            }
            return result;
        }

        // https://en.wikipedia.org/wiki/Shoelace_formula#Other_formulas_2
        public override double GetArea()
        {
            double result = 0;
            int n_1 = points.Length - 1;
            for (int i = 0; i < points.Length; i++)
            {
                // Calculate separately for i=0 and i=n
                int ip1 = (i == n_1) ? 0  : i + 1; // ip1 = i plus  1 = i + 1
                int im1 = (i == 0  ) ? n_1: i - 1; // im1 = i minus 1 = i - 1
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
                $"Perimeter: {GetPerimeter():0.###}",
                $"Stroke color: {StrokeColor}",
                $"Fill color: {FillColor}",
                $"Stroke width: {StrokeWidth:0.###}"
            }; //,
            //    $"Stroke color: {StrokeColor}",
            //    $"Fill color: {FillColor}",
            //    $"Stroke width: {StrokeWidth:0.###}"
            //};
            return String.Join(delimeter, fields);
        }

        // Indexer 
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
                    // throw new ArgumentOutOfRangeException(errorMessage);
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
                    // throw new ArgumentOutOfRangeException(errorMessage);
                    return null; // new Point2D(0, 0);
                }
            }
        }
    }
}

