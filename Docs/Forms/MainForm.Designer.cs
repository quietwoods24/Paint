
using System;

namespace Paint
{
    partial class MainForm
    {
        /// <summary>
        /// Required constructor variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Free up any resources that are in use.
        /// </summary>
        /// <param name="disposing">true if the managed resource should be deleted; otherwise false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code automatically created by the Windows Form Builder

        /// <summary>
        /// Required method to support the constructor - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("", 0);
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("", 1);
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem("", 2);
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem("", 3);
            this.panelControls = new System.Windows.Forms.Panel();
            this.groupBoxShape = new System.Windows.Forms.GroupBox();
            this.button_Line = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDownAngle = new System.Windows.Forms.NumericUpDown();
            this.button_Circle = new System.Windows.Forms.Button();
            this.checkBoxInsideImage = new System.Windows.Forms.CheckBox();
            this.button_Reg_Triangle = new System.Windows.Forms.Button();
            this.button_Square = new System.Windows.Forms.Button();
            this.button_Reg_Hexagon = new System.Windows.Forms.Button();
            this.button_Rectangle = new System.Windows.Forms.Button();
            this.button_Reg_Pentagon = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button26 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button_CurrFillColor = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button_CurrStrokeColor = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button23 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.button24 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button25 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.button20 = new System.Windows.Forms.Button();
            this.button16 = new System.Windows.Forms.Button();
            this.button21 = new System.Windows.Forms.Button();
            this.button15 = new System.Windows.Forms.Button();
            this.button22 = new System.Windows.Forms.Button();
            this.button14 = new System.Windows.Forms.Button();
            this.button17 = new System.Windows.Forms.Button();
            this.button19 = new System.Windows.Forms.Button();
            this.button18 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.button_Rand_Triangle = new System.Windows.Forms.Button();
            this.button_Rand_Quadrilateral = new System.Windows.Forms.Button();
            this.button_Rand_Hexagon = new System.Windows.Forms.Button();
            this.button_Rand_Pentagon = new System.Windows.Forms.Button();
            this.panelDraw = new System.Windows.Forms.Panel();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.numUpDSideCount = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonAddShape = new System.Windows.Forms.Button();
            this.radioButton6 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton5 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.buttonNew = new System.Windows.Forms.Button();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.checkBoxDrawAxes = new System.Windows.Forms.CheckBox();
            this.buttonMerge = new System.Windows.Forms.Button();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.numericUpDownImgAngle = new System.Windows.Forms.NumericUpDown();
            this.panelControls.SuspendLayout();
            this.groupBoxShape.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAngle)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDSideCount)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownImgAngle)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControls
            // 
            this.panelControls.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelControls.Controls.Add(this.groupBoxShape);
            this.panelControls.Controls.Add(this.groupBox1);
            this.panelControls.Controls.Add(this.groupBox2);
            this.panelControls.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelControls.Location = new System.Drawing.Point(0, 0);
            this.panelControls.Name = "panelControls";
            this.panelControls.Size = new System.Drawing.Size(211, 680);
            this.panelControls.TabIndex = 1;
            this.panelControls.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.MainForm_PreviewKeyDown);
            // 
            // groupBoxShape
            // 
            this.groupBoxShape.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBoxShape.Controls.Add(this.label5);
            this.groupBoxShape.Controls.Add(this.numericUpDownImgAngle);
            this.groupBoxShape.Controls.Add(this.button_Line);
            this.groupBoxShape.Controls.Add(this.label4);
            this.groupBoxShape.Controls.Add(this.numericUpDownAngle);
            this.groupBoxShape.Controls.Add(this.button_Circle);
            this.groupBoxShape.Controls.Add(this.checkBoxInsideImage);
            this.groupBoxShape.Controls.Add(this.button_Reg_Triangle);
            this.groupBoxShape.Controls.Add(this.button_Square);
            this.groupBoxShape.Controls.Add(this.button_Reg_Hexagon);
            this.groupBoxShape.Controls.Add(this.button_Rectangle);
            this.groupBoxShape.Controls.Add(this.button_Reg_Pentagon);
            this.groupBoxShape.Location = new System.Drawing.Point(3, 76);
            this.groupBoxShape.Name = "groupBoxShape";
            this.groupBoxShape.Size = new System.Drawing.Size(203, 220);
            this.groupBoxShape.TabIndex = 5;
            this.groupBoxShape.TabStop = false;
            this.groupBoxShape.Text = "Add shapes";
            this.groupBoxShape.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.MainForm_PreviewKeyDown);
            // 
            // button_Line
            // 
            this.button_Line.Image = ((System.Drawing.Image)(resources.GetObject("button_Line.Image")));
            this.button_Line.Location = new System.Drawing.Point(157, 59);
            this.button_Line.Name = "button_Line";
            this.button_Line.Size = new System.Drawing.Size(40, 40);
            this.button_Line.TabIndex = 17;
            this.button_Line.UseVisualStyleBackColor = true;
            this.button_Line.Click += new System.EventHandler(this.button_Line_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(61, 143);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Shape rotation angle";
            // 
            // numericUpDownAngle
            // 
            this.numericUpDownAngle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(62)))), ((int)(((byte)(75)))));
            this.numericUpDownAngle.InterceptArrowKeys = false;
            this.numericUpDownAngle.Location = new System.Drawing.Point(12, 139);
            this.numericUpDownAngle.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.numericUpDownAngle.Minimum = new decimal(new int[] {
            360,
            0,
            0,
            -2147483648});
            this.numericUpDownAngle.Name = "numericUpDownAngle";
            this.numericUpDownAngle.Size = new System.Drawing.Size(42, 21);
            this.numericUpDownAngle.TabIndex = 6;
            this.numericUpDownAngle.Tag = "Rotation angle";
            this.numericUpDownAngle.ValueChanged += new System.EventHandler(this.numericUpDownAngle_ValueChanged);
            // 
            // button_Circle
            // 
            this.button_Circle.Image = ((System.Drawing.Image)(resources.GetObject("button_Circle.Image")));
            this.button_Circle.Location = new System.Drawing.Point(110, 81);
            this.button_Circle.Name = "button_Circle";
            this.button_Circle.Size = new System.Drawing.Size(43, 43);
            this.button_Circle.TabIndex = 16;
            this.button_Circle.UseVisualStyleBackColor = true;
            this.button_Circle.Click += new System.EventHandler(this.button_Circle_Click);
            // 
            // checkBoxInsideImage
            // 
            this.checkBoxInsideImage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxInsideImage.AutoSize = true;
            this.checkBoxInsideImage.Checked = true;
            this.checkBoxInsideImage.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxInsideImage.Location = new System.Drawing.Point(12, 192);
            this.checkBoxInsideImage.Name = "checkBoxInsideImage";
            this.checkBoxInsideImage.Size = new System.Drawing.Size(151, 17);
            this.checkBoxInsideImage.TabIndex = 15;
            this.checkBoxInsideImage.Text = "Move shapes inside image";
            this.checkBoxInsideImage.UseVisualStyleBackColor = true;
            // 
            // button_Reg_Triangle
            // 
            this.button_Reg_Triangle.Image = ((System.Drawing.Image)(resources.GetObject("button_Reg_Triangle.Image")));
            this.button_Reg_Triangle.Location = new System.Drawing.Point(12, 32);
            this.button_Reg_Triangle.Name = "button_Reg_Triangle";
            this.button_Reg_Triangle.Size = new System.Drawing.Size(43, 43);
            this.button_Reg_Triangle.TabIndex = 6;
            this.button_Reg_Triangle.UseVisualStyleBackColor = true;
            this.button_Reg_Triangle.Click += new System.EventHandler(this.button_Reg_Triangle_Click);
            // 
            // button_Square
            // 
            this.button_Square.Image = ((System.Drawing.Image)(resources.GetObject("button_Square.Image")));
            this.button_Square.Location = new System.Drawing.Point(12, 81);
            this.button_Square.Name = "button_Square";
            this.button_Square.Size = new System.Drawing.Size(43, 43);
            this.button_Square.TabIndex = 7;
            this.button_Square.UseVisualStyleBackColor = true;
            this.button_Square.Click += new System.EventHandler(this.button_Square_Click);
            // 
            // button_Reg_Hexagon
            // 
            this.button_Reg_Hexagon.Image = ((System.Drawing.Image)(resources.GetObject("button_Reg_Hexagon.Image")));
            this.button_Reg_Hexagon.Location = new System.Drawing.Point(110, 32);
            this.button_Reg_Hexagon.Name = "button_Reg_Hexagon";
            this.button_Reg_Hexagon.Size = new System.Drawing.Size(43, 43);
            this.button_Reg_Hexagon.TabIndex = 10;
            this.button_Reg_Hexagon.UseVisualStyleBackColor = true;
            this.button_Reg_Hexagon.Click += new System.EventHandler(this.button_Reg_Hexagon_Click);
            // 
            // button_Rectangle
            // 
            this.button_Rectangle.Image = ((System.Drawing.Image)(resources.GetObject("button_Rectangle.Image")));
            this.button_Rectangle.Location = new System.Drawing.Point(61, 81);
            this.button_Rectangle.Name = "button_Rectangle";
            this.button_Rectangle.Size = new System.Drawing.Size(43, 43);
            this.button_Rectangle.TabIndex = 8;
            this.button_Rectangle.UseVisualStyleBackColor = true;
            this.button_Rectangle.Click += new System.EventHandler(this.button_Rectangle_Click);
            // 
            // button_Reg_Pentagon
            // 
            this.button_Reg_Pentagon.Image = ((System.Drawing.Image)(resources.GetObject("button_Reg_Pentagon.Image")));
            this.button_Reg_Pentagon.Location = new System.Drawing.Point(61, 32);
            this.button_Reg_Pentagon.Name = "button_Reg_Pentagon";
            this.button_Reg_Pentagon.Size = new System.Drawing.Size(43, 43);
            this.button_Reg_Pentagon.TabIndex = 9;
            this.button_Reg_Pentagon.UseVisualStyleBackColor = true;
            this.button_Reg_Pentagon.Click += new System.EventHandler(this.button_Reg_Pentagon_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button26);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.button7);
            this.groupBox1.Controls.Add(this.button_CurrFillColor);
            this.groupBox1.Controls.Add(this.button5);
            this.groupBox1.Controls.Add(this.button6);
            this.groupBox1.Controls.Add(this.button_CurrStrokeColor);
            this.groupBox1.Controls.Add(this.button10);
            this.groupBox1.Controls.Add(this.button8);
            this.groupBox1.Controls.Add(this.button9);
            this.groupBox1.Controls.Add(this.button23);
            this.groupBox1.Controls.Add(this.button13);
            this.groupBox1.Controls.Add(this.button24);
            this.groupBox1.Controls.Add(this.button11);
            this.groupBox1.Controls.Add(this.button25);
            this.groupBox1.Controls.Add(this.button12);
            this.groupBox1.Controls.Add(this.button20);
            this.groupBox1.Controls.Add(this.button16);
            this.groupBox1.Controls.Add(this.button21);
            this.groupBox1.Controls.Add(this.button15);
            this.groupBox1.Controls.Add(this.button22);
            this.groupBox1.Controls.Add(this.button14);
            this.groupBox1.Controls.Add(this.button17);
            this.groupBox1.Controls.Add(this.button19);
            this.groupBox1.Controls.Add(this.button18);
            this.groupBox1.Location = new System.Drawing.Point(3, 302);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(203, 190);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Palette";
            // 
            // button26
            // 
            this.button26.BackColor = System.Drawing.Color.Transparent;
            this.button26.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button26.BackgroundImage")));
            this.button26.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button26.Location = new System.Drawing.Point(78, 94);
            this.button26.Name = "button26";
            this.button26.Size = new System.Drawing.Size(50, 30);
            this.button26.TabIndex = 28;
            this.button26.UseVisualStyleBackColor = false;
            this.button26.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button26_MouseDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(145, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 26);
            this.label3.TabIndex = 27;
            this.label3.Text = "Fill\ncolor";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Black;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(5, 20);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(19, 19);
            this.button2.TabIndex = 0;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button23_MouseDown);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.White;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Location = new System.Drawing.Point(5, 69);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(19, 19);
            this.button4.TabIndex = 2;
            this.button4.UseVisualStyleBackColor = false;
            this.button4.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button23_MouseDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 26);
            this.label2.TabIndex = 26;
            this.label2.Text = "Stroke\ncolor";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Gray;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Location = new System.Drawing.Point(5, 44);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(19, 19);
            this.button3.TabIndex = 1;
            this.button3.UseVisualStyleBackColor = false;
            this.button3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button23_MouseDown);
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.DarkRed;
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.Location = new System.Drawing.Point(30, 20);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(19, 19);
            this.button7.TabIndex = 3;
            this.button7.UseVisualStyleBackColor = false;
            this.button7.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button23_MouseDown);
            // 
            // button_CurrFillColor
            // 
            this.button_CurrFillColor.BackColor = System.Drawing.Color.Black;
            this.button_CurrFillColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_CurrFillColor.Location = new System.Drawing.Point(142, 148);
            this.button_CurrFillColor.Name = "button_CurrFillColor";
            this.button_CurrFillColor.Size = new System.Drawing.Size(37, 36);
            this.button_CurrFillColor.TabIndex = 25;
            this.button_CurrFillColor.UseVisualStyleBackColor = false;
            this.button_CurrFillColor.Click += new System.EventHandler(this.button27_Click);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.Salmon;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Location = new System.Drawing.Point(30, 69);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(19, 19);
            this.button5.TabIndex = 5;
            this.button5.UseVisualStyleBackColor = false;
            this.button5.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button23_MouseDown);
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.Red;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Location = new System.Drawing.Point(30, 44);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(19, 19);
            this.button6.TabIndex = 4;
            this.button6.UseVisualStyleBackColor = false;
            this.button6.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button23_MouseDown);
            // 
            // button_CurrStrokeColor
            // 
            this.button_CurrStrokeColor.BackColor = System.Drawing.Color.White;
            this.button_CurrStrokeColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_CurrStrokeColor.Location = new System.Drawing.Point(21, 148);
            this.button_CurrStrokeColor.Name = "button_CurrStrokeColor";
            this.button_CurrStrokeColor.Size = new System.Drawing.Size(37, 36);
            this.button_CurrStrokeColor.TabIndex = 24;
            this.button_CurrStrokeColor.UseVisualStyleBackColor = false;
            this.button_CurrStrokeColor.Click += new System.EventHandler(this.button26_Click);
            // 
            // button10
            // 
            this.button10.BackColor = System.Drawing.Color.Chocolate;
            this.button10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button10.Location = new System.Drawing.Point(55, 20);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(19, 19);
            this.button10.TabIndex = 6;
            this.button10.UseVisualStyleBackColor = false;
            this.button10.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button23_MouseDown);
            // 
            // button8
            // 
            this.button8.BackColor = System.Drawing.Color.NavajoWhite;
            this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button8.Location = new System.Drawing.Point(55, 69);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(19, 19);
            this.button8.TabIndex = 8;
            this.button8.UseVisualStyleBackColor = false;
            this.button8.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button23_MouseDown);
            // 
            // button9
            // 
            this.button9.BackColor = System.Drawing.Color.Orange;
            this.button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button9.Location = new System.Drawing.Point(55, 44);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(19, 19);
            this.button9.TabIndex = 7;
            this.button9.UseVisualStyleBackColor = false;
            this.button9.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button23_MouseDown);
            // 
            // button23
            // 
            this.button23.BackColor = System.Drawing.Color.Violet;
            this.button23.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button23.Location = new System.Drawing.Point(180, 69);
            this.button23.Name = "button23";
            this.button23.Size = new System.Drawing.Size(19, 19);
            this.button23.TabIndex = 23;
            this.button23.UseVisualStyleBackColor = false;
            this.button23.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button23_MouseDown);
            // 
            // button13
            // 
            this.button13.BackColor = System.Drawing.Color.Olive;
            this.button13.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button13.Location = new System.Drawing.Point(80, 20);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(19, 19);
            this.button13.TabIndex = 9;
            this.button13.UseVisualStyleBackColor = false;
            this.button13.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button23_MouseDown);
            // 
            // button24
            // 
            this.button24.BackColor = System.Drawing.Color.Fuchsia;
            this.button24.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button24.Location = new System.Drawing.Point(180, 44);
            this.button24.Name = "button24";
            this.button24.Size = new System.Drawing.Size(19, 19);
            this.button24.TabIndex = 22;
            this.button24.UseVisualStyleBackColor = false;
            this.button24.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button23_MouseDown);
            // 
            // button11
            // 
            this.button11.BackColor = System.Drawing.Color.LemonChiffon;
            this.button11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button11.Location = new System.Drawing.Point(80, 69);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(19, 19);
            this.button11.TabIndex = 11;
            this.button11.UseVisualStyleBackColor = false;
            this.button11.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button23_MouseDown);
            // 
            // button25
            // 
            this.button25.BackColor = System.Drawing.Color.Purple;
            this.button25.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button25.Location = new System.Drawing.Point(180, 20);
            this.button25.Name = "button25";
            this.button25.Size = new System.Drawing.Size(19, 19);
            this.button25.TabIndex = 21;
            this.button25.UseVisualStyleBackColor = false;
            this.button25.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button23_MouseDown);
            // 
            // button12
            // 
            this.button12.BackColor = System.Drawing.Color.Yellow;
            this.button12.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button12.Location = new System.Drawing.Point(80, 44);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(19, 19);
            this.button12.TabIndex = 10;
            this.button12.UseVisualStyleBackColor = false;
            this.button12.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button23_MouseDown);
            // 
            // button20
            // 
            this.button20.BackColor = System.Drawing.Color.CornflowerBlue;
            this.button20.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button20.Location = new System.Drawing.Point(155, 69);
            this.button20.Name = "button20";
            this.button20.Size = new System.Drawing.Size(19, 19);
            this.button20.TabIndex = 20;
            this.button20.UseVisualStyleBackColor = false;
            this.button20.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button23_MouseDown);
            // 
            // button16
            // 
            this.button16.BackColor = System.Drawing.Color.ForestGreen;
            this.button16.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button16.Location = new System.Drawing.Point(105, 20);
            this.button16.Name = "button16";
            this.button16.Size = new System.Drawing.Size(19, 19);
            this.button16.TabIndex = 12;
            this.button16.UseVisualStyleBackColor = false;
            this.button16.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button23_MouseDown);
            // 
            // button21
            // 
            this.button21.BackColor = System.Drawing.Color.Blue;
            this.button21.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button21.Location = new System.Drawing.Point(155, 44);
            this.button21.Name = "button21";
            this.button21.Size = new System.Drawing.Size(19, 19);
            this.button21.TabIndex = 19;
            this.button21.UseVisualStyleBackColor = false;
            this.button21.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button23_MouseDown);
            // 
            // button15
            // 
            this.button15.BackColor = System.Drawing.Color.Lime;
            this.button15.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button15.Location = new System.Drawing.Point(105, 44);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(19, 19);
            this.button15.TabIndex = 13;
            this.button15.UseVisualStyleBackColor = false;
            this.button15.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button23_MouseDown);
            // 
            // button22
            // 
            this.button22.BackColor = System.Drawing.Color.DarkBlue;
            this.button22.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button22.Location = new System.Drawing.Point(155, 20);
            this.button22.Name = "button22";
            this.button22.Size = new System.Drawing.Size(19, 19);
            this.button22.TabIndex = 18;
            this.button22.UseVisualStyleBackColor = false;
            this.button22.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button23_MouseDown);
            // 
            // button14
            // 
            this.button14.BackColor = System.Drawing.Color.PaleGreen;
            this.button14.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button14.Location = new System.Drawing.Point(105, 69);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(19, 19);
            this.button14.TabIndex = 14;
            this.button14.UseVisualStyleBackColor = false;
            this.button14.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button23_MouseDown);
            // 
            // button17
            // 
            this.button17.BackColor = System.Drawing.Color.PaleTurquoise;
            this.button17.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button17.Location = new System.Drawing.Point(130, 69);
            this.button17.Name = "button17";
            this.button17.Size = new System.Drawing.Size(19, 19);
            this.button17.TabIndex = 17;
            this.button17.UseVisualStyleBackColor = false;
            this.button17.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button23_MouseDown);
            // 
            // button19
            // 
            this.button19.BackColor = System.Drawing.Color.LightSeaGreen;
            this.button19.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button19.Location = new System.Drawing.Point(130, 20);
            this.button19.Name = "button19";
            this.button19.Size = new System.Drawing.Size(19, 19);
            this.button19.TabIndex = 15;
            this.button19.UseVisualStyleBackColor = false;
            this.button19.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button23_MouseDown);
            // 
            // button18
            // 
            this.button18.BackColor = System.Drawing.Color.Aqua;
            this.button18.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button18.Location = new System.Drawing.Point(130, 44);
            this.button18.Name = "button18";
            this.button18.Size = new System.Drawing.Size(19, 19);
            this.button18.TabIndex = 16;
            this.button18.UseVisualStyleBackColor = false;
            this.button18.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button23_MouseDown);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.listView1);
            this.groupBox2.Location = new System.Drawing.Point(3, 498);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(203, 133);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Stroke width";
            // 
            // listView1
            // 
            this.listView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 5.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listView1.HideSelection = false;
            this.listView1.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3,
            listViewItem4});
            this.listView1.Location = new System.Drawing.Point(33, 28);
            this.listView1.Margin = new System.Windows.Forms.Padding(0);
            this.listView1.Name = "listView1";
            this.listView1.Scrollable = false;
            this.listView1.Size = new System.Drawing.Size(137, 79);
            this.listView1.SmallImageList = this.imageList1;
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.SmallIcon;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged_1);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Line_width_0.png");
            this.imageList1.Images.SetKeyName(1, "Line_width_1.png");
            this.imageList1.Images.SetKeyName(2, "Line_width_2.png");
            this.imageList1.Images.SetKeyName(3, "Line_width_3.png");
            // 
            // button_Rand_Triangle
            // 
            this.button_Rand_Triangle.Image = ((System.Drawing.Image)(resources.GetObject("button_Rand_Triangle.Image")));
            this.button_Rand_Triangle.Location = new System.Drawing.Point(508, 23);
            this.button_Rand_Triangle.Name = "button_Rand_Triangle";
            this.button_Rand_Triangle.Size = new System.Drawing.Size(43, 43);
            this.button_Rand_Triangle.TabIndex = 12;
            this.button_Rand_Triangle.UseVisualStyleBackColor = true;
            this.button_Rand_Triangle.Visible = false;
            this.button_Rand_Triangle.Click += new System.EventHandler(this.button_Rand_Triangle_Click);
            // 
            // button_Rand_Quadrilateral
            // 
            this.button_Rand_Quadrilateral.Image = ((System.Drawing.Image)(resources.GetObject("button_Rand_Quadrilateral.Image")));
            this.button_Rand_Quadrilateral.Location = new System.Drawing.Point(557, 23);
            this.button_Rand_Quadrilateral.Name = "button_Rand_Quadrilateral";
            this.button_Rand_Quadrilateral.Size = new System.Drawing.Size(43, 43);
            this.button_Rand_Quadrilateral.TabIndex = 11;
            this.button_Rand_Quadrilateral.UseVisualStyleBackColor = true;
            this.button_Rand_Quadrilateral.Visible = false;
            this.button_Rand_Quadrilateral.Click += new System.EventHandler(this.button_Rand_Quadrilateral_Click);
            // 
            // button_Rand_Hexagon
            // 
            this.button_Rand_Hexagon.Image = ((System.Drawing.Image)(resources.GetObject("button_Rand_Hexagon.Image")));
            this.button_Rand_Hexagon.Location = new System.Drawing.Point(557, 72);
            this.button_Rand_Hexagon.Name = "button_Rand_Hexagon";
            this.button_Rand_Hexagon.Size = new System.Drawing.Size(43, 43);
            this.button_Rand_Hexagon.TabIndex = 14;
            this.button_Rand_Hexagon.UseVisualStyleBackColor = true;
            this.button_Rand_Hexagon.Visible = false;
            this.button_Rand_Hexagon.Click += new System.EventHandler(this.button_Rand_Hexagon_Click);
            // 
            // button_Rand_Pentagon
            // 
            this.button_Rand_Pentagon.Image = ((System.Drawing.Image)(resources.GetObject("button_Rand_Pentagon.Image")));
            this.button_Rand_Pentagon.Location = new System.Drawing.Point(603, 23);
            this.button_Rand_Pentagon.Name = "button_Rand_Pentagon";
            this.button_Rand_Pentagon.Size = new System.Drawing.Size(43, 43);
            this.button_Rand_Pentagon.TabIndex = 13;
            this.button_Rand_Pentagon.UseVisualStyleBackColor = true;
            this.button_Rand_Pentagon.Visible = false;
            this.button_Rand_Pentagon.Click += new System.EventHandler(this.button_Rand_Pentagon_Click);
            // 
            // panelDraw
            // 
            this.panelDraw.AutoSize = true;
            this.panelDraw.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(38)))));
            this.panelDraw.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDraw.Cursor = System.Windows.Forms.Cursors.Default;
            this.panelDraw.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDraw.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.panelDraw.Location = new System.Drawing.Point(0, 0);
            this.panelDraw.Name = "panelDraw";
            this.panelDraw.Size = new System.Drawing.Size(863, 680);
            this.panelDraw.TabIndex = 2;
            this.panelDraw.TabStop = true;
            this.panelDraw.Paint += new System.Windows.Forms.PaintEventHandler(this.panelDraw_Paint);
            this.panelDraw.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panelDraw_MouseClick);
            this.panelDraw.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.panelDraw_MouseDoubleClick);
            this.panelDraw.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelDraw_MouseDown);
            this.panelDraw.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelDraw_MouseMove);
            this.panelDraw.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panelDraw_MouseUp);
            this.panelDraw.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.MainForm_PreviewKeyDown);
            // 
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "json";
            this.openFileDialog.FileName = "image.json";
            this.openFileDialog.Filter = "json files (*.json)|*.json|All files (*.*)|*.*";
            this.openFileDialog.RestoreDirectory = true;
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "json";
            this.saveFileDialog.FileName = "image.json";
            this.saveFileDialog.Filter = "json files (*.json)|*.json|All files (*.*)|*.*";
            this.saveFileDialog.RestoreDirectory = true;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.button_Rand_Triangle);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.button_Rand_Pentagon);
            this.panel1.Controls.Add(this.numUpDSideCount);
            this.panel1.Controls.Add(this.button_Rand_Quadrilateral);
            this.panel1.Controls.Add(this.button_Rand_Hexagon);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.buttonAddShape);
            this.panel1.Controls.Add(this.radioButton6);
            this.panel1.Controls.Add(this.radioButton1);
            this.panel1.Controls.Add(this.radioButton5);
            this.panel1.Controls.Add(this.radioButton3);
            this.panel1.Controls.Add(this.radioButton4);
            this.panel1.Location = new System.Drawing.Point(0, 626);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(851, 54);
            this.panel1.TabIndex = 3;
            this.panel1.Visible = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.button1.Location = new System.Drawing.Point(811, 73);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(39, 42);
            this.button1.TabIndex = 6;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Visible = false;
            // 
            // numUpDSideCount
            // 
            this.numUpDSideCount.Location = new System.Drawing.Point(808, 10);
            this.numUpDSideCount.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numUpDSideCount.Name = "numUpDSideCount";
            this.numUpDSideCount.Size = new System.Drawing.Size(42, 21);
            this.numUpDSideCount.TabIndex = 11;
            this.numUpDSideCount.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numUpDSideCount.Visible = false;
            this.numUpDSideCount.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.MainForm_PreviewKeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(741, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Side count:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label1.Visible = false;
            this.label1.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.MainForm_PreviewKeyDown);
            // 
            // buttonAddShape
            // 
            this.buttonAddShape.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAddShape.Location = new System.Drawing.Point(766, -30);
            this.buttonAddShape.Name = "buttonAddShape";
            this.buttonAddShape.Size = new System.Drawing.Size(75, 23);
            this.buttonAddShape.TabIndex = 12;
            this.buttonAddShape.Text = "Add shape";
            this.buttonAddShape.UseVisualStyleBackColor = true;
            this.buttonAddShape.Visible = false;
            this.buttonAddShape.Click += new System.EventHandler(this.buttonAddFigure_Click);
            this.buttonAddShape.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.MainForm_PreviewKeyDown);
            // 
            // radioButton6
            // 
            this.radioButton6.AutoSize = true;
            this.radioButton6.Location = new System.Drawing.Point(668, 105);
            this.radioButton6.Name = "radioButton6";
            this.radioButton6.Size = new System.Drawing.Size(69, 17);
            this.radioButton6.TabIndex = 13;
            this.radioButton6.TabStop = true;
            this.radioButton6.Tag = "4";
            this.radioButton6.Text = "Test data";
            this.radioButton6.UseVisualStyleBackColor = true;
            this.radioButton6.Visible = false;
            this.radioButton6.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.MainForm_PreviewKeyDown);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(668, 13);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(65, 17);
            this.radioButton1.TabIndex = 6;
            this.radioButton1.TabStop = true;
            this.radioButton1.Tag = "0";
            this.radioButton1.Text = "Polygon";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.Visible = false;
            this.radioButton1.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.MainForm_PreviewKeyDown);
            // 
            // radioButton5
            // 
            this.radioButton5.AutoSize = true;
            this.radioButton5.Location = new System.Drawing.Point(668, 82);
            this.radioButton5.Name = "radioButton5";
            this.radioButton5.Size = new System.Drawing.Size(53, 17);
            this.radioButton5.TabIndex = 10;
            this.radioButton5.TabStop = true;
            this.radioButton5.Tag = "4";
            this.radioButton5.Text = "Prism";
            this.radioButton5.UseVisualStyleBackColor = true;
            this.radioButton5.Visible = false;
            this.radioButton5.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.MainForm_PreviewKeyDown);
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(668, 36);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(104, 17);
            this.radioButton3.TabIndex = 8;
            this.radioButton3.TabStop = true;
            this.radioButton3.Tag = "2";
            this.radioButton3.Text = "Regular polygon";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.Visible = false;
            this.radioButton3.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.MainForm_PreviewKeyDown);
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Location = new System.Drawing.Point(668, 59);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(66, 17);
            this.radioButton4.TabIndex = 9;
            this.radioButton4.TabStop = true;
            this.radioButton4.Tag = "3";
            this.radioButton4.Text = "Pyramid";
            this.radioButton4.UseVisualStyleBackColor = true;
            this.radioButton4.Visible = false;
            this.radioButton4.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.MainForm_PreviewKeyDown);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(861, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.toolStripSeparator,
            this.saveToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripMenuItem.Image")));
            this.newToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.newToolStripMenuItem.Text = "&New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripMenuItem.Image")));
            this.openToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.openToolStripMenuItem.Text = "&Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(137, 6);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripMenuItem.Image")));
            this.saveToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.saveToolStripMenuItem.Text = "&Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(137, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoToolStripMenuItem,
            this.redoToolStripMenuItem,
            this.toolStripSeparator3,
            this.cutToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.toolStripSeparator4,
            this.selectAllToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.editToolStripMenuItem.Text = "&Edit";
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.undoToolStripMenuItem.Text = "&Undo";
            // 
            // redoToolStripMenuItem
            // 
            this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            this.redoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.redoToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.redoToolStripMenuItem.Text = "&Redo";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(136, 6);
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("cutToolStripMenuItem.Image")));
            this.cutToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.cutToolStripMenuItem.Text = "Cu&t";
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("copyToolStripMenuItem.Image")));
            this.copyToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.copyToolStripMenuItem.Text = "&Copy";
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("pasteToolStripMenuItem.Image")));
            this.pasteToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.pasteToolStripMenuItem.Text = "&Paste";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(136, 6);
            // 
            // selectAllToolStripMenuItem
            // 
            this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.selectAllToolStripMenuItem.Text = "Select &All";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.customizeToolStripMenuItem,
            this.optionsToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.toolsToolStripMenuItem.Text = "&Tools";
            // 
            // customizeToolStripMenuItem
            // 
            this.customizeToolStripMenuItem.Name = "customizeToolStripMenuItem";
            this.customizeToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.customizeToolStripMenuItem.Text = "&Search shape";
            this.customizeToolStripMenuItem.Click += new System.EventHandler(this.customizeToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.optionsToolStripMenuItem.Text = "&Options";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contentsToolStripMenuItem,
            this.toolStripSeparator5});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // contentsToolStripMenuItem
            // 
            this.contentsToolStripMenuItem.Name = "contentsToolStripMenuItem";
            this.contentsToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.contentsToolStripMenuItem.Text = "&View Help";
            this.contentsToolStripMenuItem.Click += new System.EventHandler(this.contentsToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(117, 6);
            // 
            // buttonNew
            // 
            this.buttonNew.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(106)))), ((int)(((byte)(131)))));
            this.buttonNew.Location = new System.Drawing.Point(5, 37);
            this.buttonNew.Name = "buttonNew";
            this.buttonNew.Size = new System.Drawing.Size(56, 23);
            this.buttonNew.TabIndex = 1;
            this.buttonNew.Text = "New";
            this.buttonNew.UseVisualStyleBackColor = false;
            this.buttonNew.Click += new System.EventHandler(this.buttonNew_Click);
            this.buttonNew.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.MainForm_PreviewKeyDown);
            // 
            // buttonLoad
            // 
            this.buttonLoad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(106)))), ((int)(((byte)(131)))));
            this.buttonLoad.Location = new System.Drawing.Point(67, 37);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(56, 23);
            this.buttonLoad.TabIndex = 2;
            this.buttonLoad.Text = "Open";
            this.buttonLoad.UseVisualStyleBackColor = false;
            this.buttonLoad.Click += new System.EventHandler(this.buttonOpen_Click);
            this.buttonLoad.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.MainForm_PreviewKeyDown);
            // 
            // buttonSave
            // 
            this.buttonSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(106)))), ((int)(((byte)(131)))));
            this.buttonSave.Location = new System.Drawing.Point(129, 37);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(53, 23);
            this.buttonSave.TabIndex = 3;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = false;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            this.buttonSave.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.MainForm_PreviewKeyDown);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.checkBoxDrawAxes);
            this.panel2.Controls.Add(this.buttonMerge);
            this.panel2.Controls.Add(this.buttonSave);
            this.panel2.Controls.Add(this.buttonLoad);
            this.panel2.Controls.Add(this.buttonNew);
            this.panel2.Controls.Add(this.menuStrip1);
            this.panel2.Controls.Add(this.radioButton2);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(863, 71);
            this.panel2.TabIndex = 6;
            // 
            // checkBoxDrawAxes
            // 
            this.checkBoxDrawAxes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxDrawAxes.AutoSize = true;
            this.checkBoxDrawAxes.Location = new System.Drawing.Point(595, 41);
            this.checkBoxDrawAxes.Name = "checkBoxDrawAxes";
            this.checkBoxDrawAxes.Size = new System.Drawing.Size(77, 17);
            this.checkBoxDrawAxes.TabIndex = 5;
            this.checkBoxDrawAxes.Text = "Draw axes";
            this.checkBoxDrawAxes.UseVisualStyleBackColor = true;
            this.checkBoxDrawAxes.Visible = false;
            this.checkBoxDrawAxes.CheckedChanged += new System.EventHandler(this.checkBoxDrawAxes_CheckedChanged);
            // 
            // buttonMerge
            // 
            this.buttonMerge.Location = new System.Drawing.Point(677, 37);
            this.buttonMerge.Name = "buttonMerge";
            this.buttonMerge.Size = new System.Drawing.Size(173, 23);
            this.buttonMerge.TabIndex = 4;
            this.buttonMerge.Text = "Merge with another image";
            this.buttonMerge.UseVisualStyleBackColor = true;
            this.buttonMerge.Visible = false;
            this.buttonMerge.Click += new System.EventHandler(this.buttonMerge_Click);
            this.buttonMerge.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.MainForm_PreviewKeyDown);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(497, 40);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(93, 17);
            this.radioButton2.TabIndex = 7;
            this.radioButton2.TabStop = true;
            this.radioButton2.Tag = "1";
            this.radioButton2.Text = "Filled polygon";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.Visible = false;
            this.radioButton2.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.MainForm_PreviewKeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(61, 167);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Image rotation angle";
            // 
            // numericUpDownImgAngle
            // 
            this.numericUpDownImgAngle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(62)))), ((int)(((byte)(75)))));
            this.numericUpDownImgAngle.InterceptArrowKeys = false;
            this.numericUpDownImgAngle.Location = new System.Drawing.Point(12, 163);
            this.numericUpDownImgAngle.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.numericUpDownImgAngle.Minimum = new decimal(new int[] {
            360,
            0,
            0,
            -2147483648});
            this.numericUpDownImgAngle.Name = "numericUpDownImgAngle";
            this.numericUpDownImgAngle.Size = new System.Drawing.Size(42, 21);
            this.numericUpDownImgAngle.TabIndex = 18;
            this.numericUpDownImgAngle.Tag = "Rotation angle";
            this.numericUpDownImgAngle.ValueChanged += new System.EventHandler(this.numericUpDownImgAngle_ValueChanged);
            // 
            // MainForm
            // 
            this.AcceptButton = this.buttonNew;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(62)))), ((int)(((byte)(75)))));
            this.ClientSize = new System.Drawing.Size(863, 680);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelControls);
            this.Controls.Add(this.panelDraw);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Font = new System.Drawing.Font("Corbel", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(179)))), ((int)(((byte)(193)))));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(350, 550);
            this.Name = "MainForm";
            this.Text = "Paint";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.MainForm_PreviewKeyDown);
            this.panelControls.ResumeLayout(false);
            this.groupBoxShape.ResumeLayout(false);
            this.groupBoxShape.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAngle)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDSideCount)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownImgAngle)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion
        private System.Windows.Forms.Panel panelControls;
        private System.Windows.Forms.Panel panelDraw;
        private System.Windows.Forms.GroupBox groupBoxShape;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.CheckBox checkBoxInsideImage;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem customizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.Button buttonNew;
        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button button23;
        private System.Windows.Forms.Button button24;
        private System.Windows.Forms.Button button25;
        private System.Windows.Forms.Button button20;
        private System.Windows.Forms.Button button21;
        private System.Windows.Forms.Button button22;
        private System.Windows.Forms.Button button17;
        private System.Windows.Forms.Button button18;
        private System.Windows.Forms.Button button19;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.Button button15;
        private System.Windows.Forms.Button button16;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button_CurrFillColor;
        private System.Windows.Forms.Button button_CurrStrokeColor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button26;
        private System.Windows.Forms.Button button_Rand_Hexagon;
        private System.Windows.Forms.Button button_Rand_Pentagon;
        private System.Windows.Forms.Button button_Rand_Triangle;
        private System.Windows.Forms.Button button_Rand_Quadrilateral;
        private System.Windows.Forms.Button button_Reg_Hexagon;
        private System.Windows.Forms.Button button_Reg_Pentagon;
        private System.Windows.Forms.Button button_Rectangle;
        private System.Windows.Forms.Button button_Square;
        private System.Windows.Forms.Button button_Reg_Triangle;
        private System.Windows.Forms.Button button_Circle;
        private System.Windows.Forms.NumericUpDown numericUpDownAngle;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.NumericUpDown numUpDSideCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonAddShape;
        private System.Windows.Forms.RadioButton radioButton6;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton5;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.CheckBox checkBoxDrawAxes;
        private System.Windows.Forms.Button buttonMerge;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.Button button_Line;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numericUpDownImgAngle;
    }
}

