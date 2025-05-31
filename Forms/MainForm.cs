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
                    CurrImage.Save(saveFileDialog.FileName);
                }
            }
        }        


        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            CurrImage?.KeyDown(sender, e, checkBoxInsideImage.Checked);

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
            AddTriangle();
            panelDraw.Refresh();
            panelDraw.Focus();
        }


        private void button_Reg_Pentagon_Click(object sender, EventArgs e)
        {
            AddPentagon();
            panelDraw.Refresh();
            panelDraw.Focus();
        }


        private void button_Reg_Hexagon_Click(object sender, EventArgs e)
        {
            AddHexagon();
            panelDraw.Refresh();
            panelDraw.Focus();
        }


        private void button_Square_Click(object sender, EventArgs e)
        {
            AddSquare();
            panelDraw.Refresh();
            panelDraw.Focus();
        }


        private void button_Rectangle_Click(object sender, EventArgs e)
        {
            AddRectangle();
            panelDraw.Refresh();
            panelDraw.Focus();
        }

        private void button_Circle_Click(object sender, EventArgs e)
        {
            AddCircle();
            panelDraw.Refresh();
            panelDraw.Focus();
        }

        private void button_Line_Click(object sender, EventArgs e)
        {
            AddLine();
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
            AddTriangle();
            panelDraw.Refresh();
        }

        private void toolStripMenuItemPentagon_Click(object sender, EventArgs e)
        {
            AddPentagon();
            panelDraw.Refresh();
        }

        private void toolStripMenuItemHexagon_Click(object sender, EventArgs e)
        {
            AddHexagon();
            panelDraw.Refresh();
        }

        private void toolStripMenuItemSquare_Click(object sender, EventArgs e)
        {
            AddSquare();
            panelDraw.Refresh();
        }

        private void toolStripMenuItemRectangle_Click(object sender, EventArgs e)
        {
            AddRectangle();
            panelDraw.Refresh();
        }

        private void toolStripMenuItemCircle_Click(object sender, EventArgs e)
        {
            AddCircle();
            panelDraw.Refresh();
        }

        private void ToolStripMenuItemline_Click(object sender, EventArgs e)
        {
            AddLine();
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

        private void AddTriangle()
        {
            if (CurrImage == null)
            {
                _ = MessageBox.Show("There is no image. To add figure you must firstly create image.");
                return;
            }
            int phi = (int)numericUpDownAngle.Value;

            var regularPolygon = new RegularPolygon(3, 40, 0, 60, 60);
            regularPolygon.RotationAngle = phi;
            regularPolygon.StrokeColor = strokeColor;
            regularPolygon.FillColor = fillColor;
            regularPolygon.StrokeWidth = strokeWidth;
            CurrImage.Add(regularPolygon);
        }

        private void AddPentagon()
        {
            if (CurrImage == null)
            {
                _ = MessageBox.Show("There is no image. To add figure you must firstly create image.");
                return;
            }

            int phi = (int)numericUpDownAngle.Value;

            var regularPolygon = new RegularPolygon(5, 40, 0, 60, 60);
            regularPolygon.RotationAngle = phi;
            regularPolygon.StrokeColor = strokeColor;
            regularPolygon.FillColor = fillColor;
            regularPolygon.StrokeWidth = strokeWidth;
            CurrImage.Add(regularPolygon);
        }

        private void AddHexagon()
        {
            if (CurrImage == null)
            {
                _ = MessageBox.Show("There is no image. To add figure you must firstly create image.");
                return;
            }

            int phi = (int)numericUpDownAngle.Value;

            var regularPolygon = new RegularPolygon(6, 40, 0, 60, 60);
            regularPolygon.RotationAngle = phi;
            regularPolygon.StrokeColor = strokeColor;
            regularPolygon.FillColor = fillColor;
            regularPolygon.StrokeWidth = strokeWidth;
            CurrImage.Add(regularPolygon);
        }

        private void AddSquare()
        {
            if (CurrImage == null)
            {
                _ = MessageBox.Show("There is no image. To add figure you must firstly create image.");
                return;
            }

            int phi = (int)numericUpDownAngle.Value;

            Random rnd = new Random();

            var regularPolygon = new RegularPolygon(4, 40, 0, 60, 60);
            regularPolygon.RotationAngle = phi;
            regularPolygon.StrokeColor = strokeColor;
            regularPolygon.FillColor = fillColor;
            regularPolygon.StrokeWidth = strokeWidth;
            CurrImage.Add(regularPolygon);
        }

        private void AddRectangle()
        {
            if (CurrImage == null)
            {
                _ = MessageBox.Show("There is no image. To add figure you must firstly create image.");
                return;
            }

            int phi = (int)numericUpDownAngle.Value;

            var rectangle = new RectangleMy(60, 60, 100, 200);
            rectangle.RotationAngle = phi;
            rectangle.StrokeColor = strokeColor;
            rectangle.FillColor = fillColor;
            rectangle.StrokeWidth = strokeWidth;
            CurrImage.Add(rectangle);
        }

        private void AddCircle()
        {
            if (CurrImage == null)
            {
                _ = MessageBox.Show("There is no image. To add figure you must firstly create image.");
                return;
            }

            var circle = new Circle(40, 60, 60);
            circle.StrokeColor = strokeColor;
            circle.FillColor = fillColor;
            circle.StrokeWidth = strokeWidth;
            CurrImage.Add(circle);
        }

        private void AddLine()
        {
            if (CurrImage == null)
            {
                _ = MessageBox.Show("There is no image. To add line you must firstly create image.");
                return;
            }

            int w = (int)CurrImage.Width / 2;

            Random rnd = new Random();

            var line = new Line(200, 200, rnd.Next(w), rnd.Next(w));
            line.StrokeColor = strokeColor;
            line.FillColor = fillColor;
            line.StrokeWidth = strokeWidth;
            CurrImage.Add(line);
        }
    }
}
