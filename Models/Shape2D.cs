using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Added manually for Drawing
using System.Drawing;
using System.Windows.Forms;

namespace Paint
{
    //Shape2D is a class that inherits Shape and implements all its basic properties and methods.
    //It is the basis for all 2D shapes that stand on the Point2D array of points.


    public class Shape2D : Shape
    {
        public Shape2D()
        {
            // https://stackoverflow.com/questions/13947997/how-to-deserialize-class-without-calling-a-constructor
            // For correct deserialization of JSON
            // Do nothing
        }


        public Shape2D(params Point2D[] shapePoints)
        {

            //// Checking for the number of Points < 3
            //if (shapePoints.Length < 3)
            //{
            //    string errorMessage = $"ERROR: Points count < 3: {shapePoints.Length}";
            //    Console.WriteLine(errorMessage);
            //    // throw new ArgumentOutOfRangeException(errorMessage);
            //    return;
            //}

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

            // We do not check whether all three Points lie on the same line. We allow this option

            Points = new Point2D[shapePoints.Length];
            for (int i = 0; i < shapePoints.Length; i++)
            {
                Points[i] = new Point2D(shapePoints[i].X, shapePoints[i].Y);
            }
        }


        public override void Move(double xOffset, double yOffset)
        {
            foreach (Point2D point in Points)
            {
                point.X += xOffset;
                point.Y += yOffset;
            }
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

            foreach (Point2D point in Points)
            {
                point.X *= zoomX;
                point.Y *= zoomX;
            }
        }


        public override void Draw(PaintEventArgs e)
        {
            //if (Points.Length < 3)
            //    return;

            // https://learn.microsoft.com/en-us/dotnet/api/system.drawing.pointf
            PointF[] shapePoints = new PointF[Points.Length];

            // Copy the array of Points Point2D to the array of Points PointF
            for (int i = 0; i < Points.Length; i++)
            {
                shapePoints[i] = new PointF((float)Points[i].X, (float)Points[i].Y);
            }

            // Draw a polygon stroke
            // Create a pen
            Pen pen = new Pen(StrokeColor, StrokeWidth);
            pen.DashCap = System.Drawing.Drawing2D.DashCap.Round;
            pen.LineJoin = System.Drawing.Drawing2D.LineJoin.Round;
            Pen penSelected = new Pen(selectedColor, selectedWidth);
            penSelected.DashCap = System.Drawing.Drawing2D.DashCap.Round;
            penSelected.LineJoin = System.Drawing.Drawing2D.LineJoin.Round;

            // Fill the polygon
            if (FillColor != Color.Transparent)
            {
                // Create a brush
                SolidBrush brush = new SolidBrush(FillColor);
                e.Graphics.FillPolygon(brush, shapePoints);
            }

            e.Graphics.DrawPolygon(pen, shapePoints);
            if (selected)
            {
                // https://learn.microsoft.com/en-us/dotnet/api/system.drawing.pen.dashstyle
                penSelected.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
                e.Graphics.DrawPolygon(penSelected, shapePoints);
                penSelected.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            }

            // Draw markers
            if (selected)
            {
                for (int i = 0; i < Points.Length; i++)
                {
                    int markerX = (int)Points[i].X;
                    int markerY = (int)Points[i].Y;

                    e.Graphics.DrawEllipse(penSelected, markerX - markerSize, markerY - markerSize, 2 * markerSize, 2 * markerSize);
                }

                if (this is RegularPolygon) {
                    float centerx = (float)(this as RegularPolygon).X - markerSize;
                    float centerY = (float)(this as RegularPolygon).Y - markerSize;
                    e.Graphics.DrawEllipse(penSelected, centerx, centerY, 2 * markerSize, 2 * markerSize);
                }
                if (this is Line) {
                    penSelected.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
                    e.Graphics.DrawEllipse(penSelected, (int)Points[1].X - clickTolerance, (int)Points[1].Y - clickTolerance, clickTolerance * 2, clickTolerance * 2);
                }
            }
        }


        public override void MouseMoveTo(double newX, double newY)
        {            
            Move(newX + clickdX - Points[0].X, newY + clickdY - Points[0].Y);
        }


        public override void StartMouseMove(double mouseX, double mouseY)
        {            
            clickdX = Points[0].X - mouseX;
            clickdY = Points[0].Y - mouseY;
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
            for (int i = 0; i < Points.Length; i++)
                if (PointOverLine(
                        mouseX, mouseY,
                        Points[i].X, Points[i].Y,
                        Points[(i + 1) % Points.Length].X, Points[(i + 1) % Points.Length].Y, clickTolerance)
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


        protected override double Distance(PointD p1, PointD p2)
        {
            return Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2) + Math.Pow(p1.Z - p2.Z, 2));
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
                $"Points: {String.Join(", ", strPoints)}",
                $"Stroke color: {StrokeColor}",
                $"Fill color: {FillColor}",
                $"Stroke width: {StrokeWidth:0.###}"
            }; 
            return String.Join(delimeter, fields);
        }


        // Indexer 
        public override PointD this[int index]
        {
            set
            {
                if (0 <= index && index < Points.Length)
                {
                    Points[index].X = value.X;
                    Points[index].Y = value.Y;
                    Points[index].Z = value.Z;
                }
                else
                {
                    string errorMessage = $"ERROR: Index must be in range [0; {Points.Length}): {index}";
                    Console.WriteLine(errorMessage);
                    // throw new ArgumentOutOfRangeException(errorMessage);
                }
            }
            get
            {
                if (0 <= index && index < Points.Length)
                {
                    return Points[index];
                }
                else
                {
                    string errorMessage = $"ERROR: Index must be in range [0; {Points.Length}): {index}";
                    Console.WriteLine(errorMessage);
                    // throw new ArgumentOutOfRangeException(errorMessage);
                    return null; // new Point2D(0, 0);
                }
            }
        }
    }
}

