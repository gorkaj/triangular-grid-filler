namespace triangular_grid_filler
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.Canvas = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textureBtn = new System.Windows.Forms.Button();
            this.textureRadioBtn = new System.Windows.Forms.RadioButton();
            this.solidRadioBtn = new System.Windows.Forms.RadioButton();
            this.objColorBox = new System.Windows.Forms.PictureBox();
            this.showGrid = new System.Windows.Forms.CheckBox();
            this.colorGroupBox = new System.Windows.Forms.GroupBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.interpolateButton = new System.Windows.Forms.RadioButton();
            this.lightColorBox = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.m_trackbar = new System.Windows.Forms.TrackBar();
            this.ks_trackbar = new System.Windows.Forms.TrackBar();
            this.kd_trackbar = new System.Windows.Forms.TrackBar();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Canvas)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.objColorBox)).BeginInit();
            this.colorGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lightColorBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_trackbar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ks_trackbar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kd_trackbar)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 61.39937F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 38.60063F));
            this.tableLayoutPanel1.Controls.Add(this.Canvas, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1128, 703);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // Canvas
            // 
            this.Canvas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.Canvas.Location = new System.Drawing.Point(21, 3);
            this.Canvas.Name = "Canvas";
            this.Canvas.Size = new System.Drawing.Size(650, 697);
            this.Canvas.TabIndex = 0;
            this.Canvas.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.showGrid);
            this.groupBox1.Controls.Add(this.colorGroupBox);
            this.groupBox1.Controls.Add(this.lightColorBox);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.m_trackbar);
            this.groupBox1.Controls.Add(this.ks_trackbar);
            this.groupBox1.Controls.Add(this.kd_trackbar);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(695, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(430, 697);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Parameters";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textureBtn);
            this.groupBox2.Controls.Add(this.textureRadioBtn);
            this.groupBox2.Controls.Add(this.solidRadioBtn);
            this.groupBox2.Controls.Add(this.objColorBox);
            this.groupBox2.Location = new System.Drawing.Point(0, 237);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(421, 105);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Object color";
            // 
            // textureBtn
            // 
            this.textureBtn.Location = new System.Drawing.Point(107, 61);
            this.textureBtn.Name = "textureBtn";
            this.textureBtn.Size = new System.Drawing.Size(94, 29);
            this.textureBtn.TabIndex = 8;
            this.textureBtn.Text = "Choose";
            this.textureBtn.UseVisualStyleBackColor = true;
            this.textureBtn.Click += new System.EventHandler(this.textureBtn_Click);
            // 
            // textureRadioBtn
            // 
            this.textureRadioBtn.AutoSize = true;
            this.textureRadioBtn.Location = new System.Drawing.Point(25, 63);
            this.textureRadioBtn.Name = "textureRadioBtn";
            this.textureRadioBtn.Size = new System.Drawing.Size(76, 24);
            this.textureRadioBtn.TabIndex = 1;
            this.textureRadioBtn.Text = "texture";
            this.textureRadioBtn.UseVisualStyleBackColor = true;
            this.textureRadioBtn.CheckedChanged += new System.EventHandler(this.textureRadioBtn_CheckedChanged);
            // 
            // solidRadioBtn
            // 
            this.solidRadioBtn.AutoSize = true;
            this.solidRadioBtn.Checked = true;
            this.solidRadioBtn.Location = new System.Drawing.Point(25, 26);
            this.solidRadioBtn.Name = "solidRadioBtn";
            this.solidRadioBtn.Size = new System.Drawing.Size(62, 24);
            this.solidRadioBtn.TabIndex = 0;
            this.solidRadioBtn.TabStop = true;
            this.solidRadioBtn.Text = "solid";
            this.solidRadioBtn.UseVisualStyleBackColor = true;
            this.solidRadioBtn.CheckedChanged += new System.EventHandler(this.solidRadioBtn_CheckedChanged);
            // 
            // objColorBox
            // 
            this.objColorBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.objColorBox.Location = new System.Drawing.Point(109, 19);
            this.objColorBox.Name = "objColorBox";
            this.objColorBox.Size = new System.Drawing.Size(46, 34);
            this.objColorBox.TabIndex = 7;
            this.objColorBox.TabStop = false;
            this.objColorBox.Click += new System.EventHandler(this.objColorBox_Click);
            // 
            // showGrid
            // 
            this.showGrid.AutoSize = true;
            this.showGrid.Checked = true;
            this.showGrid.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showGrid.Location = new System.Drawing.Point(17, 458);
            this.showGrid.Name = "showGrid";
            this.showGrid.Size = new System.Drawing.Size(98, 24);
            this.showGrid.TabIndex = 11;
            this.showGrid.Text = "Show grid";
            this.showGrid.UseVisualStyleBackColor = true;
            this.showGrid.CheckedChanged += new System.EventHandler(this.showGrid_CheckedChanged);
            // 
            // colorGroupBox
            // 
            this.colorGroupBox.Controls.Add(this.radioButton2);
            this.colorGroupBox.Controls.Add(this.interpolateButton);
            this.colorGroupBox.Location = new System.Drawing.Point(0, 348);
            this.colorGroupBox.Name = "colorGroupBox";
            this.colorGroupBox.Size = new System.Drawing.Size(421, 95);
            this.colorGroupBox.TabIndex = 10;
            this.colorGroupBox.TabStop = false;
            this.colorGroupBox.Text = "Color";
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(25, 56);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(65, 24);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.Text = "exact";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // interpolateButton
            // 
            this.interpolateButton.AutoSize = true;
            this.interpolateButton.Checked = true;
            this.interpolateButton.Location = new System.Drawing.Point(25, 26);
            this.interpolateButton.Name = "interpolateButton";
            this.interpolateButton.Size = new System.Drawing.Size(193, 24);
            this.interpolateButton.TabIndex = 0;
            this.interpolateButton.TabStop = true;
            this.interpolateButton.Text = "interpolate from vertices";
            this.interpolateButton.UseVisualStyleBackColor = true;
            this.interpolateButton.CheckedChanged += new System.EventHandler(this.interpolateButton_CheckedChanged);
            // 
            // lightColorBox
            // 
            this.lightColorBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lightColorBox.Location = new System.Drawing.Point(104, 185);
            this.lightColorBox.Name = "lightColorBox";
            this.lightColorBox.Size = new System.Drawing.Size(46, 34);
            this.lightColorBox.TabIndex = 9;
            this.lightColorBox.TabStop = false;
            this.lightColorBox.Click += new System.EventHandler(this.lightColorBox_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 193);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "Light color";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 144);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "m factor";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "k_s factor";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "k_d factor";
            // 
            // m_trackbar
            // 
            this.m_trackbar.Location = new System.Drawing.Point(104, 135);
            this.m_trackbar.Maximum = 100;
            this.m_trackbar.Minimum = 1;
            this.m_trackbar.Name = "m_trackbar";
            this.m_trackbar.Size = new System.Drawing.Size(317, 56);
            this.m_trackbar.TabIndex = 2;
            this.m_trackbar.Value = 40;
            this.m_trackbar.Scroll += new System.EventHandler(this.m_trackbar_Scroll);
            // 
            // ks_trackbar
            // 
            this.ks_trackbar.LargeChange = 20;
            this.ks_trackbar.Location = new System.Drawing.Point(104, 85);
            this.ks_trackbar.Maximum = 100;
            this.ks_trackbar.Name = "ks_trackbar";
            this.ks_trackbar.Size = new System.Drawing.Size(317, 56);
            this.ks_trackbar.SmallChange = 5;
            this.ks_trackbar.TabIndex = 1;
            this.ks_trackbar.Value = 20;
            this.ks_trackbar.ValueChanged += new System.EventHandler(this.ks_trackbar_ValueChanged);
            // 
            // kd_trackbar
            // 
            this.kd_trackbar.LargeChange = 20;
            this.kd_trackbar.Location = new System.Drawing.Point(104, 37);
            this.kd_trackbar.Maximum = 100;
            this.kd_trackbar.Name = "kd_trackbar";
            this.kd_trackbar.Size = new System.Drawing.Size(317, 56);
            this.kd_trackbar.SmallChange = 5;
            this.kd_trackbar.TabIndex = 0;
            this.kd_trackbar.Value = 80;
            this.kd_trackbar.ValueChanged += new System.EventHandler(this.kd_trackbar_ValueChanged);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1128, 703);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Triangular grid filler";
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Canvas)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.objColorBox)).EndInit();
            this.colorGroupBox.ResumeLayout(false);
            this.colorGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lightColorBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_trackbar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ks_trackbar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kd_trackbar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private PictureBox Canvas;
        private GroupBox groupBox1;
        private TrackBar m_trackbar;
        private TrackBar ks_trackbar;
        private TrackBar kd_trackbar;
        private Label label3;
        private Label label2;
        private Label label1;
        private PictureBox objColorBox;
        private PictureBox lightColorBox;
        private Label label5;
        private GroupBox colorGroupBox;
        private RadioButton radioButton2;
        private RadioButton interpolateButton;
        private CheckBox showGrid;
        private GroupBox groupBox2;
        private RadioButton textureRadioBtn;
        private RadioButton solidRadioBtn;
        private Button textureBtn;
    }
}