using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using Newtonsoft.Json;

namespace Paint
{

    public class Image
    {
        protected const string delimeter = " | ";
        protected Pen penFrame;
        protected List<Shape> shapes;


        private Shape selectedShape = null;
        [JsonIgnore]
        public Shape SelectedShape
        {
            set
            {
                if (value == selectedShape)
                    return;

                if (selectedShape != null)
                {
                    selectedShape.Deselect();
                }

                selectedShape = value;

                if (selectedShape != null)
                    selectedShape.Select();
            }

            get { return selectedShape; }
        }

        [JsonIgnore]
        public bool DrawAxes { set; get; } = false;

        public double X { set; get; }
        public double Y { set; get; }
        public double Width { set; get; }
        public double Height { set; get; }

        public Image(double x, double y, double width, double height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
            shapes = new List<Shape>();

            penFrame = new Pen(Color.Black, 1);
        }


        public void Merge(Image image)
        {
            if (image == null)
            {
                string errorMessage = $"ERROR: Image is null";
                Console.WriteLine(errorMessage);
                return;
            }

            Width = Math.Max(Width, image.Width);
            Height = Math.Max(Height, image.Height);

            SelectedShape = null;
            if (image != null && image.Count > 0)
            {
                for (int i = 0; i < image.Count; i++)
                    shapes.Add(image[i]);
            }
        }


        public void Add(Shape shape)
        {
            if (shape == null)
            {
                string errorMessage = $"ERROR: Shape is null";
                Console.WriteLine(errorMessage);
                return;
            }

            SelectedShape = null;
            if (shape != null && !shapes.Contains(shape))
                shapes.Add(shape);
        }


        public void Remove(Shape shape)
        {
            if (shape == null)
            {
                string errorMessage = $"ERROR: Shape is null";
                Console.WriteLine(errorMessage);
                return;
            }

            SelectedShape = null;
            shapes.Remove(shape);
        }


        public void Move(double xOffset, double yOffset)
        {
            X += xOffset;
            Y += yOffset;
        }


        public void MoveInside(double xOffset, double yOffset)
        {
            if (SelectedShape != null)
                SelectedShape.Move(xOffset, yOffset);
            else
                foreach (Shape shape in shapes)
                    shape.Move(xOffset, yOffset);
        }


        public void Zoom(double zoomFactor)
        {
            if (zoomFactor <= 0)
            {
                string errorMessage = $"ERROR: Zoom factor must be > 0: {zoomFactor}";
                Console.WriteLine(errorMessage);
                return;
            }

            Width *= zoomFactor;
            Height *= zoomFactor;

            foreach (Shape shape in shapes)
                shape.Zoom(zoomFactor);
        }


        public void ZoomInside(double zoomFactor)
        {
            if (zoomFactor <= 0)
            {
                string errorMessage = $"ERROR: Zoom factor must be > 0: {zoomFactor}";
                Console.WriteLine(errorMessage);
                return;
            }

            if (SelectedShape != null)
                SelectedShape.Zoom(zoomFactor);
            else
                foreach (Shape shape in shapes)
                    shape.Zoom(zoomFactor);
        }


        public void Draw(PaintEventArgs e)
        {
            Rectangle frame = new Rectangle((int)X - 1, (int)Y - 1, (int)(Width + 1), (int)(Height + 1));
            e.Graphics.DrawRectangle(penFrame, frame);

            if (DrawAxes)
            {
                int dxy = 10;
                int dz = (int)Math.Min(100, 2 * Y);
                int xO = (int)X;
                int yO = (int)Y;
                int xOX = (int)(X + Width);
                int yOX = yO;
                int xOY = xO;
                int yOY = (int)(Y + Height);
                int xOZ = (int)(X + Pyramid.XCabinetProjection(new Point3D(0, 0, dz)));
                int yOZ = (int)(Y + Pyramid.YCabinetProjection(new Point3D(0, 0, dz)));
                Pen penAxes = new Pen(Color.Black, 3);
                e.Graphics.DrawLine(penAxes, xO, yO, xOX, yOX);
                e.Graphics.DrawLine(penAxes, xO, yO, xOY, yOY);
                e.Graphics.DrawLine(penAxes, xO, yO, xOZ, yOZ);

                Font drawFont = new Font("Arial", 10);
                SolidBrush drawBrush = new SolidBrush(Color.Black);
                StringFormat drawFormat = new StringFormat();
                drawFormat.FormatFlags = StringFormatFlags.DirectionRightToLeft;
                drawFormat.Alignment = StringAlignment.Center;
                drawFormat.LineAlignment = StringAlignment.Center;
                e.Graphics.DrawString("X", drawFont, drawBrush, xOX + dxy, yOX - dxy, drawFormat);
                e.Graphics.DrawString("Y", drawFont, drawBrush, xOY - dxy, yOY - dxy, drawFormat);
                e.Graphics.DrawString("Z", drawFont, drawBrush, xOZ - dxy, yOZ, drawFormat);
            }

            frame = new Rectangle((int)X, (int)Y, (int)Width, (int)Height);
            Region clipRegion = new Region(frame);
            e.Graphics.SetClip(clipRegion, CombineMode.Replace);

            e.Graphics.TranslateTransform((float)X, (float)Y);

            foreach (Shape shape in shapes)
                shape.Draw(e);
        }

        public Cursor MouseMove(object sender, MouseEventArgs e)
        {
            bool foundedClicked = false;

            if (e.Button == MouseButtons.Left && SelectedShape != null)
            {
                if (SelectedShape.MouseHover(e.X - X, e.Y - Y))
                    SelectedShape.MouseMoveTo(e.X - X, e.Y - Y);
            }
            else if (e.Button == MouseButtons.None)
            {
                foreach (Shape shape in shapes)
                    if (shape.MouseHover(e.X - X, e.Y - Y))
                    {
                        foundedClicked = true;
                        break;
                    }
            }

            if (foundedClicked)
                return Cursors.Hand;
            else
                return Cursors.Default;
        }


        public void MouseDown(object sender, MouseEventArgs e)
        {
            bool foundedClicked = false;
            if (e.Button == MouseButtons.Left)
            {
                foreach (Shape shape in shapes)
                {
                    if (shape.MouseHover(e.X - X, e.Y - Y))
                    {
                        SelectedShape = shape;
                        shape.StartMouseMove(e.X - X, e.Y - Y);
                        foundedClicked = true;
                        break;
                    }
                }

                if (!foundedClicked)
                    SelectedShape = null;
            }
        }


        public void MouseUp(object sender, MouseEventArgs e)
        {
            if (SelectedShape != null && e.Button == MouseButtons.Left)
                SelectedShape.StopMouseMove(sender, e);
        }


        public void KeyDown(object sender, KeyEventArgs e, bool insideImage)
        {
            const int dXY = 3;

            switch (e.KeyValue)
            {
                case 37: 
                    if (insideImage)
                        MoveInside(-dXY, 0);
                    else
                        Move(-dXY, 0);
                    break;

                case 39: 
                    if (insideImage)
                        MoveInside(+dXY, 0);
                    else
                        Move(+dXY, 0);
                    break;

                case 38:
                    if (insideImage)
                        MoveInside(0, -dXY);
                    else
                        Move(0, -dXY);
                    break;

                case 40:
                    if (insideImage)
                        MoveInside(0, +dXY);
                    else
                        Move(0, +dXY);
                    break;

                case 46:
                    Remove(SelectedShape);
                    break;

                case 107:
                    if (insideImage)
                        ZoomInside(1.1);
                    else
                        Zoom(1.1);
                    break;

                case 109:
                    if (insideImage)
                        ZoomInside(0.9);
                    else
                        Zoom(0.9);
                    break;

                default:
                    break;
            }
        }


        public void Save(string filePath)
        {
            SelectedShape = null;

            string directoryName = Path.GetDirectoryName(filePath);

            if (directoryName == "" || Directory.Exists(directoryName))
            {
                var polygons        = shapes.Where(s => s is Polygon       ).Cast<Polygon>();
                var filledPolygons  = shapes.Where(s => s is FilledPolygon ).Cast<FilledPolygon>();
                var regularPolygons = shapes.Where(s => s is RegularPolygon).Cast<RegularPolygon>();
                var pyramids        = shapes.Where(s => s is Pyramid && !(s is Prism)).Cast<Pyramid>();
                var prisms          = shapes.Where(s => s is Prism         ).Cast<Prism>();

                string[] lines =
                {
                    JsonConvert.SerializeObject(this),
                    JsonConvert.SerializeObject(polygons),
                    JsonConvert.SerializeObject(filledPolygons),
                    JsonConvert.SerializeObject(regularPolygons),
                    JsonConvert.SerializeObject(pyramids),
                    JsonConvert.SerializeObject(prisms)
                };
                File.WriteAllLines(filePath, lines);
            }
            else
            {
                string errorMessage = $"ERROR: Path does not exist: {directoryName}";
                Console.WriteLine(errorMessage);
            }
        }


        public void Load(string filePath)
        {
            SelectedShape = null;

            if (File.Exists(filePath))
            {
                try
                {
                    var lines = File.ReadAllLines(filePath);

                    var jsonIm = JsonConvert.DeserializeObject<Image>(lines[0]);
                    var jsonPo = JsonConvert.DeserializeObject<List<Polygon>>(lines[1]);
                    var jsonFP = JsonConvert.DeserializeObject<List<FilledPolygon>>(lines[2]);
                    var jsonRP = JsonConvert.DeserializeObject<List<RegularPolygon>>(lines[3]);
                    var jsonPy = JsonConvert.DeserializeObject<List<Pyramid>>(lines[4]);
                    var jsonPr = JsonConvert.DeserializeObject<List<Prism>>(lines[5]);
                    if (jsonIm != null)
                    {
                        this.X = jsonIm.X;
                        this.Y = jsonIm.Y;
                        this.Width = jsonIm.Width;
                        this.Height = jsonIm.Height;
                    }
                    if (jsonPo != null)
                        shapes.AddRange(jsonPo);
                    if (jsonFP != null)
                        shapes.AddRange(jsonFP);
                    if (jsonRP != null)
                        shapes.AddRange(jsonRP);
                    if (jsonPy != null)
                        shapes.AddRange(jsonPy);
                    if (jsonPr != null)
                        shapes.AddRange(jsonPr);
                }
                catch (Exception e)
                {
                    string errorMessage = $"ERROR: Wrong file format: {filePath}. {e}";
                    Console.WriteLine(errorMessage);
                }
            }
            else
            {
                string errorMessage = $"ERROR: File does not exist: {filePath}";
                Console.WriteLine(errorMessage);
            }
        }


        public override string ToString()
        {
            List<string> strShapes = new List<string>();
            foreach (Shape shape in shapes)
            {
                strShapes.Add(shape.ToString());
            }

            string[] fields =
            {
                $"{GetType().Name} ({X:0.###}, {Y:0.###}, {Width:0.###}, {Height:0.###})",
                $"Shapes: {String.Join(delimeter, strShapes)}"
            };

            return String.Join(delimeter, fields);
        }


        [JsonIgnore]
        public double Count { get { return shapes.Count; } }

        [JsonIgnore]
        public Shape this[int index]
        {
            get
            {
                if (0 <= index && index < shapes.Count)
                    return shapes[index];
                else
                {
                    string errorMessage = $"ERROR: Index must be in range [0; {shapes.Count}): {index}";
                    Console.WriteLine(errorMessage);
                    return null;
                }
            }
        }
    }
}
