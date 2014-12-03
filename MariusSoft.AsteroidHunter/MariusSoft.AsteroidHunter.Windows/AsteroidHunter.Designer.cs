namespace MariusSoft.AsteroidHunter.Windows
{
    partial class AsteroidHunter
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Modified = new System.Windows.Forms.Label();
            this.lblModifiedStdDev = new System.Windows.Forms.Label();
            this.lblModifiedMedian = new System.Windows.Forms.Label();
            this.lblModifiedMean = new System.Windows.Forms.Label();
            this.lblModifiedMax = new System.Windows.Forms.Label();
            this.lblModifiedMin = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lblInputStdDeviation = new System.Windows.Forms.Label();
            this.lblInputMedian = new System.Windows.Forms.Label();
            this.lblInputMean = new System.Windows.Forms.Label();
            this.lblInputMax = new System.Windows.Forms.Label();
            this.lblInputMin = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbArc = new System.Windows.Forms.RadioButton();
            this.lbGamma = new System.Windows.Forms.Label();
            this.cbGamma = new System.Windows.Forms.ComboBox();
            this.rbGamma = new System.Windows.Forms.RadioButton();
            this.rbExponential = new System.Windows.Forms.RadioButton();
            this.rbLinear = new System.Windows.Forms.RadioButton();
            this.rbLog = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.numScaled = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.btnAutoCalc = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.numWhite = new System.Windows.Forms.NumericUpDown();
            this.numBlack = new System.Windows.Forms.NumericUpDown();
            this.btnZoomIn = new System.Windows.Forms.Button();
            this.btnZoomOut = new System.Windows.Forms.Button();
            this.btnResetZoom = new System.Windows.Forms.Button();
            this.chkDetections = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lblDEC = new System.Windows.Forms.Label();
            this.lblRA = new System.Windows.Forms.Label();
            this.lblY = new System.Windows.Forms.Label();
            this.lblX = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.btnFrame1 = new System.Windows.Forms.Button();
            this.btnFrame2 = new System.Windows.Forms.Button();
            this.btnFrame3 = new System.Windows.Forms.Button();
            this.btnFrame4 = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label16 = new System.Windows.Forms.Label();
            this.comboDetections = new System.Windows.Forms.ComboBox();
            this.elementHost1 = new System.Windows.Forms.Integration.ElementHost();
            this._3Dpanel1 = new MariusSoft.AsteroidHunter.Windows._3Dpanel();
            this.zzzzRangeBar1 = new MariusSoft.AsteroidHunter.Windows.ZzzzRangeBar();
            this.graphControl1 = new PointProcessing.GraphControl();
            this.imagePanelModified = new MariusSoft.AsteroidHunter.Windows.ImagePanel();
            this.imagePanel = new MariusSoft.AsteroidHunter.Windows.ImagePanel();
            this.groupBox1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numScaled)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWhite)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBlack)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 24;
            this.label1.Text = "Default";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(420, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 25;
            this.label2.Text = "Modified";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.Modified);
            this.groupBox1.Controls.Add(this.lblModifiedStdDev);
            this.groupBox1.Controls.Add(this.lblModifiedMedian);
            this.groupBox1.Controls.Add(this.lblModifiedMean);
            this.groupBox1.Controls.Add(this.lblModifiedMax);
            this.groupBox1.Controls.Add(this.lblModifiedMin);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.lblInputStdDeviation);
            this.groupBox1.Controls.Add(this.lblInputMedian);
            this.groupBox1.Controls.Add(this.lblInputMean);
            this.groupBox1.Controls.Add(this.lblInputMax);
            this.groupBox1.Controls.Add(this.lblInputMin);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(823, 445);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(257, 140);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Image Statistics";
            // 
            // Modified
            // 
            this.Modified.AutoSize = true;
            this.Modified.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Modified.Location = new System.Drawing.Point(182, 16);
            this.Modified.Name = "Modified";
            this.Modified.Size = new System.Drawing.Size(55, 13);
            this.Modified.TabIndex = 42;
            this.Modified.Text = "Modified";
            // 
            // lblModifiedStdDev
            // 
            this.lblModifiedStdDev.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblModifiedStdDev.Location = new System.Drawing.Point(182, 120);
            this.lblModifiedStdDev.Name = "lblModifiedStdDev";
            this.lblModifiedStdDev.Size = new System.Drawing.Size(59, 13);
            this.lblModifiedStdDev.TabIndex = 41;
            this.lblModifiedStdDev.Text = "0";
            this.lblModifiedStdDev.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblModifiedMedian
            // 
            this.lblModifiedMedian.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblModifiedMedian.Location = new System.Drawing.Point(182, 95);
            this.lblModifiedMedian.Name = "lblModifiedMedian";
            this.lblModifiedMedian.Size = new System.Drawing.Size(59, 13);
            this.lblModifiedMedian.TabIndex = 40;
            this.lblModifiedMedian.Text = "0";
            this.lblModifiedMedian.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblModifiedMean
            // 
            this.lblModifiedMean.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblModifiedMean.Location = new System.Drawing.Point(182, 77);
            this.lblModifiedMean.Name = "lblModifiedMean";
            this.lblModifiedMean.Size = new System.Drawing.Size(59, 13);
            this.lblModifiedMean.TabIndex = 39;
            this.lblModifiedMean.Text = "0";
            this.lblModifiedMean.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblModifiedMax
            // 
            this.lblModifiedMax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblModifiedMax.Location = new System.Drawing.Point(182, 55);
            this.lblModifiedMax.Name = "lblModifiedMax";
            this.lblModifiedMax.Size = new System.Drawing.Size(59, 13);
            this.lblModifiedMax.TabIndex = 38;
            this.lblModifiedMax.Text = "0";
            this.lblModifiedMax.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblModifiedMin
            // 
            this.lblModifiedMin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblModifiedMin.Location = new System.Drawing.Point(182, 37);
            this.lblModifiedMin.Name = "lblModifiedMin";
            this.lblModifiedMin.Size = new System.Drawing.Size(59, 13);
            this.lblModifiedMin.TabIndex = 37;
            this.lblModifiedMin.Text = "0";
            this.lblModifiedMin.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(85, 16);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(36, 13);
            this.label13.TabIndex = 36;
            this.label13.Text = "Input";
            // 
            // lblInputStdDeviation
            // 
            this.lblInputStdDeviation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInputStdDeviation.Location = new System.Drawing.Point(85, 120);
            this.lblInputStdDeviation.Name = "lblInputStdDeviation";
            this.lblInputStdDeviation.Size = new System.Drawing.Size(59, 13);
            this.lblInputStdDeviation.TabIndex = 35;
            this.lblInputStdDeviation.Text = "0";
            this.lblInputStdDeviation.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblInputMedian
            // 
            this.lblInputMedian.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInputMedian.Location = new System.Drawing.Point(85, 95);
            this.lblInputMedian.Name = "lblInputMedian";
            this.lblInputMedian.Size = new System.Drawing.Size(59, 13);
            this.lblInputMedian.TabIndex = 34;
            this.lblInputMedian.Text = "0";
            this.lblInputMedian.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblInputMean
            // 
            this.lblInputMean.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInputMean.Location = new System.Drawing.Point(85, 77);
            this.lblInputMean.Name = "lblInputMean";
            this.lblInputMean.Size = new System.Drawing.Size(59, 13);
            this.lblInputMean.TabIndex = 33;
            this.lblInputMean.Text = "0";
            this.lblInputMean.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblInputMax
            // 
            this.lblInputMax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInputMax.Location = new System.Drawing.Point(85, 55);
            this.lblInputMax.Name = "lblInputMax";
            this.lblInputMax.Size = new System.Drawing.Size(59, 13);
            this.lblInputMax.TabIndex = 32;
            this.lblInputMax.Text = "0";
            this.lblInputMax.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblInputMin
            // 
            this.lblInputMin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInputMin.Location = new System.Drawing.Point(85, 37);
            this.lblInputMin.Name = "lblInputMin";
            this.lblInputMin.Size = new System.Drawing.Size(59, 13);
            this.lblInputMin.TabIndex = 31;
            this.lblInputMin.Text = "0";
            this.lblInputMin.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 120);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 13);
            this.label7.TabIndex = 30;
            this.label7.Text = "StdDev";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 95);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 13);
            this.label6.TabIndex = 29;
            this.label6.Text = "Median";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 77);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 28;
            this.label5.Text = "Mean";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 13);
            this.label4.TabIndex = 27;
            this.label4.Text = "Max";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 13);
            this.label3.TabIndex = 26;
            this.label3.Text = "Min";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel2,
            this.lblStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 654);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1364, 22);
            this.statusStrip1.TabIndex = 27;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(42, 17);
            this.toolStripStatusLabel2.Text = "Status:";
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(52, 17);
            this.lblStatus.Text = "lblStatus";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.rbArc);
            this.groupBox2.Controls.Add(this.lbGamma);
            this.groupBox2.Controls.Add(this.cbGamma);
            this.groupBox2.Controls.Add(this.rbGamma);
            this.groupBox2.Controls.Add(this.rbExponential);
            this.groupBox2.Controls.Add(this.rbLinear);
            this.groupBox2.Controls.Add(this.rbLog);
            this.groupBox2.Location = new System.Drawing.Point(1087, 518);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(257, 114);
            this.groupBox2.TabIndex = 30;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Scaling Algorithms";
            // 
            // rbArc
            // 
            this.rbArc.AutoSize = true;
            this.rbArc.Checked = true;
            this.rbArc.Enabled = false;
            this.rbArc.Location = new System.Drawing.Point(126, 19);
            this.rbArc.Name = "rbArc";
            this.rbArc.Size = new System.Drawing.Size(75, 17);
            this.rbArc.TabIndex = 8;
            this.rbArc.TabStop = true;
            this.rbArc.Text = "ArcSinH(x)";
            this.rbArc.UseVisualStyleBackColor = true;
            this.rbArc.CheckedChanged += new System.EventHandler(this.rbLinear_CheckedChanged);
            // 
            // lbGamma
            // 
            this.lbGamma.AutoSize = true;
            this.lbGamma.Location = new System.Drawing.Point(123, 90);
            this.lbGamma.Name = "lbGamma";
            this.lbGamma.Size = new System.Drawing.Size(34, 13);
            this.lbGamma.TabIndex = 7;
            this.lbGamma.Text = "Value";
            // 
            // cbGamma
            // 
            this.cbGamma.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGamma.Enabled = false;
            this.cbGamma.FormattingEnabled = true;
            this.cbGamma.Items.AddRange(new object[] {
            "5.0",
            "4.5",
            "4.0",
            "3.5",
            "3.0",
            "2.5",
            "2.0",
            "1.8",
            "1.6",
            "1.4",
            "1.2",
            "1.0",
            "0.9",
            "0.8",
            "0.7",
            "0.6",
            "0.5",
            "0.4",
            "0.3",
            "0.2",
            "0.1"});
            this.cbGamma.Location = new System.Drawing.Point(165, 85);
            this.cbGamma.Name = "cbGamma";
            this.cbGamma.Size = new System.Drawing.Size(50, 21);
            this.cbGamma.TabIndex = 6;
            // 
            // rbGamma
            // 
            this.rbGamma.AutoSize = true;
            this.rbGamma.Enabled = false;
            this.rbGamma.Location = new System.Drawing.Point(17, 88);
            this.rbGamma.Name = "rbGamma";
            this.rbGamma.Size = new System.Drawing.Size(61, 17);
            this.rbGamma.TabIndex = 5;
            this.rbGamma.Text = "Gamma";
            this.rbGamma.UseVisualStyleBackColor = true;
            this.rbGamma.CheckedChanged += new System.EventHandler(this.rbLinear_CheckedChanged);
            // 
            // rbExponential
            // 
            this.rbExponential.AutoSize = true;
            this.rbExponential.Enabled = false;
            this.rbExponential.Location = new System.Drawing.Point(17, 65);
            this.rbExponential.Name = "rbExponential";
            this.rbExponential.Size = new System.Drawing.Size(80, 17);
            this.rbExponential.TabIndex = 4;
            this.rbExponential.Text = "Exponential";
            this.rbExponential.UseVisualStyleBackColor = true;
            this.rbExponential.CheckedChanged += new System.EventHandler(this.rbLinear_CheckedChanged);
            // 
            // rbLinear
            // 
            this.rbLinear.AutoSize = true;
            this.rbLinear.Enabled = false;
            this.rbLinear.Location = new System.Drawing.Point(17, 19);
            this.rbLinear.Name = "rbLinear";
            this.rbLinear.Size = new System.Drawing.Size(54, 17);
            this.rbLinear.TabIndex = 2;
            this.rbLinear.Text = "Linear";
            this.rbLinear.UseVisualStyleBackColor = true;
            this.rbLinear.CheckedChanged += new System.EventHandler(this.rbLinear_CheckedChanged);
            // 
            // rbLog
            // 
            this.rbLog.AutoSize = true;
            this.rbLog.Enabled = false;
            this.rbLog.Location = new System.Drawing.Point(17, 42);
            this.rbLog.Name = "rbLog";
            this.rbLog.Size = new System.Drawing.Size(43, 17);
            this.rbLog.TabIndex = 3;
            this.rbLog.Text = "Log";
            this.rbLog.UseVisualStyleBackColor = true;
            this.rbLog.CheckedChanged += new System.EventHandler(this.rbLinear_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox3.Controls.Add(this.numScaled);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.btnAutoCalc);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.numWhite);
            this.groupBox3.Controls.Add(this.numBlack);
            this.groupBox3.Location = new System.Drawing.Point(1086, 369);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(270, 136);
            this.groupBox3.TabIndex = 31;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Normalize";
            // 
            // numScaled
            // 
            this.numScaled.Enabled = false;
            this.numScaled.Location = new System.Drawing.Point(121, 74);
            this.numScaled.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.numScaled.Name = "numScaled";
            this.numScaled.Size = new System.Drawing.Size(120, 20);
            this.numScaled.TabIndex = 31;
            this.numScaled.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numScaled.ValueChanged += new System.EventHandler(this.numBlack_ValueChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(9, 78);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(92, 13);
            this.label10.TabIndex = 30;
            this.label10.Text = "Scaled peak level";
            // 
            // btnAutoCalc
            // 
            this.btnAutoCalc.Enabled = false;
            this.btnAutoCalc.Location = new System.Drawing.Point(9, 107);
            this.btnAutoCalc.Name = "btnAutoCalc";
            this.btnAutoCalc.Size = new System.Drawing.Size(232, 23);
            this.btnAutoCalc.TabIndex = 29;
            this.btnAutoCalc.Text = "Auto Calculate";
            this.btnAutoCalc.UseVisualStyleBackColor = true;
            this.btnAutoCalc.Click += new System.EventHandler(this.btnAutoCalc_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(9, 50);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(57, 13);
            this.label9.TabIndex = 28;
            this.label9.Text = "Peak level";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 23);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(90, 13);
            this.label8.TabIndex = 27;
            this.label8.Text = "Background level";
            // 
            // numWhite
            // 
            this.numWhite.Enabled = false;
            this.numWhite.Location = new System.Drawing.Point(121, 46);
            this.numWhite.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numWhite.Name = "numWhite";
            this.numWhite.Size = new System.Drawing.Size(120, 20);
            this.numWhite.TabIndex = 1;
            this.numWhite.Value = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numWhite.ValueChanged += new System.EventHandler(this.numBlack_ValueChanged);
            // 
            // numBlack
            // 
            this.numBlack.Enabled = false;
            this.numBlack.Location = new System.Drawing.Point(121, 19);
            this.numBlack.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numBlack.Name = "numBlack";
            this.numBlack.Size = new System.Drawing.Size(120, 20);
            this.numBlack.TabIndex = 0;
            this.numBlack.ValueChanged += new System.EventHandler(this.numBlack_ValueChanged);
            // 
            // btnZoomIn
            // 
            this.btnZoomIn.Enabled = false;
            this.btnZoomIn.Location = new System.Drawing.Point(382, 2);
            this.btnZoomIn.Name = "btnZoomIn";
            this.btnZoomIn.Size = new System.Drawing.Size(23, 23);
            this.btnZoomIn.TabIndex = 36;
            this.btnZoomIn.Text = "+";
            this.btnZoomIn.UseVisualStyleBackColor = true;
            this.btnZoomIn.Click += new System.EventHandler(this.btnZoomIn_Click);
            // 
            // btnZoomOut
            // 
            this.btnZoomOut.Enabled = false;
            this.btnZoomOut.Location = new System.Drawing.Point(353, 2);
            this.btnZoomOut.Name = "btnZoomOut";
            this.btnZoomOut.Size = new System.Drawing.Size(23, 23);
            this.btnZoomOut.TabIndex = 37;
            this.btnZoomOut.Text = "-";
            this.btnZoomOut.UseVisualStyleBackColor = true;
            this.btnZoomOut.Click += new System.EventHandler(this.btnZoomOut_Click);
            // 
            // btnResetZoom
            // 
            this.btnResetZoom.Enabled = false;
            this.btnResetZoom.Location = new System.Drawing.Point(324, 2);
            this.btnResetZoom.Name = "btnResetZoom";
            this.btnResetZoom.Size = new System.Drawing.Size(23, 23);
            this.btnResetZoom.TabIndex = 38;
            this.btnResetZoom.Text = ".";
            this.btnResetZoom.UseVisualStyleBackColor = true;
            this.btnResetZoom.Click += new System.EventHandler(this.btnResetZoom_Click);
            // 
            // chkDetections
            // 
            this.chkDetections.AutoSize = true;
            this.chkDetections.Checked = true;
            this.chkDetections.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDetections.Enabled = false;
            this.chkDetections.Location = new System.Drawing.Point(707, 5);
            this.chkDetections.Name = "chkDetections";
            this.chkDetections.Size = new System.Drawing.Size(103, 17);
            this.chkDetections.TabIndex = 39;
            this.chkDetections.Text = "Draw detections";
            this.chkDetections.UseVisualStyleBackColor = true;
            this.chkDetections.CheckedChanged += new System.EventHandler(this.chkDetections_CheckedChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox4.Controls.Add(this.lblDEC);
            this.groupBox4.Controls.Add(this.lblRA);
            this.groupBox4.Controls.Add(this.lblY);
            this.groupBox4.Controls.Add(this.lblX);
            this.groupBox4.Controls.Add(this.label15);
            this.groupBox4.Controls.Add(this.label14);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Location = new System.Drawing.Point(823, 369);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(257, 70);
            this.groupBox4.TabIndex = 40;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Image Data";
            // 
            // lblDEC
            // 
            this.lblDEC.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDEC.Location = new System.Drawing.Point(178, 45);
            this.lblDEC.Name = "lblDEC";
            this.lblDEC.Size = new System.Drawing.Size(59, 13);
            this.lblDEC.TabIndex = 46;
            this.lblDEC.Text = "0";
            this.lblDEC.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblRA
            // 
            this.lblRA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRA.Location = new System.Drawing.Point(178, 26);
            this.lblRA.Name = "lblRA";
            this.lblRA.Size = new System.Drawing.Size(59, 13);
            this.lblRA.TabIndex = 45;
            this.lblRA.Text = "0";
            this.lblRA.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblY
            // 
            this.lblY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblY.Location = new System.Drawing.Point(62, 45);
            this.lblY.Name = "lblY";
            this.lblY.Size = new System.Drawing.Size(59, 13);
            this.lblY.TabIndex = 44;
            this.lblY.Text = "0";
            this.lblY.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblX
            // 
            this.lblX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblX.Location = new System.Drawing.Point(62, 26);
            this.lblX.Name = "lblX";
            this.lblX.Size = new System.Drawing.Size(59, 13);
            this.lblX.TabIndex = 43;
            this.lblX.Text = "0";
            this.lblX.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(140, 45);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(29, 13);
            this.label15.TabIndex = 30;
            this.label15.Text = "DEC";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(140, 26);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(22, 13);
            this.label14.TabIndex = 29;
            this.label14.Text = "RA";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(9, 45);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(14, 13);
            this.label12.TabIndex = 28;
            this.label12.Text = "Y";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(9, 26);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(14, 13);
            this.label11.TabIndex = 27;
            this.label11.Text = "X";
            // 
            // btnFrame1
            // 
            this.btnFrame1.Location = new System.Drawing.Point(15, 442);
            this.btnFrame1.Name = "btnFrame1";
            this.btnFrame1.Size = new System.Drawing.Size(24, 23);
            this.btnFrame1.TabIndex = 41;
            this.btnFrame1.Text = "1";
            this.btnFrame1.UseVisualStyleBackColor = true;
            this.btnFrame1.Click += new System.EventHandler(this.btnFrame1_Click);
            // 
            // btnFrame2
            // 
            this.btnFrame2.Location = new System.Drawing.Point(45, 442);
            this.btnFrame2.Name = "btnFrame2";
            this.btnFrame2.Size = new System.Drawing.Size(24, 23);
            this.btnFrame2.TabIndex = 42;
            this.btnFrame2.Text = "2";
            this.btnFrame2.UseVisualStyleBackColor = true;
            this.btnFrame2.Click += new System.EventHandler(this.btnFrame1_Click);
            // 
            // btnFrame3
            // 
            this.btnFrame3.Location = new System.Drawing.Point(75, 442);
            this.btnFrame3.Name = "btnFrame3";
            this.btnFrame3.Size = new System.Drawing.Size(24, 23);
            this.btnFrame3.TabIndex = 43;
            this.btnFrame3.Text = "3";
            this.btnFrame3.UseVisualStyleBackColor = true;
            this.btnFrame3.Click += new System.EventHandler(this.btnFrame1_Click);
            // 
            // btnFrame4
            // 
            this.btnFrame4.Location = new System.Drawing.Point(105, 442);
            this.btnFrame4.Name = "btnFrame4";
            this.btnFrame4.Size = new System.Drawing.Size(24, 23);
            this.btnFrame4.TabIndex = 44;
            this.btnFrame4.Text = "4";
            this.btnFrame4.UseVisualStyleBackColor = true;
            this.btnFrame4.Click += new System.EventHandler(this.btnFrame1_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox5.Controls.Add(this.label16);
            this.groupBox5.Controls.Add(this.comboDetections);
            this.groupBox5.Location = new System.Drawing.Point(824, 596);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(256, 52);
            this.groupBox5.TabIndex = 45;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Detections";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(13, 22);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(30, 13);
            this.label16.TabIndex = 43;
            this.label16.Text = "Goto";
            // 
            // comboDetections
            // 
            this.comboDetections.FormattingEnabled = true;
            this.comboDetections.Location = new System.Drawing.Point(49, 19);
            this.comboDetections.Name = "comboDetections";
            this.comboDetections.Size = new System.Drawing.Size(191, 21);
            this.comboDetections.TabIndex = 0;
            this.comboDetections.SelectedIndexChanged += new System.EventHandler(this.comboDetections_SelectedIndexChanged);
            // 
            // elementHost1
            // 
            this.elementHost1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.elementHost1.Location = new System.Drawing.Point(824, 12);
            this.elementHost1.Name = "elementHost1";
            this.elementHost1.Size = new System.Drawing.Size(527, 340);
            this.elementHost1.TabIndex = 46;
            this.elementHost1.Text = "elementHost1";
            this.elementHost1.Child = this._3Dpanel1;
            // 
            // zzzzRangeBar1
            // 
            this.zzzzRangeBar1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.zzzzRangeBar1.DivisionNum = 100;
            this.zzzzRangeBar1.Enabled = false;
            this.zzzzRangeBar1.HeightOfBar = 8;
            this.zzzzRangeBar1.HeightOfMark = 24;
            this.zzzzRangeBar1.HeightOfTick = 6;
            this.zzzzRangeBar1.InnerColor = System.Drawing.Color.LightGreen;
            this.zzzzRangeBar1.Location = new System.Drawing.Point(15, 605);
            this.zzzzRangeBar1.Name = "zzzzRangeBar1";
            this.zzzzRangeBar1.Orientation = MariusSoft.AsteroidHunter.Windows.ZzzzRangeBar.RangeBarOrientation.horizontal;
            this.zzzzRangeBar1.RangeMaximum = 100;
            this.zzzzRangeBar1.RangeMinimum = 0;
            this.zzzzRangeBar1.ScaleOrientation = MariusSoft.AsteroidHunter.Windows.ZzzzRangeBar.TopBottomOrientation.bottom;
            this.zzzzRangeBar1.Size = new System.Drawing.Size(795, 43);
            this.zzzzRangeBar1.TabIndex = 35;
            this.zzzzRangeBar1.TotalMaximum = 100;
            this.zzzzRangeBar1.TotalMinimum = 0;
            this.zzzzRangeBar1.RangeChanged += new MariusSoft.AsteroidHunter.Windows.ZzzzRangeBar.RangeChangedEventHandler(this.levelMin_Scroll);
            // 
            // graphControl1
            // 
            this.graphControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.graphControl1.BackColor = System.Drawing.SystemColors.Control;
            this.graphControl1.Location = new System.Drawing.Point(15, 471);
            this.graphControl1.Margin = new System.Windows.Forms.Padding(0);
            this.graphControl1.Name = "graphControl1";
            this.graphControl1.Size = new System.Drawing.Size(795, 131);
            this.graphControl1.TabIndex = 34;
            // 
            // imagePanelModified
            // 
            this.imagePanelModified.Location = new System.Drawing.Point(420, 28);
            this.imagePanelModified.Name = "imagePanelModified";
            this.imagePanelModified.Size = new System.Drawing.Size(390, 410);
            this.imagePanelModified.TabIndex = 29;
            this.imagePanelModified.Scrolled += new MariusSoft.AsteroidHunter.Windows.ImagePanel.PointHandlerDouble(this.imagePanelModified_Scrolled);
            this.imagePanelModified.MouseMove += new MariusSoft.AsteroidHunter.Windows.ImagePanel.PointHandler(this.imagePanel_MouseMove);
            // 
            // imagePanel
            // 
            this.imagePanel.Location = new System.Drawing.Point(15, 28);
            this.imagePanel.Name = "imagePanel";
            this.imagePanel.Size = new System.Drawing.Size(390, 410);
            this.imagePanel.TabIndex = 28;
            this.imagePanel.Scrolled += new MariusSoft.AsteroidHunter.Windows.ImagePanel.PointHandlerDouble(this.imagePanel_Scrolled);
            this.imagePanel.MouseMove += new MariusSoft.AsteroidHunter.Windows.ImagePanel.PointHandler(this.imagePanel_MouseMove);
            // 
            // AsteroidHunter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1364, 676);
            this.Controls.Add(this.elementHost1);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.btnFrame4);
            this.Controls.Add(this.btnFrame3);
            this.Controls.Add(this.btnFrame2);
            this.Controls.Add(this.btnFrame1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.chkDetections);
            this.Controls.Add(this.btnResetZoom);
            this.Controls.Add(this.btnZoomOut);
            this.Controls.Add(this.btnZoomIn);
            this.Controls.Add(this.zzzzRangeBar1);
            this.Controls.Add(this.graphControl1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.imagePanelModified);
            this.Controls.Add(this.imagePanel);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AsteroidHunter";
            this.Text = "AsteroidHunter";
            this.Load += new System.EventHandler(this.AsteroidHunter_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numScaled)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWhite)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBlack)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblInputStdDeviation;
        private System.Windows.Forms.Label lblInputMedian;
        private System.Windows.Forms.Label lblInputMean;
        private System.Windows.Forms.Label lblInputMax;
        private System.Windows.Forms.Label lblInputMin;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private ImagePanel imagePanel;
        private ImagePanel imagePanelModified;
        private System.Windows.Forms.Label Modified;
        private System.Windows.Forms.Label lblModifiedStdDev;
        private System.Windows.Forms.Label lblModifiedMedian;
        private System.Windows.Forms.Label lblModifiedMean;
        private System.Windows.Forms.Label lblModifiedMax;
        private System.Windows.Forms.Label lblModifiedMin;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbArc;
        private System.Windows.Forms.Label lbGamma;
        private System.Windows.Forms.ComboBox cbGamma;
        private System.Windows.Forms.RadioButton rbGamma;
        private System.Windows.Forms.RadioButton rbExponential;
        private System.Windows.Forms.RadioButton rbLinear;
        private System.Windows.Forms.RadioButton rbLog;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnAutoCalc;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown numWhite;
        private System.Windows.Forms.NumericUpDown numBlack;
        private System.Windows.Forms.NumericUpDown numScaled;
        private System.Windows.Forms.Label label10;
        private PointProcessing.GraphControl graphControl1;
        private ZzzzRangeBar zzzzRangeBar1;
        private System.Windows.Forms.Button btnZoomIn;
        private System.Windows.Forms.Button btnZoomOut;
        private System.Windows.Forms.Button btnResetZoom;
        private System.Windows.Forms.CheckBox chkDetections;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblDEC;
        private System.Windows.Forms.Label lblRA;
        private System.Windows.Forms.Label lblY;
        private System.Windows.Forms.Label lblX;
        private System.Windows.Forms.Button btnFrame1;
        private System.Windows.Forms.Button btnFrame2;
        private System.Windows.Forms.Button btnFrame3;
        private System.Windows.Forms.Button btnFrame4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox comboDetections;
        private System.Windows.Forms.Integration.ElementHost elementHost1;
        private _3Dpanel _3Dpanel1;
    }
}