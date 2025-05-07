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
            List<Shape> result = CurrImage.Find(
                NameBox.Text.Trim(),
                StrColBox.Text.Trim(),
                StrFillBox.Text.Trim());

            // nothingFoundLabel.Visible = result.Count = 0;
            listBox_search.DataSource = result;
        }

        private void Search_Load(object sender, EventArgs e)
        {

        }
    }
}
