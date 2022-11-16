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
            this.z_label = new System.Windows.Forms.Label();
            this.ChangeIlluminationColorButton = new System.Windows.Forms.Button();
            this.m_label = new System.Windows.Forms.Label();
            this.ks_label = new System.Windows.Forms.Label();
            this.zTrackBar = new System.Windows.Forms.TrackBar();
            this.kd_label = new System.Windows.Forms.Label();
            this.mTrackBar = new System.Windows.Forms.TrackBar();
            this.ksTrackBar = new System.Windows.Forms.TrackBar();
            this.kdTrackBar = new System.Windows.Forms.TrackBar();
            this.r_label = new System.Windows.Forms.Label();
            this.rTrackBar = new System.Windows.Forms.TrackBar();
            this.FillingBox = new System.Windows.Forms.GroupBox();
            this.TextureRadioButton = new System.Windows.Forms.RadioButton();
            this.SolidColorRadioButton = new System.Windows.Forms.RadioButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.ChangeColorButton = new System.Windows.Forms.Button();
            this.ChangeTextureButton = new System.Windows.Forms.Button();
            this.AnimationBox = new System.Windows.Forms.GroupBox();
            this.AnimationButton = new System.Windows.Forms.Button();
            this.NormalMap = new System.Windows.Forms.GroupBox();
            this.ChangeNormalMapButton = new System.Windows.Forms.Button();
            this.NormalMapCheckBox = new System.Windows.Forms.CheckBox();
            this.InterpolationBox = new System.Windows.Forms.GroupBox();
            this.VectorInterpolationButton = new System.Windows.Forms.RadioButton();
            this.ColorInterpolationButton = new System.Windows.Forms.RadioButton();
            this.ColorDialog = new System.Windows.Forms.ColorDialog();
            this.OpenImageDialog = new System.Windows.Forms.OpenFileDialog();
            this.DrawMeshCheckbox = new System.Windows.Forms.CheckBox();
            this.LoadSurfaceButton = new System.Windows.Forms.Button();
            this.LoadedSurfaceLabel = new System.Windows.Forms.Label();
            this.OpenObjDialog = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox)).BeginInit();
            this.IlluminationBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.zTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ksTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kdTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rTrackBar)).BeginInit();
            this.FillingBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.AnimationBox.SuspendLayout();
            this.NormalMap.SuspendLayout();
            this.InterpolationBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // PictureBox
            // 
            this.PictureBox.Location = new System.Drawing.Point(12, 38);
            this.PictureBox.Name = "PictureBox";
            this.PictureBox.Size = new System.Drawing.Size(500, 500);
            this.PictureBox.TabIndex = 0;
            this.PictureBox.TabStop = false;
            // 
            // IlluminationBox
            // 
            this.IlluminationBox.Controls.Add(this.z_label);
            this.IlluminationBox.Controls.Add(this.ChangeIlluminationColorButton);
            this.IlluminationBox.Controls.Add(this.m_label);
            this.IlluminationBox.Controls.Add(this.ks_label);
            this.IlluminationBox.Controls.Add(this.zTrackBar);
            this.IlluminationBox.Controls.Add(this.kd_label);
            this.IlluminationBox.Controls.Add(this.mTrackBar);
            this.IlluminationBox.Controls.Add(this.ksTrackBar);
            this.IlluminationBox.Controls.Add(this.kdTrackBar);
            this.IlluminationBox.Location = new System.Drawing.Point(518, 12);
            this.IlluminationBox.Name = "IlluminationBox";
            this.IlluminationBox.Size = new System.Drawing.Size(254, 202);
            this.IlluminationBox.TabIndex = 1;
            this.IlluminationBox.TabStop = false;
            this.IlluminationBox.Text = "Illumination";
            // 
            // z_label
            // 
            this.z_label.AutoSize = true;
            this.z_label.Location = new System.Drawing.Point(156, 176);
            this.z_label.Name = "z_label";
            this.z_label.Size = new System.Drawing.Size(24, 15);
            this.z_label.TabIndex = 6;
            this.z_label.Text = "z: 0";
            // 
            // ChangeIlluminationColorButton
            // 
            this.ChangeIlluminationColorButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.ChangeIlluminationColorButton.Location = new System.Drawing.Point(6, 153);
            this.ChangeIlluminationColorButton.Name = "ChangeIlluminationColorButton";
            this.ChangeIlluminationColorButton.Size = new System.Drawing.Size(80, 38);
            this.ChangeIlluminationColorButton.TabIndex = 5;
            this.ChangeIlluminationColorButton.Text = "Change color";
            this.ChangeIlluminationColorButton.UseVisualStyleBackColor = true;
            this.ChangeIlluminationColorButton.Click += new System.EventHandler(this.OnChangeIlluminationColorButtonClick);
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
            // zTrackBar
            // 
            this.zTrackBar.Location = new System.Drawing.Point(89, 148);
            this.zTrackBar.Maximum = 1000;
            this.zTrackBar.Name = "zTrackBar";
            this.zTrackBar.Size = new System.Drawing.Size(159, 45);
            this.zTrackBar.TabIndex = 3;
            this.zTrackBar.Value = 200;
            this.zTrackBar.ValueChanged += new System.EventHandler(this.OnZChanged);
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
            this.mTrackBar.Maximum = 100;
            this.mTrackBar.Minimum = 1;
            this.mTrackBar.Name = "mTrackBar";
            this.mTrackBar.Size = new System.Drawing.Size(242, 45);
            this.mTrackBar.TabIndex = 2;
            this.mTrackBar.Value = 1;
            this.mTrackBar.ValueChanged += new System.EventHandler(this.OnMChanged);
            // 
            // ksTrackBar
            // 
            this.ksTrackBar.LargeChange = 4;
            this.ksTrackBar.Location = new System.Drawing.Point(6, 59);
            this.ksTrackBar.Maximum = 100;
            this.ksTrackBar.Name = "ksTrackBar";
            this.ksTrackBar.Size = new System.Drawing.Size(242, 45);
            this.ksTrackBar.TabIndex = 1;
            this.ksTrackBar.ValueChanged += new System.EventHandler(this.OnKsChanged);
            // 
            // kdTrackBar
            // 
            this.kdTrackBar.LargeChange = 4;
            this.kdTrackBar.Location = new System.Drawing.Point(6, 17);
            this.kdTrackBar.Maximum = 100;
            this.kdTrackBar.Name = "kdTrackBar";
            this.kdTrackBar.Size = new System.Drawing.Size(242, 45);
            this.kdTrackBar.TabIndex = 0;
            this.kdTrackBar.ValueChanged += new System.EventHandler(this.OnKdChanged);
            // 
            // r_label
            // 
            this.r_label.AutoSize = true;
            this.r_label.Location = new System.Drawing.Point(155, 46);
            this.r_label.Name = "r_label";
            this.r_label.Size = new System.Drawing.Size(26, 15);
            this.r_label.TabIndex = 7;
            this.r_label.Text = "R: 0";
            // 
            // rTrackBar
            // 
            this.rTrackBar.Location = new System.Drawing.Point(89, 16);
            this.rTrackBar.Maximum = 500;
            this.rTrackBar.Minimum = 25;
            this.rTrackBar.Name = "rTrackBar";
            this.rTrackBar.Size = new System.Drawing.Size(159, 45);
            this.rTrackBar.TabIndex = 7;
            this.rTrackBar.Value = 25;
            this.rTrackBar.ValueChanged += new System.EventHandler(this.OnRChanged);
            // 
            // FillingBox
            // 
            this.FillingBox.Controls.Add(this.TextureRadioButton);
            this.FillingBox.Controls.Add(this.SolidColorRadioButton);
            this.FillingBox.Controls.Add(this.splitContainer1);
            this.FillingBox.Location = new System.Drawing.Point(518, 293);
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
            // SolidColorRadioButton
            // 
            this.SolidColorRadioButton.AutoSize = true;
            this.SolidColorRadioButton.Location = new System.Drawing.Point(26, 21);
            this.SolidColorRadioButton.Name = "SolidColorRadioButton";
            this.SolidColorRadioButton.Size = new System.Drawing.Size(81, 19);
            this.SolidColorRadioButton.TabIndex = 0;
            this.SolidColorRadioButton.TabStop = true;
            this.SolidColorRadioButton.Text = "Solid color";
            this.SolidColorRadioButton.UseVisualStyleBackColor = true;
            this.SolidColorRadioButton.CheckedChanged += new System.EventHandler(this.OnFillingMethodChanged);
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
            this.splitContainer1.SplitterDistance = 124;
            this.splitContainer1.TabIndex = 2;
            // 
            // ChangeColorButton
            // 
            this.ChangeColorButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.ChangeColorButton.Location = new System.Drawing.Point(5, 8);
            this.ChangeColorButton.Name = "ChangeColorButton";
            this.ChangeColorButton.Size = new System.Drawing.Size(116, 31);
            this.ChangeColorButton.TabIndex = 1;
            this.ChangeColorButton.Text = "Change color";
            this.ChangeColorButton.UseVisualStyleBackColor = true;
            this.ChangeColorButton.Click += new System.EventHandler(this.OnChangeColorButtonClick);
            // 
            // ChangeTextureButton
            // 
            this.ChangeTextureButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.ChangeTextureButton.Enabled = false;
            this.ChangeTextureButton.Location = new System.Drawing.Point(4, 8);
            this.ChangeTextureButton.Name = "ChangeTextureButton";
            this.ChangeTextureButton.Size = new System.Drawing.Size(113, 31);
            this.ChangeTextureButton.TabIndex = 2;
            this.ChangeTextureButton.Text = "Change texture";
            this.ChangeTextureButton.UseVisualStyleBackColor = true;
            this.ChangeTextureButton.Click += new System.EventHandler(this.OnChangeTextureButtonClick);
            // 
            // AnimationBox
            // 
            this.AnimationBox.Controls.Add(this.r_label);
            this.AnimationBox.Controls.Add(this.AnimationButton);
            this.AnimationBox.Controls.Add(this.rTrackBar);
            this.AnimationBox.Location = new System.Drawing.Point(518, 220);
            this.AnimationBox.Name = "AnimationBox";
            this.AnimationBox.Size = new System.Drawing.Size(254, 67);
            this.AnimationBox.TabIndex = 3;
            this.AnimationBox.TabStop = false;
            this.AnimationBox.Text = "Animation";
            // 
            // AnimationButton
            // 
            this.AnimationButton.Location = new System.Drawing.Point(8, 27);
            this.AnimationButton.Name = "AnimationButton";
            this.AnimationButton.Size = new System.Drawing.Size(75, 23);
            this.AnimationButton.TabIndex = 0;
            this.AnimationButton.Text = "Enable";
            this.AnimationButton.UseVisualStyleBackColor = true;
            this.AnimationButton.Click += new System.EventHandler(this.OnAnimationButtonClick);
            // 
            // NormalMap
            // 
            this.NormalMap.Controls.Add(this.ChangeNormalMapButton);
            this.NormalMap.Controls.Add(this.NormalMapCheckBox);
            this.NormalMap.Location = new System.Drawing.Point(518, 449);
            this.NormalMap.Name = "NormalMap";
            this.NormalMap.Size = new System.Drawing.Size(254, 89);
            this.NormalMap.TabIndex = 4;
            this.NormalMap.TabStop = false;
            this.NormalMap.Text = "NormalMap";
            // 
            // ChangeNormalMapButton
            // 
            this.ChangeNormalMapButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.ChangeNormalMapButton.Enabled = false;
            this.ChangeNormalMapButton.Location = new System.Drawing.Point(49, 47);
            this.ChangeNormalMapButton.Name = "ChangeNormalMapButton";
            this.ChangeNormalMapButton.Size = new System.Drawing.Size(157, 31);
            this.ChangeNormalMapButton.TabIndex = 2;
            this.ChangeNormalMapButton.Text = "Change NormalMap";
            this.ChangeNormalMapButton.UseVisualStyleBackColor = true;
            this.ChangeNormalMapButton.Click += new System.EventHandler(this.OnChangeNormalMapButtonClick);
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
            this.NormalMapCheckBox.CheckedChanged += new System.EventHandler(this.OnModifyWithNormalMapChanged);
            // 
            // InterpolationBox
            // 
            this.InterpolationBox.Controls.Add(this.VectorInterpolationButton);
            this.InterpolationBox.Controls.Add(this.ColorInterpolationButton);
            this.InterpolationBox.Location = new System.Drawing.Point(518, 384);
            this.InterpolationBox.Name = "InterpolationBox";
            this.InterpolationBox.Size = new System.Drawing.Size(254, 59);
            this.InterpolationBox.TabIndex = 5;
            this.InterpolationBox.TabStop = false;
            this.InterpolationBox.Text = "Interpolation";
            // 
            // VectorInterpolationButton
            // 
            this.VectorInterpolationButton.AutoSize = true;
            this.VectorInterpolationButton.Location = new System.Drawing.Point(26, 22);
            this.VectorInterpolationButton.Name = "VectorInterpolationButton";
            this.VectorInterpolationButton.Size = new System.Drawing.Size(101, 19);
            this.VectorInterpolationButton.TabIndex = 1;
            this.VectorInterpolationButton.TabStop = true;
            this.VectorInterpolationButton.Text = "Normal vector";
            this.VectorInterpolationButton.UseVisualStyleBackColor = true;
            // 
            // ColorInterpolationButton
            // 
            this.ColorInterpolationButton.AutoSize = true;
            this.ColorInterpolationButton.Location = new System.Drawing.Point(159, 22);
            this.ColorInterpolationButton.Name = "ColorInterpolationButton";
            this.ColorInterpolationButton.Size = new System.Drawing.Size(54, 19);
            this.ColorInterpolationButton.TabIndex = 0;
            this.ColorInterpolationButton.TabStop = true;
            this.ColorInterpolationButton.Text = "Color";
            this.ColorInterpolationButton.UseVisualStyleBackColor = true;
            this.ColorInterpolationButton.CheckedChanged += new System.EventHandler(this.OnInterpolationMethodChanged);
            // 
            // OpenImageDialog
            // 
            this.OpenImageDialog.InitialDirectory = "../../../..";
            // 
            // DrawMeshCheckbox
            // 
            this.DrawMeshCheckbox.AutoSize = true;
            this.DrawMeshCheckbox.Location = new System.Drawing.Point(386, 12);
            this.DrawMeshCheckbox.Name = "DrawMeshCheckbox";
            this.DrawMeshCheckbox.Size = new System.Drawing.Size(126, 19);
            this.DrawMeshCheckbox.TabIndex = 6;
            this.DrawMeshCheckbox.Text = "Draw surface mesh";
            this.DrawMeshCheckbox.UseVisualStyleBackColor = true;
            this.DrawMeshCheckbox.CheckedChanged += new System.EventHandler(this.OnDrawMeshChanged);
            // 
            // LoadSurfaceButton
            // 
            this.LoadSurfaceButton.Location = new System.Drawing.Point(12, 8);
            this.LoadSurfaceButton.Name = "LoadSurfaceButton";
            this.LoadSurfaceButton.Size = new System.Drawing.Size(126, 23);
            this.LoadSurfaceButton.TabIndex = 7;
            this.LoadSurfaceButton.Text = "Load surface";
            this.LoadSurfaceButton.UseVisualStyleBackColor = true;
            this.LoadSurfaceButton.Click += new System.EventHandler(this.OnLoadSurfaceButtonClick);
            // 
            // LoadedSurfaceLabel
            // 
            this.LoadedSurfaceLabel.AutoSize = true;
            this.LoadedSurfaceLabel.Location = new System.Drawing.Point(144, 12);
            this.LoadedSurfaceLabel.Name = "LoadedSurfaceLabel";
            this.LoadedSurfaceLabel.Size = new System.Drawing.Size(112, 15);
            this.LoadedSurfaceLabel.TabIndex = 8;
            this.LoadedSurfaceLabel.Text = "Loaded surface file: ";
            // 
            // Visualizer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 559);
            this.Controls.Add(this.LoadedSurfaceLabel);
            this.Controls.Add(this.LoadSurfaceButton);
            this.Controls.Add(this.DrawMeshCheckbox);
            this.Controls.Add(this.InterpolationBox);
            this.Controls.Add(this.NormalMap);
            this.Controls.Add(this.FillingBox);
            this.Controls.Add(this.AnimationBox);
            this.Controls.Add(this.IlluminationBox);
            this.Controls.Add(this.PictureBox);
            this.MaximumSize = new System.Drawing.Size(800, 598);
            this.MinimumSize = new System.Drawing.Size(800, 598);
            this.Name = "Visualizer";
            this.Text = "Surface Filler";
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox)).EndInit();
            this.IlluminationBox.ResumeLayout(false);
            this.IlluminationBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.zTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ksTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kdTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rTrackBar)).EndInit();
            this.FillingBox.ResumeLayout(false);
            this.FillingBox.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.AnimationBox.ResumeLayout(false);
            this.AnimationBox.PerformLayout();
            this.NormalMap.ResumeLayout(false);
            this.NormalMap.PerformLayout();
            this.InterpolationBox.ResumeLayout(false);
            this.InterpolationBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private RadioButton SolidColorRadioButton;
        private SplitContainer splitContainer1;
        private Button ChangeColorButton;
        private Button ChangeTextureButton;
        private CheckBox NormalMapCheckBox;
        private GroupBox InterpolationBox;
        private RadioButton VectorInterpolationButton;
        private RadioButton ColorInterpolationButton;
        private Button ChangeIlluminationColorButton;
        private Label z_label;
        private ColorDialog ColorDialog;
        private Label r_label;
        private TrackBar rTrackBar;
        private OpenFileDialog OpenImageDialog;
        private CheckBox DrawMeshCheckbox;
        private Button ChangeNormalMapButton;
        private Button LoadSurfaceButton;
        private Label LoadedSurfaceLabel;
        private OpenFileDialog OpenObjDialog;
    }
}