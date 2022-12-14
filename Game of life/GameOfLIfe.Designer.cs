namespace Game_of_life
{
    partial class GameOfLIfeForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameOfLIfeForm));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label2 = new System.Windows.Forms.Label();
            this.CBselectedGeneration = new System.Windows.Forms.ComboBox();
            this.DUDuniverseFormat = new System.Windows.Forms.DomainUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.Continue = new System.Windows.Forms.Button();
            this.NUDgenRate = new System.Windows.Forms.NumericUpDown();
            this.Generation_rate = new System.Windows.Forms.Label();
            this.Clear = new System.Windows.Forms.Button();
            this.Pause = new System.Windows.Forms.Button();
            this.Start = new System.Windows.Forms.Button();
            this.NUDdensity = new System.Windows.Forms.NumericUpDown();
            this.Density = new System.Windows.Forms.Label();
            this.NUDresolution = new System.Windows.Forms.NumericUpDown();
            this.Resolution = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUDgenRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDdensity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDresolution)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.Black;
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.Black;
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.CBselectedGeneration);
            this.splitContainer1.Panel1.Controls.Add(this.DUDuniverseFormat);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.Continue);
            this.splitContainer1.Panel1.Controls.Add(this.NUDgenRate);
            this.splitContainer1.Panel1.Controls.Add(this.Generation_rate);
            this.splitContainer1.Panel1.Controls.Add(this.Clear);
            this.splitContainer1.Panel1.Controls.Add(this.Pause);
            this.splitContainer1.Panel1.Controls.Add(this.Start);
            this.splitContainer1.Panel1.Controls.Add(this.NUDdensity);
            this.splitContainer1.Panel1.Controls.Add(this.Density);
            this.splitContainer1.Panel1.Controls.Add(this.NUDresolution);
            this.splitContainer1.Panel1.Controls.Add(this.Resolution);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.pictureBox1);
            this.splitContainer1.Size = new System.Drawing.Size(1920, 663);
            this.splitContainer1.SplitterDistance = 122;
            this.splitContainer1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Unispace", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.label2.Location = new System.Drawing.Point(477, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(321, 36);
            this.label2.TabIndex = 19;
            this.label2.Text = "First generation:";
            // 
            // CBselectedGeneration
            // 
            this.CBselectedGeneration.AutoCompleteCustomSource.AddRange(new string[] {
            "Random",
            "My",
            "Gun template",
            "Loaf template"});
            this.CBselectedGeneration.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.CBselectedGeneration.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.CBselectedGeneration.BackColor = System.Drawing.SystemColors.InfoText;
            this.CBselectedGeneration.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CBselectedGeneration.Font = new System.Drawing.Font("Unispace", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CBselectedGeneration.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.CBselectedGeneration.FormattingEnabled = true;
            this.CBselectedGeneration.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.CBselectedGeneration.Items.AddRange(new object[] {
            "Random",
            "My",
            "Gun template",
            "Loafer template"});
            this.CBselectedGeneration.Location = new System.Drawing.Point(848, 50);
            this.CBselectedGeneration.Name = "CBselectedGeneration";
            this.CBselectedGeneration.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CBselectedGeneration.Size = new System.Drawing.Size(340, 44);
            this.CBselectedGeneration.TabIndex = 18;
            this.CBselectedGeneration.SelectedIndexChanged += new System.EventHandler(this.CBselectedGeneration_SelectedIndexChanged);
            // 
            // DUDuniverseFormat
            // 
            this.DUDuniverseFormat.BackColor = System.Drawing.SystemColors.InfoText;
            this.DUDuniverseFormat.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DUDuniverseFormat.Font = new System.Drawing.Font("Unispace", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DUDuniverseFormat.ForeColor = System.Drawing.Color.Fuchsia;
            this.DUDuniverseFormat.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.DUDuniverseFormat.Items.Add("Closed");
            this.DUDuniverseFormat.Items.Add("Limited");
            this.DUDuniverseFormat.Location = new System.Drawing.Point(1237, 51);
            this.DUDuniverseFormat.Name = "DUDuniverseFormat";
            this.DUDuniverseFormat.ReadOnly = true;
            this.DUDuniverseFormat.Size = new System.Drawing.Size(182, 43);
            this.DUDuniverseFormat.TabIndex = 16;
            this.DUDuniverseFormat.TabStop = false;
            this.DUDuniverseFormat.Text = "Closed";
            this.DUDuniverseFormat.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.DUDuniverseFormat.Wrap = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Unispace", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(1414, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(186, 41);
            this.label1.TabIndex = 15;
            this.label1.Text = "universe";
            // 
            // Continue
            // 
            this.Continue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Continue.Font = new System.Drawing.Font("Unispace", 22.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Continue.ForeColor = System.Drawing.Color.Lime;
            this.Continue.Location = new System.Drawing.Point(1772, 80);
            this.Continue.Name = "Continue";
            this.Continue.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Continue.Size = new System.Drawing.Size(56, 43);
            this.Continue.TabIndex = 13;
            this.Continue.Text = ">";
            this.Continue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Continue.UseVisualStyleBackColor = true;
            this.Continue.Click += new System.EventHandler(this.Continue_Click);
            // 
            // NUDgenRate
            // 
            this.NUDgenRate.BackColor = System.Drawing.SystemColors.InfoText;
            this.NUDgenRate.Font = new System.Drawing.Font("Unispace", 16F, System.Drawing.FontStyle.Bold);
            this.NUDgenRate.ForeColor = System.Drawing.SystemColors.Control;
            this.NUDgenRate.Location = new System.Drawing.Point(329, 83);
            this.NUDgenRate.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.NUDgenRate.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NUDgenRate.Name = "NUDgenRate";
            this.NUDgenRate.Size = new System.Drawing.Size(113, 39);
            this.NUDgenRate.TabIndex = 9;
            this.NUDgenRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.NUDgenRate.Value = new decimal(new int[] {
            45,
            0,
            0,
            0});
            // 
            // Generation_rate
            // 
            this.Generation_rate.AutoSize = true;
            this.Generation_rate.Font = new System.Drawing.Font("Unispace", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Generation_rate.ForeColor = System.Drawing.SystemColors.Control;
            this.Generation_rate.Location = new System.Drawing.Point(43, 85);
            this.Generation_rate.Name = "Generation_rate";
            this.Generation_rate.Size = new System.Drawing.Size(270, 34);
            this.Generation_rate.TabIndex = 7;
            this.Generation_rate.Text = "Generation rate";
            // 
            // Clear
            // 
            this.Clear.BackColor = System.Drawing.SystemColors.InfoText;
            this.Clear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Clear.Font = new System.Drawing.Font("Unispace", 16F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Clear.ForeColor = System.Drawing.SystemColors.Control;
            this.Clear.Location = new System.Drawing.Point(1700, 22);
            this.Clear.Name = "Clear";
            this.Clear.Size = new System.Drawing.Size(128, 43);
            this.Clear.TabIndex = 6;
            this.Clear.Text = "Clear";
            this.Clear.UseVisualStyleBackColor = false;
            this.Clear.Click += new System.EventHandler(this.Clear_Click);
            // 
            // Pause
            // 
            this.Pause.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Pause.Font = new System.Drawing.Font("Unispace", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Pause.ForeColor = System.Drawing.Color.Yellow;
            this.Pause.Location = new System.Drawing.Point(1700, 80);
            this.Pause.Name = "Pause";
            this.Pause.Size = new System.Drawing.Size(66, 43);
            this.Pause.TabIndex = 5;
            this.Pause.Text = "||";
            this.Pause.UseVisualStyleBackColor = true;
            this.Pause.Click += new System.EventHandler(this.Pause_Click);
            // 
            // Start
            // 
            this.Start.BackColor = System.Drawing.SystemColors.InfoText;
            this.Start.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Start.FlatAppearance.BorderSize = 3;
            this.Start.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Start.Font = new System.Drawing.Font("Unispace", 17F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Start.ForeColor = System.Drawing.Color.SpringGreen;
            this.Start.Location = new System.Drawing.Point(1872, 33);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(130, 83);
            this.Start.TabIndex = 4;
            this.Start.Text = "Start";
            this.Start.UseVisualStyleBackColor = true;
            this.Start.Click += new System.EventHandler(this.Start_Click);
            // 
            // NUDdensity
            // 
            this.NUDdensity.BackColor = System.Drawing.SystemColors.InfoText;
            this.NUDdensity.Font = new System.Drawing.Font("Unispace", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NUDdensity.ForeColor = System.Drawing.SystemColors.Control;
            this.NUDdensity.Location = new System.Drawing.Point(1021, 100);
            this.NUDdensity.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.NUDdensity.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.NUDdensity.Name = "NUDdensity";
            this.NUDdensity.Size = new System.Drawing.Size(90, 35);
            this.NUDdensity.TabIndex = 3;
            this.NUDdensity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.NUDdensity.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
            // 
            // Density
            // 
            this.Density.AutoSize = true;
            this.Density.Font = new System.Drawing.Font("Unispace", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Density.ForeColor = System.Drawing.SystemColors.Control;
            this.Density.Location = new System.Drawing.Point(901, 102);
            this.Density.Name = "Density";
            this.Density.Size = new System.Drawing.Size(124, 28);
            this.Density.TabIndex = 2;
            this.Density.Text = "Density ";
            this.toolTip1.SetToolTip(this.Density, "Parameter for random generation only");
            // 
            // NUDresolution
            // 
            this.NUDresolution.BackColor = System.Drawing.SystemColors.InfoText;
            this.NUDresolution.Font = new System.Drawing.Font("Unispace", 16F, System.Drawing.FontStyle.Bold);
            this.NUDresolution.ForeColor = System.Drawing.SystemColors.Control;
            this.NUDresolution.Location = new System.Drawing.Point(329, 28);
            this.NUDresolution.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.NUDresolution.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.NUDresolution.Name = "NUDresolution";
            this.NUDresolution.Size = new System.Drawing.Size(113, 39);
            this.NUDresolution.TabIndex = 1;
            this.NUDresolution.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.NUDresolution.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // Resolution
            // 
            this.Resolution.AutoSize = true;
            this.Resolution.Font = new System.Drawing.Font("Unispace", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Resolution.ForeColor = System.Drawing.SystemColors.Control;
            this.Resolution.Location = new System.Drawing.Point(91, 33);
            this.Resolution.Name = "Resolution";
            this.Resolution.Size = new System.Drawing.Size(185, 34);
            this.Resolution.TabIndex = 0;
            this.Resolution.Text = "Resolution";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1916, 533);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CellClickHandler);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.CellClickMoveHandler);
            // 
            // timer1
            // 
            this.timer1.Interval = 45;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // GameOfLIfeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1920, 663);
            this.Controls.Add(this.splitContainer1);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "GameOfLIfeForm";
            this.Text = "Game of lIfe";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.NUDgenRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDdensity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDresolution)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.NumericUpDown NUDresolution;
        private System.Windows.Forms.Label Resolution;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.NumericUpDown NUDdensity;
        private System.Windows.Forms.Label Density;
        private System.Windows.Forms.Button Clear;
        private System.Windows.Forms.Button Pause;
        private System.Windows.Forms.Button Start;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label Generation_rate;
        private System.Windows.Forms.NumericUpDown NUDgenRate;
        private System.Windows.Forms.Button Continue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DomainUpDown DUDuniverseFormat;
        private System.Windows.Forms.ComboBox CBselectedGeneration;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolTip toolTip2;
    }
}

