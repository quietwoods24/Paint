using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint
{
    public partial class Search : Form
    {
        public Image CurrImage = null;
        public Search(Image currImage)
        {
            InitializeComponent();
            CurrImage = currImage;
        }

        private void button_Find_Click(object sender, EventArgs e)
        {

            if (CurrImage != null)
            {
                Color strcolor = Color.Black;
                Color fillcolor = Color.Transparent;
                if (StrColListView.SelectedItems.Count > 0)
                {
                    strcolor = Color.FromName(StrColListView.SelectedItems[0].Text.Trim());
                }
                if (FilColListView.SelectedItems.Count > 0)
                {
                    fillcolor = Color.FromName(FilColListView.SelectedItems[0].Text.Trim());
                }

                List<Shape> result = CurrImage.Find(
                    NameComboBox.Text.Trim(),
                    strcolor,
                    fillcolor);
                if (NameComboBox.Text.Trim() == "" || strcolor == null || fillcolor == null)
                {
                    _ = MessageBox.Show("Fill at least figure name form");
                }
                else if (result.Count == 0)
                {
                    _ = MessageBox.Show("No figure whith such parameters found");
                }
                shapeBindingSource.DataSource = result;
            }
            else
                _ = MessageBox.Show("There is no image. To perform " + '"' + "Search" + '"' + "operation you must firstly create image and fill it with shapes.");
        }

    }
}
