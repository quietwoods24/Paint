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
            this.AcceptButton = null;
        }

        private void Log(string message)
        {
            if (message == null)
                return;
            // https://stackoverflow.com/questions/485196/autoscrolling-a-listbox-under-a-certain-situation
        }

        private void buttonNew_Click(object sender, EventArgs e)
        {
            CurrImage = new Image(197, 77, 600, 500);
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


        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            CurrImage?.KeyDown(sender, e, checkBoxInsideImage.Checked);

            Log(CurrImage?.SelectedShape?.ToString());
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


        private void panelDraw_MouseMove(object sender, MouseEventArgs e)
        {
            bool shapeMoved = false;

            panelDraw.Cursor = CurrImage?.MouseMove(sender, e, out shapeMoved);

            if (shapeMoved == true)
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


        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrImage = new Image(10, 10, 600, 500);
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
            panelDraw.Focus();
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
                CurrImage.SolidBrushFrame = new SolidBrush(((Button)sender).BackColor);
            }
            panelDraw.Refresh();
            panelDraw.Focus();
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
            panelDraw.Focus();
        }


        private void button_Reg_Triangle_Click(object sender, EventArgs e)
        {
            if (CurrImage == null)
            {
                _ = MessageBox.Show("There is no image. To add figure you must firstly create image.");
                return;
            }
            int phi = (int)numericUpDownAngle.Value;
            int w = (int)CurrImage.Width;
            int h = (int)CurrImage.Height;

            Random rnd = new Random();

            var regularPolygon = new RegularPolygon(3, rnd.Next(h / 3), 0, rnd.Next(w), rnd.Next(h));
            regularPolygon.RotationAngle = phi;
            regularPolygon.StrokeColor = strokeColor;
            regularPolygon.FillColor = fillColor;
            regularPolygon.StrokeWidth = strokeWidth;
            CurrImage.Add(regularPolygon);
            panelDraw.Refresh();
            panelDraw.Focus();
        }


        private void button_Reg_Pentagon_Click(object sender, EventArgs e)
        {
            if (CurrImage == null)
            {
                _ = MessageBox.Show("There is no image. To add figure you must firstly create image.");
                return;
            }

            int phi = (int)numericUpDownAngle.Value;
            int w = (int)CurrImage.Width;
            int h = (int)CurrImage.Height;

            Random rnd = new Random();

            var regularPolygon = new RegularPolygon(5, rnd.Next(h / 3), 0, rnd.Next(w), rnd.Next(h));
            regularPolygon.RotationAngle = phi;
            regularPolygon.StrokeColor = strokeColor;
            regularPolygon.FillColor = fillColor;
            regularPolygon.StrokeWidth = strokeWidth;
            CurrImage.Add(regularPolygon);
            panelDraw.Refresh();
            panelDraw.Focus();
        }


        private void button_Reg_Hexagon_Click(object sender, EventArgs e)
        {
            if (CurrImage == null)
            {
                _ = MessageBox.Show("There is no image. To add figure you must firstly create image.");
                return;
            }

            int phi = (int)numericUpDownAngle.Value;
            int w = (int)CurrImage.Width;
            int h = (int)CurrImage.Height;

            Random rnd = new Random();

            var regularPolygon = new RegularPolygon(6, rnd.Next(h / 3), 0, rnd.Next(w), rnd.Next(h));
            regularPolygon.RotationAngle = phi;
            regularPolygon.StrokeColor = strokeColor;
            regularPolygon.FillColor = fillColor;
            regularPolygon.StrokeWidth = strokeWidth;
            CurrImage.Add(regularPolygon);
            panelDraw.Refresh();
            panelDraw.Focus();
        }


        private void button_Square_Click(object sender, EventArgs e)
        {
            if (CurrImage == null)
            {
                _ = MessageBox.Show("There is no image. To add figure you must firstly create image.");
                return;
            }

            int phi = (int)numericUpDownAngle.Value;
            int w = (int)CurrImage.Width;
            int h = (int)CurrImage.Height;

            Random rnd = new Random();

            var regularPolygon = new RegularPolygon(4, rnd.Next(h / 3), 0, rnd.Next(w), rnd.Next(h));
            regularPolygon.RotationAngle = phi;
            regularPolygon.StrokeColor = strokeColor;
            regularPolygon.FillColor = fillColor;
            regularPolygon.StrokeWidth = strokeWidth;
            CurrImage.Add(regularPolygon);
            panelDraw.Refresh();
            panelDraw.Focus();
        }


        private void button_Rectangle_Click(object sender, EventArgs e)
        {
            if (CurrImage == null)
            {
                _ = MessageBox.Show("There is no image. To add figure you must firstly create image.");
                return;
            }

            int phi = (int)numericUpDownAngle.Value;
            int w = (int)CurrImage.Width / 2;
            int h = (int)CurrImage.Height / 2;

            Random rnd = new Random();

            var rectangle = new RectangleMy(rnd.Next(w), rnd.Next(h), rnd.Next(w), rnd.Next(w));
            rectangle.RotationAngle = phi;
            rectangle.StrokeColor = strokeColor;
            rectangle.FillColor = fillColor;
            rectangle.StrokeWidth = strokeWidth;
            CurrImage.Add(rectangle);
            panelDraw.Refresh();
            panelDraw.Focus();
        }


        private void button_Circle_Click(object sender, EventArgs e)
        {
            if (CurrImage == null)
            {
                _ = MessageBox.Show("There is no image. To add figure you must firstly create image.");
                return;
            }

            int w = (int)CurrImage.Width / 2;
            int h = (int)CurrImage.Height / 2;

            Random rnd = new Random();

            var circle = new Circle(rnd.Next(w), rnd.Next(h), rnd.Next(w));
            circle.StrokeColor = strokeColor;
            circle.FillColor = fillColor;
            circle.StrokeWidth = strokeWidth;
            CurrImage.Add(circle);
            panelDraw.Refresh();
            panelDraw.Focus();
        }


        private void numericUpDownAngle_ValueChanged(object sender, EventArgs e)
        {
            int phi = (int)numericUpDownAngle.Value;

            if (CurrImage != null)
            {
                if (CurrImage.selectedShape != null)
                {
                    CurrImage.selectedShape.RotationAngle = phi;
                    panelDraw.Refresh();
                }
            }

        }


        private void button_Line_Click(object sender, EventArgs e)
        {
            if (CurrImage == null)
            {
                _ = MessageBox.Show("There is no image. To add line you must firstly create image.");
                return;
            }

            int phi = (int)numericUpDownAngle.Value;
            int w = (int)CurrImage.Width / 2;
            int h = (int)CurrImage.Height / 2;

            Random rnd = new Random();

            var line = new Line(rnd.Next(h), rnd.Next(h), rnd.Next(w), rnd.Next(w));
            line.RotationAngle = phi;
            line.StrokeColor = strokeColor;
            line.FillColor = fillColor;
            line.StrokeWidth = strokeWidth;
            CurrImage.Add(line);
            panelDraw.Refresh();
            panelDraw.Focus();
        }


        private void numericUpDownImgAngle_ValueChanged(object sender, EventArgs e)
        {
            int phi = (int)numericUpDownImgAngle.Value;

            if (CurrImage != null)
            {
                CurrImage.ImgRotationAngle = phi;                
            }
            panelDraw.Refresh();
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            Search h = new Search(CurrImage);
            h.Show();
        }

        private void HelpButton_Click(object sender, EventArgs e)
        {
            Help h = new Help();
            h.Show();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            About h = new About();
            h.Show();
        }

        private void toolStripMenuItemTriangle_Click(object sender, EventArgs e)
        {
            if (CurrImage == null)
            {
                _ = MessageBox.Show("There is no image. To add figure you must firstly create image.");
                return;
            }
            int phi = (int)numericUpDownAngle.Value;
            int w = (int)CurrImage.Width;
            int h = (int)CurrImage.Height;

            Random rnd = new Random();

            var regularPolygon = new RegularPolygon(3, rnd.Next(h / 3), 0, rnd.Next(w), rnd.Next(h));
            regularPolygon.RotationAngle = phi;
            regularPolygon.StrokeColor = strokeColor;
            regularPolygon.FillColor = fillColor;
            regularPolygon.StrokeWidth = strokeWidth;
            CurrImage.Add(regularPolygon);
            panelDraw.Refresh();
        }

        private void toolStripMenuItemPentagon_Click(object sender, EventArgs e)
        {
            if (CurrImage == null)
            {
                _ = MessageBox.Show("There is no image. To add figure you must firstly create image.");
                return;
            }

            int phi = (int)numericUpDownAngle.Value;
            int w = (int)CurrImage.Width;
            int h = (int)CurrImage.Height;

            Random rnd = new Random();

            var regularPolygon = new RegularPolygon(5, rnd.Next(h / 3), 0, rnd.Next(w), rnd.Next(h));
            regularPolygon.RotationAngle = phi;
            regularPolygon.StrokeColor = strokeColor;
            regularPolygon.FillColor = fillColor;
            regularPolygon.StrokeWidth = strokeWidth;
            CurrImage.Add(regularPolygon);
            panelDraw.Refresh();
        }

        private void toolStripMenuItemHexagon_Click(object sender, EventArgs e)
        {
            if (CurrImage == null)
            {
                _ = MessageBox.Show("There is no image. To add figure you must firstly create image.");
                return;
            }

            int phi = (int)numericUpDownAngle.Value;
            int w = (int)CurrImage.Width;
            int h = (int)CurrImage.Height;

            Random rnd = new Random();

            var regularPolygon = new RegularPolygon(6, rnd.Next(h / 3), 0, rnd.Next(w), rnd.Next(h));
            regularPolygon.RotationAngle = phi;
            regularPolygon.StrokeColor = strokeColor;
            regularPolygon.FillColor = fillColor;
            regularPolygon.StrokeWidth = strokeWidth;
            CurrImage.Add(regularPolygon);
            panelDraw.Refresh();
        }

        private void toolStripMenuItemSquare_Click(object sender, EventArgs e)
        {
            if (CurrImage == null)
            {
                _ = MessageBox.Show("There is no image. To add figure you must firstly create image.");
                return;
            }

            int phi = (int)numericUpDownAngle.Value;
            int w = (int)CurrImage.Width;
            int h = (int)CurrImage.Height;

            Random rnd = new Random();

            var regularPolygon = new RegularPolygon(4, rnd.Next(h / 3), 0, rnd.Next(w), rnd.Next(h));
            regularPolygon.RotationAngle = phi;
            regularPolygon.StrokeColor = strokeColor;
            regularPolygon.FillColor = fillColor;
            regularPolygon.StrokeWidth = strokeWidth;
            CurrImage.Add(regularPolygon);
            panelDraw.Refresh();
        }

        private void toolStripMenuItemRectangle_Click(object sender, EventArgs e)
        {
            if (CurrImage == null)
            {
                _ = MessageBox.Show("There is no image. To add figure you must firstly create image.");
                return;
            }

            int phi = (int)numericUpDownAngle.Value;
            int w = (int)CurrImage.Width / 2;
            int h = (int)CurrImage.Height / 2;

            Random rnd = new Random();

            var rectangle = new RectangleMy(rnd.Next(w), rnd.Next(h), rnd.Next(w), rnd.Next(w));
            rectangle.RotationAngle = phi;
            rectangle.StrokeColor = strokeColor;
            rectangle.FillColor = fillColor;
            rectangle.StrokeWidth = strokeWidth;
            CurrImage.Add(rectangle);
            panelDraw.Refresh();
        }

        private void toolStripMenuItemCircle_Click(object sender, EventArgs e)
        {
            if (CurrImage == null)
            {
                _ = MessageBox.Show("There is no image. To add figure you must firstly create image.");
                return;
            }

            int w = (int)CurrImage.Width / 2;
            int h = (int)CurrImage.Height / 2;

            Random rnd = new Random();

            var circle = new Circle(rnd.Next(w), rnd.Next(h), rnd.Next(w));
            circle.StrokeColor = strokeColor;
            circle.FillColor = fillColor;
            circle.StrokeWidth = strokeWidth;
            CurrImage.Add(circle);
            panelDraw.Refresh();
        }

        private void ToolStripMenuItemline_Click(object sender, EventArgs e)
        {
            if (CurrImage == null)
            {
                _ = MessageBox.Show("There is no image. To add line you must firstly create image.");
                return;
            }

            int phi = (int)numericUpDownAngle.Value;
            int w = (int)CurrImage.Width / 2;
            int h = (int)CurrImage.Height / 2;

            Random rnd = new Random();

            var line = new Line(rnd.Next(h), rnd.Next(h), rnd.Next(w), rnd.Next(w));
            line.RotationAngle = phi;
            line.StrokeColor = strokeColor;
            line.FillColor = fillColor;
            line.StrokeWidth = strokeWidth;
            CurrImage.Add(line);
            panelDraw.Refresh();
        }

        private void toolStripMenuItemDelete_Click(object sender, EventArgs e)
        {
            CurrImage?.Remove(CurrImage.SelectedShape);
            panelDraw.Refresh();
        }

        private void numericUpDownAngle_Click(object sender, EventArgs e)
        {
            panelDraw.Focus();
        }

        private void numericUpDownImgAngle_Click(object sender, EventArgs e)
        {
            panelDraw.Focus();
        }
    }
}
