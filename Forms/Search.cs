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
            comboBoxName.SelectedIndex = 0; // "Any"
            listViewStrokeColor.Items[0].Selected = true; // "Any"
            listViewFillColor.Items[0].Selected = true; // "Any"
        }

        private void buttonFind_Click(object sender, EventArgs e)
        {

            if (CurrImage == null)
            {
                // https://learn.microsoft.com/en-us/dotnet/api/system.windows.forms.messageboxicon
                // https://learn.microsoft.com/en-us/dotnet/api/system.windows.forms.messageboxbuttons
                _ = MessageBox.Show("There is no image. To perform \"Search\" operation you must firstly create image and fill it with shapes.",
                                        "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            string shapeName = "";
            Color strokeColor = Color.Empty;
            Color fillColor = Color.Empty;

            string selectedItem = comboBoxName.Text.Trim();
            if (selectedItem == "Any" || selectedItem == "")
                shapeName = "";
            else
                shapeName = selectedItem;

            if (listViewStrokeColor.SelectedItems.Count > 0)
            {

                selectedItem = listViewStrokeColor.SelectedItems[0].Text.Trim();
                if (selectedItem == "Any")
                    strokeColor = Color.Empty;
                else
                    strokeColor = Color.FromName(selectedItem);
            }

            if (listViewFillColor.SelectedItems.Count > 0)
            {
                selectedItem = listViewFillColor.SelectedItems[0].Text.Trim();
                if (selectedItem == "Any")
                    fillColor = Color.Empty;
                else
                    fillColor = Color.FromName(selectedItem);
            }

            List<Shape> result = CurrImage.Find(
                shapeName,
                strokeColor,
                fillColor);

            //if (comboBoxName.Text.Trim() == "" && strokeColor.IsEmpty && fillColor.IsEmpty)
            //{
            //    // https://learn.microsoft.com/en-us/dotnet/api/system.windows.forms.messageboxicon
            //    // https://learn.microsoft.com/en-us/dotnet/api/system.windows.forms.messageboxbuttons
            //    _ = MessageBox.Show("Fill at least figure name field",
            //                        "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
            //else
            if (result.Count == 0)
            {
                // https://learn.microsoft.com/en-us/dotnet/api/system.windows.forms.messageboxicon
                // https://learn.microsoft.com/en-us/dotnet/api/system.windows.forms.messageboxbuttons
                _ = MessageBox.Show("No figure whith such parameters found",
                                    "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            bindingSourceShape.DataSource = result;
        }

        private void listViewFillColor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
