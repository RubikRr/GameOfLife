namespace GameOfLife
{
    partial class Universe
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
            this.components = new System.ComponentModel.Container();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.stop = new System.Windows.Forms.Button();
            this.start = new System.Windows.Forms.Button();
            this.density = new System.Windows.Forms.NumericUpDown();
            this.DensityLable = new System.Windows.Forms.Label();
            this.resolution = new System.Windows.Forms.NumericUpDown();
            this.ResolutionLabel = new System.Windows.Forms.Label();
            this.map = new System.Windows.Forms.PictureBox();
            this.timer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.density)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resolution)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.map)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer.IsSplitterFixed = true;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.stop);
            this.splitContainer.Panel1.Controls.Add(this.start);
            this.splitContainer.Panel1.Controls.Add(this.density);
            this.splitContainer.Panel1.Controls.Add(this.DensityLable);
            this.splitContainer.Panel1.Controls.Add(this.resolution);
            this.splitContainer.Panel1.Controls.Add(this.ResolutionLabel);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.map);
            this.splitContainer.Size = new System.Drawing.Size(734, 461);
            this.splitContainer.SplitterDistance = 181;
            this.splitContainer.TabIndex = 0;
            // 
            // stop
            // 
            this.stop.Location = new System.Drawing.Point(91, 175);
            this.stop.Name = "stop";
            this.stop.Size = new System.Drawing.Size(64, 34);
            this.stop.TabIndex = 5;
            this.stop.Text = "Stop";
            this.stop.UseVisualStyleBackColor = true;
            this.stop.Click += new System.EventHandler(this.stop_Click);
            // 
            // start
            // 
            this.start.Location = new System.Drawing.Point(21, 175);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(64, 34);
            this.start.TabIndex = 4;
            this.start.Text = "Start";
            this.start.UseVisualStyleBackColor = true;
            this.start.Click += new System.EventHandler(this.start_Click);
            // 
            // density
            // 
            this.density.Location = new System.Drawing.Point(21, 136);
            this.density.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.density.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.density.Name = "density";
            this.density.Size = new System.Drawing.Size(120, 20);
            this.density.TabIndex = 3;
            this.density.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.density.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
            // 
            // DensityLable
            // 
            this.DensityLable.AutoSize = true;
            this.DensityLable.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DensityLable.Location = new System.Drawing.Point(17, 92);
            this.DensityLable.Name = "DensityLable";
            this.DensityLable.Size = new System.Drawing.Size(62, 20);
            this.DensityLable.TabIndex = 2;
            this.DensityLable.Text = "Density";
            // 
            // resolution
            // 
            this.resolution.Location = new System.Drawing.Point(21, 59);
            this.resolution.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.resolution.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.resolution.Name = "resolution";
            this.resolution.Size = new System.Drawing.Size(120, 20);
            this.resolution.TabIndex = 1;
            this.resolution.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.resolution.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // ResolutionLabel
            // 
            this.ResolutionLabel.AutoSize = true;
            this.ResolutionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ResolutionLabel.Location = new System.Drawing.Point(17, 23);
            this.ResolutionLabel.Name = "ResolutionLabel";
            this.ResolutionLabel.Size = new System.Drawing.Size(85, 20);
            this.ResolutionLabel.TabIndex = 0;
            this.ResolutionLabel.Text = "Resolution";
            // 
            // map
            // 
            this.map.BackColor = System.Drawing.Color.IndianRed;
            this.map.Dock = System.Windows.Forms.DockStyle.Fill;
            this.map.Location = new System.Drawing.Point(0, 0);
            this.map.Name = "map";
            this.map.Size = new System.Drawing.Size(549, 461);
            this.map.TabIndex = 0;
            this.map.TabStop = false;
            this.map.MouseMove += new System.Windows.Forms.MouseEventHandler(this.map_MouseMove);
            // 
            // timer
            // 
            this.timer.Interval = 40;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // Universe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 461);
            this.Controls.Add(this.splitContainer);
            this.MinimumSize = new System.Drawing.Size(500, 500);
            this.Name = "Universe";
            this.Text = "Universe";
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel1.PerformLayout();
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.density)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resolution)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.map)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.PictureBox map;
        private System.Windows.Forms.NumericUpDown resolution;
        private System.Windows.Forms.Label ResolutionLabel;
        private System.Windows.Forms.Button stop;
        private System.Windows.Forms.Button start;
        private System.Windows.Forms.NumericUpDown density;
        private System.Windows.Forms.Label DensityLable;
        private System.Windows.Forms.Timer timer;
    }
}

