using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Paint
{
    public static class TestCode
    {
        static public Point2D[] GenerateRandomShape(int n, double r, double phi = -1, double x = -1, double y = -1, bool regular = false)
        {
            // This is a test code, here without checking n, r, ...

            // https://learn.microsoft.com/en-us/dotnet/api/system.random.next
            // https://learn.microsoft.com/en-us/dotnet/api/system.random.nextdouble  [0; 1)
            Random rnd = new Random();
            Point2D[] Points = new Point2D[n];

            phi = (phi < 0) ? Math.PI * rnd.NextDouble() : phi;
            x = (x < 0) ? r * rnd.NextDouble() : x;
            y = (y < 0) ? r * rnd.NextDouble() : y;
            double R = r / 3 * rnd.NextDouble();
            for (int i = 0; i < n; i++)
            {
                double angle = phi + 2 * Math.PI * i / n + (regular ? 0 : Math.PI / n * rnd.NextDouble());
                R = regular ? R : r / 3 * rnd.NextDouble();
                Points[i] = new Point2D(
                    x + R * Math.Cos(angle),
                    y + R * Math.Sin(angle));
            }

            return Points;
        }


        static public void TestInWinForms(Image currImage)
        {
            double zf = 15;
            Shape shape = null;
            // Polygon - triangle  3x4x5. Area: 6; Perimeter: 12
            shape = new Polygon(new Point2D(0, 0), new Point2D(0, 3), new Point2D(4, 0));
            shape.Zoom(zf, 1, false); shape.Move(10, 10); currImage.Add(shape);
            // Polygon - parallelogram  3x5 . Area: 12; Perimeter: 16=3+3+5+5
            shape = new Polygon(new Point2D(0, 0), new Point2D(3, 4), new Point2D(6, 4), new Point2D(3, 0));
            shape.Zoom(zf, 1, false); shape.Move(110, 10); currImage.Add(shape);
            // Polygon - square    5x5 . Area: 25; Perimeter: 20
            shape = new Polygon(new Point2D(0, 0), new Point2D(4, 3), new Point2D(1, 7), new Point2D(-3, 4));
            shape.Zoom(zf, 1, false); shape.Move(210, 10); currImage.Add(shape);
            // Polygon - square    2x2 . Area: 4; Perimeter: 8
            shape = new Polygon(new Point2D(0, 0), new Point2D(0, 2), new Point2D(2, 2), new Point2D(2, 0));
            shape.Zoom(zf, 1, false); shape.Move(310, 10); currImage.Add(shape);

            //shape = new FilledPolygon(Color.Red, new Point2D(0, 0), new Point2D(0, 2), new Point2D(2, 2), new Point2D(2, 0));
            shape.Zoom(zf, 1, false); shape.Move(360, 10); currImage.Add(shape);


            // RegularPolygon - triangle  3x3x3. Area: 3.897; Perimeter: 9
            shape = new RegularPolygon(3, 3 / Math.Sqrt(3), 0, 1, 1);
            shape.Zoom(zf, 1, false); shape.Move(10, 110); currImage.Add(shape);
            shape = new RegularPolygon(3, 3 / Math.Sqrt(3), 0.5, 1, 1);
            shape.Zoom(zf, 1, false); shape.Move(110, 110); currImage.Add(shape);
            shape = new RegularPolygon(3, 3 / Math.Sqrt(3), 1.0, 1, 1);
            shape.Zoom(zf, 1, false); shape.Move(210, 110); currImage.Add(shape);
            // RegularPolygon - square    2x2 . Area: 4; Perimeter: 8
            shape = new RegularPolygon(4, Math.Sqrt(2), 0.5, 1, 1);
            shape.Zoom(zf, 1, false); shape.Move(310, 110); currImage.Add(shape);
            shape = new RegularPolygon(4, Math.Sqrt(2), 13, 1, 1);
            shape.Zoom(zf, 1, false); shape.Move(410, 110); currImage.Add(shape);
            shape = new RegularPolygon(4, Math.Sqrt(2), Math.PI / 4, 1, 1);
            shape.Zoom(zf, 1, false); shape.Move(510, 110); currImage.Add(shape);



        }

        static public void TestInConsole()
        {
            Console.WriteLine("\n\n\n=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
            Console.WriteLine("Testing Polygon");
            Shape shape = null;

            // Error: point count < 3
            shape = new Polygon();
            shape = new Polygon(new Point2D(0, 0));
            shape = new Polygon(new Point2D(0, 0), new Point2D(0, 2));
            // Error: same Points
            shape = new Polygon(new Point2D(0, 0), new Point2D(0, 0), new Point2D(0, 3), new Point2D(4, 0));
            shape = new Polygon(new Point2D(0, 0), new Point2D(0, 3), new Point2D(0, 3), new Point2D(4, 0));
            shape = new Polygon(new Point2D(0, 0), new Point2D(0, 3), new Point2D(4, 0), new Point2D(4, 0));

            // Polygon - triangle  3x4x5. Area: 6; Perimeter: 12
            shape = new Polygon(new Point2D(0, 0), new Point2D(0, 3), new Point2D(4, 0));
            Console.WriteLine(shape.ToString());
            // Polygon - parallelogram  3x5 . Area: 12; Perimeter: 16=3+3+5+5
            shape = new Polygon(new Point2D(0, 0), new Point2D(3, 4), new Point2D(6, 4), new Point2D(3, 0));
            Console.WriteLine(shape.ToString());
            // Polygon - square    5x5 . Area: 25; Perimeter: 20
            shape = new Polygon(new Point2D(0, 0), new Point2D(4, 3), new Point2D(1, 7), new Point2D(-3, 4));
            Console.WriteLine(shape.ToString());
            // Polygon - square    2x2 . Area: 4; Perimeter: 8
            shape = new Polygon(new Point2D(0, 0), new Point2D(0, 2), new Point2D(2, 2), new Point2D(2, 0));
            Console.WriteLine(shape.ToString());

            Console.WriteLine("\n\nTesting Shape Indexer");
            // Error: wrong index
            Console.WriteLine($"Shape point[{-10}]: {shape[-10]?.ToString()}");
            Console.WriteLine($"Shape point[{10}]: {shape[10]?.ToString()}");
            // OK
            Console.WriteLine($"Shape point[{1}]: {shape[1]?.ToString()}");

            Console.WriteLine("\n\nTesting Move/Zoom");
            // Error: wrong zoom factor
            shape.Zoom(-1, 1, false);
            shape.Zoom(0, 1, false);
            // OK
            shape.Zoom(1, 1, false);
            Console.WriteLine($"Shape point[{1}]: {shape[1]?.ToString()}");
            shape.Zoom(2, 1, false);
            Console.WriteLine($"Shape point[{1}]: {shape[1]?.ToString()}");
            shape.Move(0, 0);
            Console.WriteLine($"Shape point[{1}]: {shape[1]?.ToString()}");
            shape.Move(2, 2);
            Console.WriteLine($"Shape point[{1}]: {shape[1]?.ToString()}");
            shape.Move(-2, -2);
            Console.WriteLine($"Shape point[{1}]: {shape[1]?.ToString()}");



            Console.WriteLine("\n\n\n=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
            Console.WriteLine("Testing Regular Polygon");

            // Error: point count < 3
            shape = new RegularPolygon(-1, 10, 0, 100, 100);
            shape = new RegularPolygon(0, 10, 0, 100, 100);
            shape = new RegularPolygon(1, 10, 0, 100, 100);
            shape = new RegularPolygon(2, 10, 0, 100, 100);
            // Error: r < 0
            shape = new RegularPolygon(3, -10, 0, 100, 100);


            Console.WriteLine("\n\nRegularPolygon - triangle  3x3x3. Area: 3.897; Perimeter: 9");
            shape = new RegularPolygon(3, 3 / Math.Sqrt(3), 0, 10, 10);
            Console.WriteLine(shape.ToString());
            shape = new RegularPolygon(3, 3 / Math.Sqrt(3), 0.5, 100, 100);
            Console.WriteLine(shape.ToString());
            shape = new RegularPolygon(3, 3 / Math.Sqrt(3), 1.0, 200, 200);
            Console.WriteLine(shape.ToString());


            Console.WriteLine("\n\nRegularPolygon - square    2x2 . Area: 4; Perimeter: 8");
            shape = new RegularPolygon(4, Math.Sqrt(2), 0.5, 100, 100);
            Console.WriteLine(shape.ToString());
            shape = new RegularPolygon(4, Math.Sqrt(2), 13, 200, 200);
            Console.WriteLine(shape.ToString());
            shape = new RegularPolygon(4, Math.Sqrt(2), Math.PI / 4, 0, 0);
            Console.WriteLine(shape.ToString());
            Console.WriteLine("\n\n");


            Console.WriteLine("\n\nTesting Shape Indexer");
            // Error: wrong index
            Console.WriteLine($"Shape point[{-10}]: {shape[-10]?.ToString()}");
            Console.WriteLine($"Shape point[{10}]: {shape[10]?.ToString()}");
            // OK
            Console.WriteLine($"Shape point[{1}]: {shape[1]?.ToString()}");

            Console.WriteLine("\n\nTesting Move/Zoom");
            // Error: wrong zoom factor
            shape.Zoom(-1, 1, false);
            shape.Zoom(0, 1, false);
            // OK
            shape.Zoom(1, 1, false);
            Console.WriteLine($"Shape point[{0}]: {shape[0]?.ToString()}");
            shape.Zoom(2, 1, false);
            Console.WriteLine($"Shape point[{0}]: {shape[0]?.ToString()}");
            shape.Move(0, 0);
            Console.WriteLine($"Shape point[{0}]: {shape[0]?.ToString()}");
            shape.Move(2, 2);
            Console.WriteLine($"Shape point[{0}]: {shape[0]?.ToString()}");
            shape.Move(-2, -2);
            Console.WriteLine($"Shape point[{0}]: {shape[0]?.ToString()}");


            Console.WriteLine("\n\nTesting Shape Indexer");
            // Error: wrong index
            Console.WriteLine($"Shape point[{-10}]: {shape[-10]?.ToString()}");
            Console.WriteLine($"Shape point[{10}]: {shape[10]?.ToString()}");
            // OK
            Console.WriteLine($"Shape point[{1}]: {shape[1]?.ToString()}");

            Console.WriteLine("\n\nTesting Move/Zoom");
            // Error: wrong zoom factor
            shape.Zoom(-1, 1, false);
            shape.Zoom(0, 1, false);
            // OK
            shape.Zoom(1, 1, false);
            Console.WriteLine($"Shape point[{1}]: {shape[1]?.ToString()}");
            shape.Zoom(2, 1, false);
            Console.WriteLine($"Shape point[{1}]: {shape[1]?.ToString()}");
            shape.Move(0, 0);
            Console.WriteLine($"Shape point[{1}]: {shape[1]?.ToString()}");
            shape.Move(2, 2);
            Console.WriteLine($"Shape point[{1}]: {shape[1]?.ToString()}");
            shape.Move(-2, -2);
            Console.WriteLine($"Shape point[{1}]: {shape[1]?.ToString()}");


            Console.WriteLine("\n\nTesting Shape Indexer");
            // Error: wrong index
            Console.WriteLine($"Shape point[{-10}]: {shape[-10]?.ToString()}");
            Console.WriteLine($"Shape point[{10}]: {shape[10]?.ToString()}");
            // OK
            Console.WriteLine($"Shape point[{1}]: {shape[1]?.ToString()}");

            Console.WriteLine("\n\nTesting Move/Zoom");
            // Error: wrong zoom factor
            shape.Zoom(-1, 1, false);
            shape.Zoom(0, 1, false);
            // OK
            shape.Zoom(1, 1, false);
            Console.WriteLine($"Shape point[{1}]: {shape[1]?.ToString()}");
            shape.Zoom(2, 1, false);
            Console.WriteLine($"Shape point[{1}]: {shape[1]?.ToString()}");
            shape.Move(0, 0);
            Console.WriteLine($"Shape point[{1}]: {shape[1]?.ToString()}");
            shape.Move(2, 2);
            Console.WriteLine($"Shape point[{1}]: {shape[1]?.ToString()}");
            shape.Move(-2, -2);
            Console.WriteLine($"Shape point[{1}]: {shape[1]?.ToString()}");


            Console.WriteLine("\n\n\n=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
            Console.WriteLine("Testing Image Indexer");
            var img = new Image(0, 0, 100, 100);
            // Error: wrong index
            Console.WriteLine($"Image shape[{-10}]: {img[-10]?.ToString()}");
            Console.WriteLine($"Image shape[{10}]: {img[10]?.ToString()}");

            // OK
            img.Add(new RegularPolygon(3, 10, 0, 10, 10));
            img.Add(new RegularPolygon(5, 10, 0, 10, 10));
            Console.WriteLine($"Image shape[{1}]: {img[1]?.ToString()}");


            Console.WriteLine("\n\n\n=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
        }
    }
}
