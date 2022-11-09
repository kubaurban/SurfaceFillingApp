namespace Views
{
    partial class Visualizer
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
            this.PictureBox = new System.Windows.Forms.PictureBox();
            this.IlluminationBox = new System.Windows.Forms.GroupBox();
            this.ChangeIlluminationColorButton = new System.Windows.Forms.Button();
            this.m_label = new System.Windows.Forms.Label();
            this.ks_label = new System.Windows.Forms.Label();
            this.kd_label = new System.Windows.Forms.Label();
            this.mTrackBar = new System.Windows.Forms.TrackBar();
            this.ksTrackBar = new System.Windows.Forms.TrackBar();
            this.kdTrackBar = new System.Windows.Forms.TrackBar();
            this.FillingBox = new System.Windows.Forms.GroupBox();
            this.TextureRadioButton = new System.Windows.Forms.RadioButton();
            this.SolidColorButton = new System.Windows.Forms.RadioButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.ChangeColorButton = new System.Windows.Forms.Button();
            this.ChangeTextureButton = new System.Windows.Forms.Button();
            this.AnimationBox = new System.Windows.Forms.GroupBox();
            this.AnimationButton = new System.Windows.Forms.Button();
            this.zTrackBar = new System.Windows.Forms.TrackBar();
            this.NormalMap = new System.Windows.Forms.GroupBox();
            this.NormalMapCheckBox = new System.Windows.Forms.CheckBox();
            this.InterpolationBox = new System.Windows.Forms.GroupBox();
            this.FromDirectPointButton = new System.Windows.Forms.RadioButton();
            this.FromVerticesButton = new System.Windows.Forms.RadioButton();
            this.z_label = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox)).BeginInit();
            this.IlluminationBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ksTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kdTrackBar)).BeginInit();
            this.FillingBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.AnimationBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.zTrackBar)).BeginInit();
            this.NormalMap.SuspendLayout();
            this.InterpolationBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // PictureBox
            // 
            this.PictureBox.Location = new System.Drawing.Point(12, 28);
            this.PictureBox.Name = "PictureBox";
            this.PictureBox.Size = new System.Drawing.Size(500, 500);
            this.PictureBox.TabIndex = 0;
            this.PictureBox.TabStop = false;
            // 
            // IlluminationBox
            // 
            this.IlluminationBox.Controls.Add(this.ChangeIlluminationColorButton);
            this.IlluminationBox.Controls.Add(this.m_label);
            this.IlluminationBox.Controls.Add(this.ks_label);
            this.IlluminationBox.Controls.Add(this.kd_label);
            this.IlluminationBox.Controls.Add(this.mTrackBar);
            this.IlluminationBox.Controls.Add(this.ksTrackBar);
            this.IlluminationBox.Controls.Add(this.kdTrackBar);
            this.IlluminationBox.Location = new System.Drawing.Point(518, 20);
            this.IlluminationBox.Name = "IlluminationBox";
            this.IlluminationBox.Size = new System.Drawing.Size(254, 184);
            this.IlluminationBox.TabIndex = 1;
            this.IlluminationBox.TabStop = false;
            this.IlluminationBox.Text = "Illumination";
            // 
            // ChangeIlluminationColorButton
            // 
            this.ChangeIlluminationColorButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.ChangeIlluminationColorButton.Location = new System.Drawing.Point(39, 150);
            this.ChangeIlluminationColorButton.Name = "ChangeIlluminationColorButton";
            this.ChangeIlluminationColorButton.Size = new System.Drawing.Size(176, 25);
            this.ChangeIlluminationColorButton.TabIndex = 5;
            this.ChangeIlluminationColorButton.Text = "Change illumiantion color";
            this.ChangeIlluminationColorButton.UseVisualStyleBackColor = true;
            // 
            // m_label
            // 
            this.m_label.AutoSize = true;
            this.m_label.Location = new System.Drawing.Point(111, 129);
            this.m_label.Name = "m_label";
            this.m_label.Size = new System.Drawing.Size(30, 15);
            this.m_label.TabIndex = 4;
            this.m_label.Text = "m: 0";
            // 
            // ks_label
            // 
            this.ks_label.AutoSize = true;
            this.ks_label.Location = new System.Drawing.Point(111, 89);
            this.ks_label.Name = "ks_label";
            this.ks_label.Size = new System.Drawing.Size(30, 15);
            this.ks_label.TabIndex = 3;
            this.ks_label.Text = "ks: 0";
            // 
            // kd_label
            // 
            this.kd_label.AutoSize = true;
            this.kd_label.Location = new System.Drawing.Point(110, 45);
            this.kd_label.Name = "kd_label";
            this.kd_label.Size = new System.Drawing.Size(32, 15);
            this.kd_label.TabIndex = 0;
            this.kd_label.Text = "kd: 0";
            // 
            // mTrackBar
            // 
            this.mTrackBar.LargeChange = 4;
            this.mTrackBar.Location = new System.Drawing.Point(6, 102);
            this.mTrackBar.Maximum = 20;
            this.mTrackBar.Name = "mTrackBar";
            this.mTrackBar.Size = new System.Drawing.Size(242, 45);
            this.mTrackBar.TabIndex = 2;
            // 
            // ksTrackBar
            // 
            this.ksTrackBar.LargeChange = 4;
            this.ksTrackBar.Location = new System.Drawing.Point(6, 59);
            this.ksTrackBar.Maximum = 20;
            this.ksTrackBar.Name = "ksTrackBar";
            this.ksTrackBar.Size = new System.Drawing.Size(242, 45);
            this.ksTrackBar.TabIndex = 1;
            // 
            // kdTrackBar
            // 
            this.kdTrackBar.LargeChange = 4;
            this.kdTrackBar.Location = new System.Drawing.Point(6, 17);
            this.kdTrackBar.Maximum = 20;
            this.kdTrackBar.Name = "kdTrackBar";
            this.kdTrackBar.Size = new System.Drawing.Size(242, 45);
            this.kdTrackBar.TabIndex = 0;
            // 
            // FillingBox
            // 
            this.FillingBox.Controls.Add(this.TextureRadioButton);
            this.FillingBox.Controls.Add(this.SolidColorButton);
            this.FillingBox.Controls.Add(this.splitContainer1);
            this.FillingBox.Location = new System.Drawing.Point(518, 283);
            this.FillingBox.Name = "FillingBox";
            this.FillingBox.Size = new System.Drawing.Size(254, 85);
            this.FillingBox.TabIndex = 2;
            this.FillingBox.TabStop = false;
            this.FillingBox.Text = "Filling";
            // 
            // TextureRadioButton
            // 
            this.TextureRadioButton.AutoSize = true;
            this.TextureRadioButton.Location = new System.Drawing.Point(159, 21);
            this.TextureRadioButton.Name = "TextureRadioButton";
            this.TextureRadioButton.Size = new System.Drawing.Size(63, 19);
            this.TextureRadioButton.TabIndex = 1;
            this.TextureRadioButton.TabStop = true;
            this.TextureRadioButton.Text = "Texture";
            this.TextureRadioButton.UseVisualStyleBackColor = true;
            // 
            // SolidColorButton
            // 
            this.SolidColorButton.AutoSize = true;
            this.SolidColorButton.Location = new System.Drawing.Point(26, 21);
            this.SolidColorButton.Name = "SolidColorButton";
            this.SolidColorButton.Size = new System.Drawing.Size(81, 19);
            this.SolidColorButton.TabIndex = 0;
            this.SolidColorButton.TabStop = true;
            this.SolidColorButton.Text = "Solid color";
            this.SolidColorButton.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(3, 37);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.ChangeColorButton);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.ChangeTextureButton);
            this.splitContainer1.Size = new System.Drawing.Size(248, 46);
            this.splitContainer1.SplitterDistance = 125;
            this.splitContainer1.TabIndex = 2;
            // 
            // ChangeColorButton
            // 
            this.ChangeColorButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.ChangeColorButton.Location = new System.Drawing.Point(5, 8);
            this.ChangeColorButton.Name = "ChangeColorButton";
            this.ChangeColorButton.Size = new System.Drawing.Size(117, 31);
            this.ChangeColorButton.TabIndex = 1;
            this.ChangeColorButton.Text = "Change color";
            this.ChangeColorButton.UseVisualStyleBackColor = true;
            // 
            // ChangeTextureButton
            // 
            this.ChangeTextureButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.ChangeTextureButton.Location = new System.Drawing.Point(3, 8);
            this.ChangeTextureButton.Name = "ChangeTextureButton";
            this.ChangeTextureButton.Size = new System.Drawing.Size(113, 31);
            this.ChangeTextureButton.TabIndex = 2;
            this.ChangeTextureButton.Text = "Change texture";
            this.ChangeTextureButton.UseVisualStyleBackColor = true;
            // 
            // AnimationBox
            // 
            this.AnimationBox.Controls.Add(this.z_label);
            this.AnimationBox.Controls.Add(this.AnimationButton);
            this.AnimationBox.Controls.Add(this.zTrackBar);
            this.AnimationBox.Location = new System.Drawing.Point(518, 210);
            this.AnimationBox.Name = "AnimationBox";
            this.AnimationBox.Size = new System.Drawing.Size(254, 67);
            this.AnimationBox.TabIndex = 3;
            this.AnimationBox.TabStop = false;
            this.AnimationBox.Text = "Animation";
            // 
            // AnimationButton
            // 
            this.AnimationButton.Location = new System.Drawing.Point(8, 26);
            this.AnimationButton.Name = "AnimationButton";
            this.AnimationButton.Size = new System.Drawing.Size(75, 23);
            this.AnimationButton.TabIndex = 0;
            this.AnimationButton.Text = "Enable";
            this.AnimationButton.UseVisualStyleBackColor = true;
            this.AnimationButton.Click += new System.EventHandler(this.AnimationButton_Click);
            // 
            // zTrackBar
            // 
            this.zTrackBar.Location = new System.Drawing.Point(89, 16);
            this.zTrackBar.Name = "zTrackBar";
            this.zTrackBar.Size = new System.Drawing.Size(159, 45);
            this.zTrackBar.TabIndex = 3;
            // 
            // NormalMap
            // 
            this.NormalMap.Controls.Add(this.NormalMapCheckBox);
            this.NormalMap.Location = new System.Drawing.Point(518, 439);
            this.NormalMap.Name = "NormalMap";
            this.NormalMap.Size = new System.Drawing.Size(254, 89);
            this.NormalMap.TabIndex = 4;
            this.NormalMap.TabStop = false;
            this.NormalMap.Text = "NormalMap";
            // 
            // NormalMapCheckBox
            // 
            this.NormalMapCheckBox.AutoSize = true;
            this.NormalMapCheckBox.Location = new System.Drawing.Point(52, 22);
            this.NormalMapCheckBox.Name = "NormalMapCheckBox";
            this.NormalMapCheckBox.Size = new System.Drawing.Size(157, 19);
            this.NormalMapCheckBox.TabIndex = 0;
            this.NormalMapCheckBox.Text = "Modify with NormalMap";
            this.NormalMapCheckBox.UseVisualStyleBackColor = true;
            // 
            // InterpolationBox
            // 
            this.InterpolationBox.Controls.Add(this.FromDirectPointButton);
            this.InterpolationBox.Controls.Add(this.FromVerticesButton);
            this.InterpolationBox.Location = new System.Drawing.Point(518, 374);
            this.InterpolationBox.Name = "InterpolationBox";
            this.InterpolationBox.Size = new System.Drawing.Size(254, 59);
            this.InterpolationBox.TabIndex = 5;
            this.InterpolationBox.TabStop = false;
            this.InterpolationBox.Text = "Interpolation";
            // 
            // FromDirectPointButton
            // 
            this.FromDirectPointButton.AutoSize = true;
            this.FromDirectPointButton.Location = new System.Drawing.Point(131, 23);
            this.FromDirectPointButton.Name = "FromDirectPointButton";
            this.FromDirectPointButton.Size = new System.Drawing.Size(117, 19);
            this.FromDirectPointButton.TabIndex = 1;
            this.FromDirectPointButton.TabStop = true;
            this.FromDirectPointButton.Text = "From direct point";
            this.FromDirectPointButton.UseVisualStyleBackColor = true;
            // 
            // FromVerticesButton
            // 
            this.FromVerticesButton.AutoSize = true;
            this.FromVerticesButton.Location = new System.Drawing.Point(20, 23);
            this.FromVerticesButton.Name = "FromVerticesButton";
            this.FromVerticesButton.Size = new System.Drawing.Size(96, 19);
            this.FromVerticesButton.TabIndex = 0;
            this.FromVerticesButton.TabStop = true;
            this.FromVerticesButton.Text = "From vertices";
            this.FromVerticesButton.UseVisualStyleBackColor = true;
            // 
            // z_label
            // 
            this.z_label.AutoSize = true;
            this.z_label.Location = new System.Drawing.Point(158, 46);
            this.z_label.Name = "z_label";
            this.z_label.Size = new System.Drawing.Size(24, 15);
            this.z_label.TabIndex = 6;
            this.z_label.Text = "z: 0";
            // 
            // Visualizer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.InterpolationBox);
            this.Controls.Add(this.NormalMap);
            this.Controls.Add(this.FillingBox);
            this.Controls.Add(this.AnimationBox);
            this.Controls.Add(this.IlluminationBox);
            this.Controls.Add(this.PictureBox);
            this.MaximumSize = new System.Drawing.Size(800, 600);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "Visualizer";
            this.Text = "Surface Filler";
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox)).EndInit();
            this.IlluminationBox.ResumeLayout(false);
            this.IlluminationBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ksTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kdTrackBar)).EndInit();
            this.FillingBox.ResumeLayout(false);
            this.FillingBox.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.AnimationBox.ResumeLayout(false);
            this.AnimationBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.zTrackBar)).EndInit();
            this.NormalMap.ResumeLayout(false);
            this.NormalMap.PerformLayout();
            this.InterpolationBox.ResumeLayout(false);
            this.InterpolationBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private PictureBox PictureBox;
        private GroupBox IlluminationBox;
        private GroupBox FillingBox;
        private GroupBox AnimationBox;
        private GroupBox NormalMap;
        private TrackBar kdTrackBar;
        private TrackBar mTrackBar;
        private TrackBar ksTrackBar;
        private Label kd_label;
        private Label ks_label;
        private Label m_label;
        private Button AnimationButton;
        private TrackBar zTrackBar;
        private RadioButton TextureRadioButton;
        private RadioButton SolidColorButton;
        private SplitContainer splitContainer1;
        private Button ChangeColorButton;
        private Button ChangeTextureButton;
        private CheckBox NormalMapCheckBox;
        private GroupBox InterpolationBox;
        private RadioButton FromDirectPointButton;
        private RadioButton FromVerticesButton;
        private Button ChangeIlluminationColorButton;
        private Label z_label;
    }
}