using System;
// Added manually for Drawing
using System.Drawing;
using System.Windows.Forms;

namespace Paint
{
    public partial class MainForm : Form
    {
        private const int IMAGE_WIDTH = 600;
        private const int IMAGE_HEIGHT = 500;
        private const int IMAGE_MARGIN = 5;
        public Image CurrImage = null;

        private Color strokeColor = Color.Black;
        private Color fillColor = Color.Transparent;
        private int strokeWidth = 2;

        public MainForm()
        {
            InitializeComponent();
            this.AcceptButton = null;

            // Creates Image by default;
            New_Click(null, new EventArgs());
        }
        

        private bool SaveImageResult(object sender, EventArgs e)
        {
            if (CurrImage?.Changed == true) {
                // https://learn.microsoft.com/en-us/dotnet/api/system.windows.forms.messageboxicon
                // https://learn.microsoft.com/en-us/dotnet/api/system.windows.forms.messageboxbuttons
                var result = MessageBox.Show("This image contains unsaved changes. Do you want to save it?",
                                             "Save?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                switch (result)
                {
                    case DialogResult.Yes:
                    {
                        Save_Click(sender, e);
                        return true;
                    }

                    case DialogResult.No:
                    {
                        return true;
                    }

                    case DialogResult.Cancel:
                    {
                        return false;
                    }
                }
            }

            return true;
        }
        
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = !SaveImageResult(sender, e);
        }

        private void New_Click(object sender, EventArgs e)
        {
            if (SaveImageResult(sender, e))
            {
                int x = panelControls.ClientRectangle.X + panelControls.ClientRectangle.Width + IMAGE_MARGIN;
                int y = panelMenu.ClientRectangle.Y + panelMenu.ClientRectangle.Height + IMAGE_MARGIN;
                CurrImage = new Image(x, y, IMAGE_WIDTH, IMAGE_HEIGHT);
                CurrImage.SelectedShapeChanged += Listener;
                panelDraw.Refresh();
            }
        }

        private void Open_Click(object sender, EventArgs e)
        {
            if (SaveImageResult(sender, e))
                // https://learn.microsoft.com/en-us/dotnet/api/system.windows.forms.openfiledialog?view=netframework-4.7.2
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

        private void Save_Click(object sender, EventArgs e)
        {
            // https://learn.microsoft.com/en-us/dotnet/api/system.windows.forms.savefiledialog
            using (saveFileDialog)
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    CurrImage.Save(saveFileDialog.FileName);
                }
            }
        }



        private void ToolStripMenuItemExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ToolStripMenuItemAbout_Click(object sender, EventArgs e)
        {
            About h = new About();
            h.Show();
        }

        private void ToolStripMenuItemDelete_Click(object sender, EventArgs e)
        {
            CurrImage?.Remove(CurrImage.SelectedShape);
            panelDraw.Refresh();
        }



        private void Search_Click(object sender, EventArgs e)
        {
            Search h = new Search(CurrImage);
            h.Show();
        }

        private void Help_Click(object sender, EventArgs e)
        {
            Help h = new Help();
            h.Show();
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
                     
        private void listViewStrokeWidth_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((sender as ListView).SelectedIndices.Count < 1)
                return;
                

            int i = (sender as ListView).SelectedIndices[0];

            switch (i)
            {
                case 0:
                    strokeWidth = 2;
                    break;
                case 1:
                    strokeWidth = 3;
                    break;
                case 2:
                    strokeWidth = 6;
                    break;
                case 3:
                    strokeWidth = 8;
                    break;
                default:
                    strokeWidth = 2;
                    break;
            }

            if (CurrImage != null)
                if (CurrImage.selectedShape != null)
                    CurrImage.selectedShape.StrokeWidth = strokeWidth;

            panelDraw.Refresh();
            panelDraw.Focus();
        }



        private void CurrFillColor_Click(object sender, EventArgs e)
        {
            if (CurrImage != null)
            {
                CurrImage.FillColor = ((Button)sender).BackColor;
                CurrImage.BackgroundColor = new SolidBrush(((Button)sender).BackColor);
                
            }
            panelDraw.Refresh();
            panelDraw.Focus();
        }

        private void AssignColor_MouseDown(object sender, MouseEventArgs e)
        {    
            if (e.Button == MouseButtons.Right)
            {
                strokeColor = ((Button)sender).BackColor;

                if (CurrImage != null)
                    if (CurrImage.selectedShape != null)
                        CurrImage.selectedShape.StrokeColor = strokeColor;
            }
            else if (e.Button == MouseButtons.Left)
            {
                fillColor = ((Button)sender).BackColor;

                if (CurrImage != null)
                    if (CurrImage.selectedShape != null)
                        CurrImage.selectedShape.FillColor = fillColor;
            }            
            
            SetButtonColor(buttonCurrStrokeColor, strokeColor);
            SetButtonColor(buttonCurrFillColor, fillColor);
            panelDraw.Refresh();
        }

        private void SetButtonColor(Button buttonColor, Color color) {
            if (color == Color.Transparent) { 
                buttonColor.BackColor = Color.Transparent;
                buttonColor.BackgroundImage = buttonTransparent.BackgroundImage;
            }
            else
            {
                buttonColor.BackColor = color;
                buttonColor.BackgroundImage = null;
            }
        }

        private void Listener(Shape shape)
        {
            if (shape == null)
                return;

            SetButtonColor(buttonCurrStrokeColor, shape.StrokeColor);
            SetButtonColor(buttonCurrFillColor, shape.FillColor);

            int itemIndex = -1;
            switch (shape.StrokeWidth)
            {
                case 2:
                    itemIndex = 0;
                    break;
                case 3:
                    itemIndex = 1;
                    break;
                case 6:
                    itemIndex = 2;
                    break;
                case 8:
                    itemIndex = 3;
                    break;
                default:
                    strokeWidth = -1;
                    break;
            }
            if (0 <= itemIndex && itemIndex < listViewStrokeWidth.Items.Count)
                listViewStrokeWidth.Items[itemIndex].Selected = true;
        }



        private void AddFigure_Click(object sender, EventArgs e)
        {
            AddFigure(sender);
        }

        private void AddFigure(object sender) {
            if (CurrImage == null)
            {
                _ = MessageBox.Show("There is no image. To add figure you must firstly create image.");
                return;
            }


            int phi = (int)numericUpDownAngle.Value;
            int sidecount = Convert.ToInt32((sender as Button).Tag);

            var figure = new Shape2D();
            if (1003 <= sidecount && sidecount <= 1006)
                figure = new RegularPolygon(sidecount % 10, 40, phi, 60, 60);
            if (sidecount / 100 == 4)
                figure = new RectangleMy(60, 60, 100, 200);
            if (sidecount / 100 == 9)
                figure = new Circle(40, 60, 60);
            if (sidecount / 100 == 2)
                figure = new Line(200, 200, 400, 400);

            figure.StrokeColor = strokeColor;
            figure.FillColor = fillColor;
            figure.StrokeWidth = strokeWidth;
            CurrImage.Add(figure);
            panelDraw.Refresh();
            panelDraw.Focus();
        }



        private void numericUpDownAngle_ValueChanged(object sender, EventArgs e)
        {
            int phi = (int)numericUpDownAngle.Value;

            if (CurrImage != null)
            {
                if (CurrImage.selectedShape != null && CurrImage.selectedShape is RegularPolygon)
                {
                    (CurrImage.selectedShape as RegularPolygon).Alpha = phi;
                    panelDraw.Refresh();
                }
            }

        }

        private void numericUpDownAngle_Click(object sender, EventArgs e)
        {
            panelDraw.Focus();
        }
                        


        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            CurrImage?.KeyDown(sender, e, checkBoxInsideImage.Checked);

            // Force redraw Image
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

    }
}
