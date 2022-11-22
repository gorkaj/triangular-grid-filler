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
            this.cloudsBox = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.chooseNormalMapBtn = new System.Windows.Forms.Button();
            this.useNormalMap = new System.Windows.Forms.CheckBox();
            this.rotateLight = new System.Windows.Forms.CheckBox();
            this.objBrowseBtn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.zLightTrackBar = new System.Windows.Forms.TrackBar();
            this.label6 = new System.Windows.Forms.Label();
            this.lightColorBox = new System.Windows.Forms.PictureBox();
            this.kd_trackbar = new System.Windows.Forms.TrackBar();
            this.ks_trackbar = new System.Windows.Forms.TrackBar();
            this.m_trackbar = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textureBtn = new System.Windows.Forms.Button();
            this.textureRadioBtn = new System.Windows.Forms.RadioButton();
            this.solidRadioBtn = new System.Windows.Forms.RadioButton();
            this.objColorBox = new System.Windows.Forms.PictureBox();
            this.showGrid = new System.Windows.Forms.CheckBox();
            this.colorGroupBox = new System.Windows.Forms.GroupBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.interpolateButton = new System.Windows.Forms.RadioButton();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Canvas)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.zLightTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lightColorBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kd_trackbar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ks_trackbar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_trackbar)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.objColorBox)).BeginInit();
            this.colorGroupBox.SuspendLayout();
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
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1182, 733);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // Canvas
            // 
            this.Canvas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.Canvas.Location = new System.Drawing.Point(37, 3);
            this.Canvas.Name = "Canvas";
            this.Canvas.Size = new System.Drawing.Size(650, 727);
            this.Canvas.TabIndex = 0;
            this.Canvas.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cloudsBox);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.rotateLight);
            this.groupBox1.Controls.Add(this.objBrowseBtn);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.showGrid);
            this.groupBox1.Controls.Add(this.colorGroupBox);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(728, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(451, 727);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Parameters";
            // 
            // cloudsBox
            // 
            this.cloudsBox.AutoSize = true;
            this.cloudsBox.Location = new System.Drawing.Point(303, 684);
            this.cloudsBox.Name = "cloudsBox";
            this.cloudsBox.Size = new System.Drawing.Size(76, 24);
            this.cloudsBox.TabIndex = 18;
            this.cloudsBox.Text = "Clouds";
            this.cloudsBox.UseVisualStyleBackColor = true;
            this.cloudsBox.CheckedChanged += new System.EventHandler(this.cloudsBox_CheckedChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.chooseNormalMapBtn);
            this.groupBox4.Controls.Add(this.useNormalMap);
            this.groupBox4.Location = new System.Drawing.Point(6, 578);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(436, 81);
            this.groupBox4.TabIndex = 17;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Normal vectors map";
            // 
            // chooseNormalMapBtn
            // 
            this.chooseNormalMapBtn.Location = new System.Drawing.Point(156, 36);
            this.chooseNormalMapBtn.Name = "chooseNormalMapBtn";
            this.chooseNormalMapBtn.Size = new System.Drawing.Size(94, 29);
            this.chooseNormalMapBtn.TabIndex = 9;
            this.chooseNormalMapBtn.Text = "Browse";
            this.chooseNormalMapBtn.UseVisualStyleBackColor = true;
            this.chooseNormalMapBtn.Click += new System.EventHandler(this.chooseNormalMapBtn_Click);
            // 
            // useNormalMap
            // 
            this.useNormalMap.AutoSize = true;
            this.useNormalMap.Location = new System.Drawing.Point(10, 39);
            this.useNormalMap.Name = "useNormalMap";
            this.useNormalMap.Size = new System.Drawing.Size(140, 24);
            this.useNormalMap.TabIndex = 0;
            this.useNormalMap.Text = "Use normal map";
            this.useNormalMap.UseVisualStyleBackColor = true;
            this.useNormalMap.CheckedChanged += new System.EventHandler(this.useNormalMap_CheckedChanged);
            // 
            // rotateLight
            // 
            this.rotateLight.AutoSize = true;
            this.rotateLight.Checked = true;
            this.rotateLight.CheckState = System.Windows.Forms.CheckState.Checked;
            this.rotateLight.Location = new System.Drawing.Point(130, 683);
            this.rotateLight.Name = "rotateLight";
            this.rotateLight.Size = new System.Drawing.Size(169, 24);
            this.rotateLight.TabIndex = 16;
            this.rotateLight.Text = "Rotating light source";
            this.rotateLight.UseVisualStyleBackColor = true;
            this.rotateLight.CheckedChanged += new System.EventHandler(this.rotateLight_CheckedChanged);
            // 
            // objBrowseBtn
            // 
            this.objBrowseBtn.Location = new System.Drawing.Point(130, 36);
            this.objBrowseBtn.Name = "objBrowseBtn";
            this.objBrowseBtn.Size = new System.Drawing.Size(94, 29);
            this.objBrowseBtn.TabIndex = 15;
            this.objBrowseBtn.Text = "Browse";
            this.objBrowseBtn.UseVisualStyleBackColor = true;
            this.objBrowseBtn.Click += new System.EventHandler(this.objBrowseBtn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 20);
            this.label4.TabIndex = 14;
            this.label4.Text = "Choose object";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.zLightTrackBar);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.lightColorBox);
            this.groupBox3.Controls.Add(this.kd_trackbar);
            this.groupBox3.Controls.Add(this.ks_trackbar);
            this.groupBox3.Controls.Add(this.m_trackbar);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Location = new System.Drawing.Point(6, 74);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(436, 286);
            this.groupBox3.TabIndex = 13;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Light model";
            // 
            // zLightTrackBar
            // 
            this.zLightTrackBar.Location = new System.Drawing.Point(116, 220);
            this.zLightTrackBar.Maximum = 20;
            this.zLightTrackBar.Name = "zLightTrackBar";
            this.zLightTrackBar.Size = new System.Drawing.Size(292, 56);
            this.zLightTrackBar.SmallChange = 2;
            this.zLightTrackBar.TabIndex = 11;
            this.zLightTrackBar.Value = 9;
            this.zLightTrackBar.ValueChanged += new System.EventHandler(this.zLightTrackBar_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 227);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 20);
            this.label6.TabIndex = 10;
            this.label6.Text = "Light position";
            // 
            // lightColorBox
            // 
            this.lightColorBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lightColorBox.Location = new System.Drawing.Point(105, 172);
            this.lightColorBox.Name = "lightColorBox";
            this.lightColorBox.Size = new System.Drawing.Size(46, 34);
            this.lightColorBox.TabIndex = 9;
            this.lightColorBox.TabStop = false;
            this.lightColorBox.Click += new System.EventHandler(this.lightColorBox_Click);
            // 
            // kd_trackbar
            // 
            this.kd_trackbar.LargeChange = 20;
            this.kd_trackbar.Location = new System.Drawing.Point(91, 23);
            this.kd_trackbar.Maximum = 100;
            this.kd_trackbar.Name = "kd_trackbar";
            this.kd_trackbar.Size = new System.Drawing.Size(317, 56);
            this.kd_trackbar.SmallChange = 5;
            this.kd_trackbar.TabIndex = 0;
            this.kd_trackbar.Value = 80;
            this.kd_trackbar.ValueChanged += new System.EventHandler(this.kd_trackbar_ValueChanged);
            // 
            // ks_trackbar
            // 
            this.ks_trackbar.LargeChange = 20;
            this.ks_trackbar.Location = new System.Drawing.Point(91, 71);
            this.ks_trackbar.Maximum = 100;
            this.ks_trackbar.Name = "ks_trackbar";
            this.ks_trackbar.Size = new System.Drawing.Size(317, 56);
            this.ks_trackbar.SmallChange = 5;
            this.ks_trackbar.TabIndex = 1;
            this.ks_trackbar.Value = 20;
            this.ks_trackbar.ValueChanged += new System.EventHandler(this.ks_trackbar_ValueChanged);
            // 
            // m_trackbar
            // 
            this.m_trackbar.Location = new System.Drawing.Point(91, 121);
            this.m_trackbar.Maximum = 100;
            this.m_trackbar.Minimum = 1;
            this.m_trackbar.Name = "m_trackbar";
            this.m_trackbar.Size = new System.Drawing.Size(317, 56);
            this.m_trackbar.TabIndex = 2;
            this.m_trackbar.Value = 20;
            this.m_trackbar.Scroll += new System.EventHandler(this.m_trackbar_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "k_d factor";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 180);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "Light color";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "k_s factor";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "m factor";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textureBtn);
            this.groupBox2.Controls.Add(this.textureRadioBtn);
            this.groupBox2.Controls.Add(this.solidRadioBtn);
            this.groupBox2.Controls.Add(this.objColorBox);
            this.groupBox2.Location = new System.Drawing.Point(6, 366);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(436, 105);
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
            this.textureBtn.Text = "Browse";
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
            this.showGrid.Location = new System.Drawing.Point(16, 683);
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
            this.colorGroupBox.Location = new System.Drawing.Point(6, 477);
            this.colorGroupBox.Name = "colorGroupBox";
            this.colorGroupBox.Size = new System.Drawing.Size(436, 95);
            this.colorGroupBox.TabIndex = 10;
            this.colorGroupBox.TabStop = false;
            this.colorGroupBox.Text = "Color";
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Checked = true;
            this.radioButton2.Location = new System.Drawing.Point(25, 56);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(65, 24);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "exact";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // interpolateButton
            // 
            this.interpolateButton.AutoSize = true;
            this.interpolateButton.Location = new System.Drawing.Point(25, 26);
            this.interpolateButton.Name = "interpolateButton";
            this.interpolateButton.Size = new System.Drawing.Size(193, 24);
            this.interpolateButton.TabIndex = 0;
            this.interpolateButton.Text = "interpolate from vertices";
            this.interpolateButton.UseVisualStyleBackColor = true;
            this.interpolateButton.CheckedChanged += new System.EventHandler(this.interpolateButton_CheckedChanged);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1182, 733);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Objects animator";
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Canvas)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.zLightTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lightColorBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kd_trackbar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ks_trackbar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_trackbar)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.objColorBox)).EndInit();
            this.colorGroupBox.ResumeLayout(false);
            this.colorGroupBox.PerformLayout();
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
        private Button objBrowseBtn;
        private Label label4;
        private GroupBox groupBox3;
        private TrackBar zLightTrackBar;
        private Label label6;
        private CheckBox rotateLight;
        private GroupBox groupBox4;
        private Button chooseNormalMapBtn;
        private CheckBox useNormalMap;
        private CheckBox cloudsBox;
    }
}