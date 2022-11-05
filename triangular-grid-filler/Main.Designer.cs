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
            this.objColorBox = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.m_trackbar = new System.Windows.Forms.TrackBar();
            this.ks_trackbar = new System.Windows.Forms.TrackBar();
            this.kd_trackbar = new System.Windows.Forms.TrackBar();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Canvas)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.objColorBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_trackbar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ks_trackbar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kd_trackbar)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.Controls.Add(this.Canvas, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1082, 703);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // Canvas
            // 
            this.Canvas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.Canvas.Location = new System.Drawing.Point(53, 3);
            this.Canvas.Name = "Canvas";
            this.Canvas.Size = new System.Drawing.Size(650, 697);
            this.Canvas.TabIndex = 0;
            this.Canvas.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.objColorBox);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.m_trackbar);
            this.groupBox1.Controls.Add(this.ks_trackbar);
            this.groupBox1.Controls.Add(this.kd_trackbar);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(760, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(319, 697);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Parameters";
            // 
            // objColorBox
            // 
            this.objColorBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.objColorBox.Location = new System.Drawing.Point(169, 210);
            this.objColorBox.Name = "objColorBox";
            this.objColorBox.Size = new System.Drawing.Size(46, 34);
            this.objColorBox.TabIndex = 7;
            this.objColorBox.TabStop = false;
            this.objColorBox.Click += new System.EventHandler(this.objColorBox_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(71, 217);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Object color";
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
            this.m_trackbar.Size = new System.Drawing.Size(186, 56);
            this.m_trackbar.TabIndex = 2;
            this.m_trackbar.Value = 1;
            // 
            // ks_trackbar
            // 
            this.ks_trackbar.LargeChange = 20;
            this.ks_trackbar.Location = new System.Drawing.Point(104, 85);
            this.ks_trackbar.Maximum = 100;
            this.ks_trackbar.Name = "ks_trackbar";
            this.ks_trackbar.Size = new System.Drawing.Size(186, 56);
            this.ks_trackbar.SmallChange = 5;
            this.ks_trackbar.TabIndex = 1;
            // 
            // kd_trackbar
            // 
            this.kd_trackbar.LargeChange = 20;
            this.kd_trackbar.Location = new System.Drawing.Point(104, 37);
            this.kd_trackbar.Maximum = 100;
            this.kd_trackbar.Name = "kd_trackbar";
            this.kd_trackbar.Size = new System.Drawing.Size(186, 56);
            this.kd_trackbar.SmallChange = 5;
            this.kd_trackbar.TabIndex = 0;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1082, 703);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Triangular grid filler";
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Canvas)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.objColorBox)).EndInit();
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
        private Label label4;
        private PictureBox objColorBox;
    }
}