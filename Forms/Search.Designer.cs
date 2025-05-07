
namespace Paint
{
    partial class Search
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.StrFillBox = new System.Windows.Forms.TextBox();
            this.StrColBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.NameBox = new System.Windows.Forms.TextBox();
            this.button_Find = new System.Windows.Forms.Button();
            this.listBox_search = new System.Windows.Forms.ListBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.StrFillBox);
            this.panel1.Controls.Add(this.StrColBox);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.NameBox);
            this.panel1.Controls.Add(this.button_Find);
            this.panel1.Location = new System.Drawing.Point(42, 38);
            this.panel1.MinimumSize = new System.Drawing.Size(420, 141);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(420, 141);
            this.panel1.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Shape fill color";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Shape stroke color";
            // 
            // StrFillBox
            // 
            this.StrFillBox.Location = new System.Drawing.Point(121, 71);
            this.StrFillBox.Name = "StrFillBox";
            this.StrFillBox.Size = new System.Drawing.Size(270, 20);
            this.StrFillBox.TabIndex = 4;
            // 
            // StrColBox
            // 
            this.StrColBox.Location = new System.Drawing.Point(121, 45);
            this.StrColBox.Name = "StrColBox";
            this.StrColBox.Size = new System.Drawing.Size(270, 20);
            this.StrColBox.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Shape name";
            // 
            // NameBox
            // 
            this.NameBox.Location = new System.Drawing.Point(121, 19);
            this.NameBox.Name = "NameBox";
            this.NameBox.Size = new System.Drawing.Size(270, 20);
            this.NameBox.TabIndex = 1;
            // 
            // button_Find
            // 
            this.button_Find.Location = new System.Drawing.Point(165, 97);
            this.button_Find.Name = "button_Find";
            this.button_Find.Size = new System.Drawing.Size(85, 28);
            this.button_Find.TabIndex = 0;
            this.button_Find.Text = "Find";
            this.button_Find.UseVisualStyleBackColor = true;
            this.button_Find.Click += new System.EventHandler(this.button_Find_Click);
            // 
            // listBox_search
            // 
            this.listBox_search.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox_search.FormattingEnabled = true;
            this.listBox_search.Location = new System.Drawing.Point(12, 200);
            this.listBox_search.Name = "listBox_search";
            this.listBox_search.Size = new System.Drawing.Size(484, 199);
            this.listBox_search.TabIndex = 1;
            // 
            // Search
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(510, 411);
            this.Controls.Add(this.listBox_search);
            this.Controls.Add(this.panel1);
            this.Name = "Search";
            this.Text = "Search";
            this.Load += new System.EventHandler(this.Search_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox StrFillBox;
        private System.Windows.Forms.TextBox StrColBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox NameBox;
        private System.Windows.Forms.Button button_Find;
        private System.Windows.Forms.ListBox listBox_search;
    }
}