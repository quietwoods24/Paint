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

    public class Pyramid : Shape2D
    {
        public Point3D Circle { set; get; }

        public Pyramid(Point3D vertex, params Point2D[] points) : base(points)
        {
            Circle = vertex;
        }


        // 2D Movement in the XY plane
        public override void Move(double xOffset, double yOffset)
        {
            // Move the base of the pyramid
            base.Move(xOffset, yOffset);

            // Move the top of the pyramid
            Circle.X += xOffset;
            Circle.Y += yOffset;
        }


        // 3D Zoom
        public override void Zoom(double zoomFactor)
        {
            if (zoomFactor <= 0)
            {
                string errorMessage = $"ERROR: Zoom factor must be > 0: {zoomFactor}";
                Console.WriteLine(errorMessage);
                // throw new ArgumentOutOfRangeException(errorMessage);
                return;
            }

            // Pyramid base re-design
            base.Zoom(zoomFactor);

            // Pyramid top re-size
            Circle.X *= zoomFactor;
            Circle.Y *= zoomFactor;
            Circle.Z *= zoomFactor;
        }

        /*
        https://en.wikipedia.org/wiki/Oblique_projection#Cabinet_projection
        Oblique frontal dimensional projection 
        

                          ^ Y 
                          | 
                          | 
                          | 
                        y +-----------+             
                         /|          /|
                        / |         / |
                       /_________  / P(x,y,z)
                      |   |       *   |  
                      |   o-------|---+---------> X
                      |  /        |  / x
                      | /         | /
                      |/__________|/
                    z /               X = x + 0.5 * z * cos(225)
                     /                Y = y + 0.5 * z * sin(225)
                    /
                   Z
                  

                                      x                  
                          o-----------+---------> X
                         /|           | 
                        / |           |
                     z /  |y          |
                      /|  +-----------+       
                     / | /|          /        
                    /  |/ |         /   X = x + 0.5 * z * cos(225)
                   /   +-----------*    Y = y - 0.5 * z * sin(225)  // "-" because OY is pointing downward.
                  /       |      P(x,y,z)       
                 /        |
                /         |
               Z          Y


                                 Z           
                                /
                               /            
                            z +-----------+
                             /|          /|
                            / |         / |
                           /  |      x /  |                
                          o———————————+—————————————> X
                          |   |_ _ _ _|_ _| 
                          |  /        |  / P(x,y,z)
                          | /         | /
                          |/          |/
                        y +———————————+       
                          |          
                          |            X = x + 0.5 * z * cos(-45)
                          Y            Y = y + 0.5 * z * sin(-45)
                           
                  
        */
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

            // Drawing the base of the pyramid
            base.Draw(e);


            // Drawing the edges of a pyramid
            // Create pen
            Pen pen = new Pen(StrokeColor, 1); // StrokeWidth
            Pen penSelected = new Pen(selectedColor, selectedWidth);

            float vertexX = (float)XCabinetProjection(Circle);
            float vertexY = (float)YCabinetProjection(Circle);

            for (int i = 0; i < points.Length; i++)
            {
                // https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics.drawline?view=netframework-4.7.2
                e.Graphics.DrawLine(selected ? penSelected : pen,
                    vertexX, vertexY,
                    (float)points[i].X, (float)points[i].Y);
            }

            // Draw a vertex marker
            e.Graphics.DrawEllipse(selected ? penSelected : pen, (int)vertexX - markerSize, (int)vertexY - markerSize, 2 * markerSize, 2 * markerSize);
        }


        public override double GetPerimeter()
        {
            // Perimeter of the base of the pyramid
            //double result = (new Shape2D(points)).GetPerimeter();
            double result = base.GetPerimeter();

            // Lengths of the edges of the pyramid
            for (int i = 0; i < points.Length; i++)
            {
                result += Distance(Circle, points[i]);
            }
            return result;
        }


        public override double GetArea()
        {
            // Area of the base of the pyramid
            //double result = (new Shape2D(points)).GetArea();
            double result = base.GetArea();

            // Area of the side faces of the pyramid
            for (int i = 0; i < points.Length; i++)
            {
                // (i+1) % N - for the case of a loop => the first point is connected to the last
                int j = (i + 1) % points.Length;
                double a = Distance(Circle, points[i]);
                double b = Distance(Circle, points[j]);
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
                $"Circle: {Circle.ToString()}"
            };
            return String.Join(delimeter, fields);
        }
    }


    public class Prism : Pyramid
    {
        public Prism(Point3D vertex, params Point2D[] points) : base(vertex, points)
        {
            // Do nothing
        }


        public override void Draw(PaintEventArgs e)
        {
            if (points.Length <= 0)
                return;

            // Drawing the bases of the prism
            PointF[] upperBasePoints = new PointF[points.Length];
            PointF[] lowerBasePoints = new PointF[points.Length];

            // Shift of the upper base relative to the lower base
            double dX = Circle.X - points[0].X;
            double dY = Circle.Y - points[0].Y;

            for (int i = 0; i < points.Length; i++)
            {
                // Copy the array of points Point2D to the array of points PointF
                lowerBasePoints[i] = new PointF((float)points[i].X, (float)points[i].Y);

                var iVertex = new Point3D(points[i].X + dX, points[i].Y + dY, Circle.Z);
                upperBasePoints[i] = new PointF((float)XCabinetProjection(iVertex), (float)YCabinetProjection(iVertex));
            }

            // Create a pen
            Pen pen = new Pen(StrokeColor, (float)StrokeWidth);
            Pen penSelected = new Pen(selectedColor, selectedWidth);

            // Drawing the lower base of the prism
            e.Graphics.DrawPolygon(selected ? penSelected : pen, lowerBasePoints);

            pen.Width = 1;
            // Drawing the lower base of the prism
            e.Graphics.DrawPolygon(selected ? penSelected : pen, upperBasePoints);

            // Drawing the edges of a prism
            for (int i = 0; i < points.Length; i++)
            {
                // https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics.drawline?view=netframework-4.7.2
                e.Graphics.DrawLine(selected ? penSelected : pen, lowerBasePoints[i], upperBasePoints[i]);

                // Draw the bottom base markers
                // https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics.drawellipse?view=netframework-4.8
                e.Graphics.DrawEllipse(selected ? penSelected : pen,
                    (int)lowerBasePoints[i].X - markerSize, (int)lowerBasePoints[i].Y - markerSize, 2 * markerSize, 2 * markerSize);
            }
            // Draw a vertex marker
            e.Graphics.DrawEllipse(selected ? penSelected : pen,
                (int)upperBasePoints[0].X - markerSize, (int)upperBasePoints[0].Y - markerSize, 2 * markerSize, 2 * markerSize);
        }


        public override double GetPerimeter()
        {
            // Perimeter of the prism bases
            double result = 2 * (new Shape2D(points)).GetPerimeter();
            // double result = 2 * ((Shape2D)this).GetPerimeter(); // NOT WORKING

            // Lengths of the prism edges
            result += points.Length * Distance(Circle, points[0]);

            return result;
        }


        public override double GetArea()
        {
            // Area of the prism bases
            double result = 2 * (new Shape2D(points)).GetArea();

            // Area of prism bases // Area of prism side faces
            // Offset of the top face relative to the base face (in 3D)
            double dX = Circle.X - points[0].X;
            double dY = Circle.Y - points[0].Y;
            for (int i = 0; i < points.Length; i++)
            {
                // (i+1) % N - for the case of a short circuit => the first point is connected to the last
                int j = (i + 1) % points.Length;
                double a = Distance(points[i], points[j]);
                double b = Distance(Circle, points[0]); // the length of the side edges is the same, can be removed from the cycle
                Point3D vertexPj = new Point3D(points[j].X + dX, points[j].Y + dY, Circle.Z);
                double d = Distance(points[i], vertexPj); // diagonal of the face
                result += 2 * TriangleArea(a, b, d);
            }
            return result;
        }
    }
}

