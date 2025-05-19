using System;
// Added manually for Drawing
using System.Drawing;
using System.Windows.Forms;

namespace Paint
{
    public partial class MainForm : Form
    {
        public Image CurrImage = null;

        private Color strokeColor = Color.Black;
        private Color fillColor = Color.Transparent;
        private float strokeWidth = 2.0F;
        public MainForm()
        {
            InitializeComponent();
        }


        private void Log(string message)
        {
            if (message == null)
                return;

            //listboxLog.Items.Add(message);

            //// https://stackoverflow.com/questions/485196/autoscrolling-a-listbox-under-a-certain-situation
            //// Scroll to the last one
            //listboxLog.SelectedIndex = listboxLog.Items.Count - 1;
            //listboxLog.SelectedIndex = -1;
        }


        private void buttonNew_Click(object sender, EventArgs e)
        {
            CurrImage = new Image(197, checkBoxDrawAxes.Checked ? 127 : 77, 600, 500);
            CurrImage.DrawAxes = checkBoxDrawAxes.Checked;
            panelDraw.Refresh();
        }


        // https://learn.microsoft.com/en-us/dotnet/api/system.windows.forms.openfiledialog?view=netframework-4.7.2
        private void buttonOpen_Click(object sender, EventArgs e)
        {
            using (openFileDialog)
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var image = new Image(0, 0, 50, 50);
                    Log("Open: " + openFileDialog.FileName);
                    image.Load(openFileDialog.FileName);
                    CurrImage = image;
                    panelDraw.Refresh();
                }
            }
        }

        // https://learn.microsoft.com/en-us/dotnet/api/system.windows.forms.savefiledialog?view=netframework-4.7.2
        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (CurrImage == null)
                return;

            using (saveFileDialog)
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    Log("Save: " + saveFileDialog.FileName);
                    CurrImage.Save(saveFileDialog.FileName);
                }
            }
        }


        private void buttonMerge_Click(object sender, EventArgs e)
        {
            using (openFileDialog)
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var image = new Image(0, 0, 10, 10);
                    Log("Merge: " + openFileDialog.FileName);
                    image.Load(openFileDialog.FileName);

                    CurrImage.Merge(image);

                    panelDraw.Refresh();
                }
            }
        }


        private void buttonAddFigure_Click(object sender, EventArgs e)
        {
            if (CurrImage == null)
                return;

            int n = (int)numUpDSideCount.Value;
            int w = (int)CurrImage.Width;
            int h = (int)CurrImage.Height;

            // Log("TEST: Message");
            // Polygon
            if (radioButton1.Checked)
            {
                Point2D[] points = TestCode.GenerateRandomShape(n, h);
                var polygon = new Polygon(points);
                polygon.StrokeColor = strokeColor;
                polygon.FillColor = fillColor;
                polygon.StrokeWidth = strokeWidth;
                CurrImage.Add(polygon);
            }
            // FilledPolygon
            else if (radioButton2.Checked)
            {
                Point2D[] points = TestCode.GenerateRandomShape(n, h);

                var filledPolygon = new FilledPolygon(Color.DarkGreen, points);
                filledPolygon.StrokeColor = strokeColor;
                filledPolygon.FillColor = fillColor;
                filledPolygon.StrokeWidth = strokeWidth;
                CurrImage.Add(filledPolygon);
            }
            // RegularPolygon
            else if (radioButton3.Checked)
            {
                Random rnd = new Random();

                var regularPolygon = new RegularPolygon(n, rnd.Next(h / 3), rnd.NextDouble(), rnd.Next(w), rnd.Next(h));
                regularPolygon.StrokeColor = strokeColor;
                regularPolygon.FillColor = fillColor;
                regularPolygon.StrokeWidth = strokeWidth;
                CurrImage.Add(regularPolygon);
            }
            // Pyramid
            else if (radioButton4.Checked)
            {
                Random rnd = new Random();
                int xCenter = rnd.Next(w);
                int yCenter = rnd.Next(h);
                Point2D[] points = TestCode.GenerateRandomShape(n, h, -1, xCenter, yCenter, true);
                Point3D vertex = new Point3D(xCenter, yCenter, rnd.Next(h / 2));
                var pyramid = new Pyramid(vertex, points);
                pyramid.StrokeColor = strokeColor;
                pyramid.FillColor = fillColor;
                pyramid.StrokeWidth = strokeWidth;
                CurrImage.Add(pyramid);
            }
            // Prism
            else if (radioButton5.Checked)
            {
                Random rnd = new Random();
                Point2D[] points = TestCode.GenerateRandomShape(n, h, -1, -1, -1, true);
                Point3D vertex = new Point3D(points[0].X, points[0].Y, rnd.Next(h / 2));
                var prism = new Prism(vertex, points);
                prism.StrokeColor = strokeColor;
                prism.FillColor = fillColor;
                prism.StrokeWidth = strokeWidth;
                CurrImage.Add(prism);
            }
            else if (radioButton6.Checked)
            {
                TestCode.TestInWinForms(CurrImage);
            }

            

            Log(CurrImage.ToString());

            // Forcibly redrawing the picture
            panelDraw.Refresh();
        }


        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            // Log($"{e.KeyValue}  {e.KeyCode}  {e.KeyData}");

            CurrImage?.KeyDown(sender, e, checkBoxInsideImage.Checked);

            // Testing Shape.ToString()
            Log(CurrImage?.SelectedShape?.ToString());
            // Testing Indexer
            Log("Indexer:" + CurrImage?.SelectedShape?[0]?.ToString());

            // Force redraw currImage
            panelDraw.Refresh();
        }


        // https://stackoverflow.com/questions/1646998/up-down-left-and-right-arrow-keys-do-not-trigger-keydown-event
        // https://learn.microsoft.com/en-us/dotnet/api/system.windows.forms.control.previewkeydown
        private void MainForm_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                case Keys.Right:
                case Keys.Down:
                case Keys.Up:
                    e.IsInputKey = true;
                    break;
            }
        }


        private void panelDraw_Paint(object sender, PaintEventArgs e)
        {
            CurrImage?.Draw(e);
        }


        private void panelDraw_MouseClick(object sender, MouseEventArgs e)
        {

            // Testing Shape.ToString()
            Log(CurrImage?.SelectedShape?.ToString());
            // Testing Clicked
            Log($"  Mouse: ({e.X}, {e.Y})  MouseHover: {CurrImage?.SelectedShape?.MouseHover(e.X - CurrImage.X, e.Y - CurrImage.Y)}");
        }


        private void panelDraw_MouseMove(object sender, MouseEventArgs e)
        {
            panelDraw.Cursor = CurrImage?.MouseMove(sender, e);

            panelDraw.Refresh();
        }


        private void panelDraw_MouseDown(object sender, MouseEventArgs e)
        {
            CurrImage?.MouseDown(sender, e);

            panelDraw.Refresh();
        }


        private void panelDraw_MouseUp(object sender, MouseEventArgs e)
        {
            CurrImage?.MouseUp(sender, e);
        }

        private void panelDraw_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Log(CurrImage?.ToString());
        }

        private void checkBoxDrawAxes_CheckedChanged(object sender, EventArgs e)
        {
            //if (currImage == null)
            //    return;

            //currImage.DrawAxes = checkBoxDrawAxes.Checked;
            //panelDraw.Refresh();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrImage = new Image(10, checkBoxDrawAxes.Checked ? 50 : 10, 600, 500);
            CurrImage.DrawAxes = checkBoxDrawAxes.Checked;
            panelDraw.Refresh();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (openFileDialog)
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var image = new Image(0, 0, 50, 50);
                    Log("Open: " + openFileDialog.FileName);
                    image.Load(openFileDialog.FileName);
                    CurrImage = image;
                    panelDraw.Refresh();
                }
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CurrImage == null)
                return;

            using (saveFileDialog)
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    Log("Save: " + saveFileDialog.FileName);
                    CurrImage.Save(saveFileDialog.FileName);
                }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            var result = MessageBox.Show("Do you want to save data?", "", MessageBoxButtons.YesNoCancel);
            switch (result)
            {
                case DialogResult.Yes:
                    {
                        if (CurrImage == null)
                            return;

                        using (saveFileDialog)
                        {
                            if (saveFileDialog.ShowDialog() == DialogResult.OK)
                            {
                                Log("Save: " + saveFileDialog.FileName);
                                CurrImage.Save(saveFileDialog.FileName);
                            }
                        }
                        // save data here
                        break;
                    }
                case DialogResult.No:
                    break;
                case DialogResult.Cancel:
                    e.Cancel = true;
                    break;
            }
        }



        private void listView1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if ((sender as ListView).SelectedIndices.Count < 1)
                return;
                

            int i = (sender as ListView).SelectedIndices[0];

            switch (i)
            {
                case 0:
                    strokeWidth = 2.0F;
                    break;
                case 1:
                    strokeWidth = 3.0F;
                    break;
                case 2:
                    strokeWidth = 6.0F;
                    break;
                case 3:
                    strokeWidth = 8.0F;
                    break;
                default:
                    strokeWidth = 2.0F;
                    break;
            }

            if (CurrImage != null)
                if (CurrImage.selectedShape != null)
                    CurrImage.selectedShape.StrokeWidth = strokeWidth;

            panelDraw.Refresh();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Progtam made by quietwoods", "About");
        }

        private void contentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Help h = new Help();
            h.Show();
        }

        private void button23_MouseDown(object sender, MouseEventArgs e)
        {
            

            if (e.Button == MouseButtons.Left)
            {
                strokeColor = ((Button)sender).BackColor;

                if (CurrImage != null)
                    if (CurrImage.selectedShape != null)
                        CurrImage.selectedShape.StrokeColor = strokeColor;
            }
            else if (e.Button == MouseButtons.Right)
            {
                fillColor = ((Button)sender).BackColor;

                if (CurrImage != null)
                    if (CurrImage.selectedShape != null)
                        CurrImage.selectedShape.FillColor = fillColor;
            }

            button_CurrStrokeColor.BackColor = strokeColor;
            button_CurrFillColor.BackColor = fillColor;

            panelDraw.Refresh();
        }

        private void button27_Click(object sender, EventArgs e)
        {
            if (CurrImage != null) { 
                CurrImage.FillColor = ((Button)sender).BackColor;
                CurrImage.solidBrushFrame = new SolidBrush(((Button)sender).BackColor);
            }
            panelDraw.Refresh();
        }

        private void button26_Click(object sender, EventArgs e)
        {
            
        }

        private void customizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Search h = new Search(CurrImage);
            h.Show();
        }

        private void button26_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                strokeColor = Color.Transparent;

                if (CurrImage != null)
                    if (CurrImage.selectedShape != null)
                        CurrImage.selectedShape.StrokeColor = strokeColor;
            }
            else if (e.Button == MouseButtons.Right)
            {
                fillColor = Color.Transparent;

                if (CurrImage != null)
                    if (CurrImage.selectedShape != null)
                        CurrImage.selectedShape.FillColor = fillColor;
            }

            button_CurrStrokeColor.BackColor = strokeColor;
            button_CurrFillColor.BackColor = fillColor;

            panelDraw.Refresh();
        }
    }
}
