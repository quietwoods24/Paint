using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// Added manually for Drawing
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Paint
{
    public partial class MainForm : Form
    {
        private Image currImage = null;

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
            currImage = new Image(10, checkBoxDrawAxes.Checked ? 50 : 10, 600, 500);
            currImage.DrawAxes = checkBoxDrawAxes.Checked;
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
                    currImage = image;
                    panelDraw.Refresh();
                }
            }
        }

        // https://learn.microsoft.com/en-us/dotnet/api/system.windows.forms.savefiledialog?view=netframework-4.7.2
        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (currImage == null)
                return;

            using (saveFileDialog)
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    Log("Save: " + saveFileDialog.FileName);
                    currImage.Save(saveFileDialog.FileName);
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

                    currImage.Merge(image);

                    panelDraw.Refresh();
                }
            }
        }


        private void buttonAddFigure_Click(object sender, EventArgs e)
        {
            if (currImage == null)
                return;

            int n = (int)numUpDSideCount.Value;
            int w = (int)currImage.Width;
            int h = (int)currImage.Height;

            // Log("TEST: Message");
            // Polygon
            if (radioButton1.Checked)
            {
                Point2D[] points = TestCode.GenerateRandomShape(n, h);
                currImage.Add(new Polygon(points));
            }
            // FilledPolygon
            else if (radioButton2.Checked)
            {
                Point2D[] points = TestCode.GenerateRandomShape(n, h);
                currImage.Add(new FilledPolygon(Color.DarkGreen, points));
            }
            // RegularPolygon
            else if (radioButton3.Checked)
            {
                Random rnd = new Random();
                currImage.Add(new RegularPolygon(n, rnd.Next(h / 3), rnd.NextDouble(), rnd.Next(w), rnd.Next(h)));
            }
            // Pyramid
            else if (radioButton4.Checked)
            {
                Random rnd = new Random();
                int xCenter = rnd.Next(w);
                int yCenter = rnd.Next(h);
                Point2D[] points = TestCode.GenerateRandomShape(n, h, -1, xCenter, yCenter, true);
                Point3D vertex = new Point3D(xCenter, yCenter, rnd.Next(h / 2));
                currImage.Add(new Pyramid(vertex, points));
            }
            // Prism
            else if (radioButton5.Checked)
            {
                Random rnd = new Random();
                Point2D[] points = TestCode.GenerateRandomShape(n, h, -1, -1, -1, true);
                Point3D vertex = new Point3D(points[0].X, points[0].Y, rnd.Next(h / 2));
                currImage.Add(new Prism(vertex, points));
            }
            else if (radioButton6.Checked)
            {
                TestCode.TestInWinForms(currImage);
            }

            Log(currImage.ToString());

            // Forcibly redrawing the picture
            panelDraw.Refresh();
        }


        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            // Log($"{e.KeyValue}  {e.KeyCode}  {e.KeyData}");

            currImage?.KeyDown(sender, e, checkBoxInsideImage.Checked);

            // Testing Shape.ToString()
            Log(currImage?.SelectedShape?.ToString());
            // Testing Indexer
            Log("Indexer:" + currImage?.SelectedShape?[0]?.ToString());

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
            currImage?.Draw(e);
        }


        private void panelDraw_MouseClick(object sender, MouseEventArgs e)
        {

            // Testing Shape.ToString()
            Log(currImage?.SelectedShape?.ToString());
            // Testing Clicked
            Log($"  Mouse: ({e.X}, {e.Y})  MouseHover: {currImage?.SelectedShape?.MouseHover(e.X - currImage.X, e.Y - currImage.Y)}");
        }


        private void panelDraw_MouseMove(object sender, MouseEventArgs e)
        {
            panelDraw.Cursor = currImage?.MouseMove(sender, e);

            panelDraw.Refresh();
        }


        private void panelDraw_MouseDown(object sender, MouseEventArgs e)
        {
            currImage?.MouseDown(sender, e);

            panelDraw.Refresh();
        }


        private void panelDraw_MouseUp(object sender, MouseEventArgs e)
        {
            currImage?.MouseUp(sender, e);
        }

        private void panelDraw_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Log(currImage?.ToString());
        }

        private void checkBoxDrawAxes_CheckedChanged(object sender, EventArgs e)
        {
            if (currImage == null)
                return;

            currImage.DrawAxes = checkBoxDrawAxes.Checked;
            panelDraw.Refresh();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currImage = new Image(10, checkBoxDrawAxes.Checked ? 50 : 10, 600, 500);
            currImage.DrawAxes = checkBoxDrawAxes.Checked;
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
                    currImage = image;
                    panelDraw.Refresh();
                }
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currImage == null)
                return;

            using (saveFileDialog)
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    Log("Save: " + saveFileDialog.FileName);
                    currImage.Save(saveFileDialog.FileName);
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
                        if (currImage == null)
                            return;

                        using (saveFileDialog)
                        {
                            if (saveFileDialog.ShowDialog() == DialogResult.OK)
                            {
                                Log("Save: " + saveFileDialog.FileName);
                                currImage.Save(saveFileDialog.FileName);
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

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Progtam made by quietwoods", "About");
        }

        private void contentsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
