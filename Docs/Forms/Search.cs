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

            if (CurrImage != null) {
                string strcolor = "Black";
                string fillcolor = "Transparent";
                if (StrColListView.SelectedItems.Count > 0) {
                    strcolor = StrColListView.SelectedItems[0].Text.Trim();
                }
                if (FilColListView.SelectedItems.Count > 0)
                {
                    fillcolor = FilColListView.SelectedItems[0].Text.Trim();
                }

                List<Shape> result = CurrImage.Find(
                    NameComboBox.Text.Trim(),
                    strcolor,
                    fillcolor);
                listBox_search.DataSource = result;
            }
            // nothingFoundLabel.Visible = result.Count = 0;
            
        }

        private void Search_Load(object sender, EventArgs e)
        {

        }
    }
}
