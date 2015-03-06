﻿namespace Cube.Forms.Demo
{
    partial class MainForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.ButtonGroupBox = new System.Windows.Forms.GroupBox();
            this.FlatButton = new Cube.Forms.Button();
            this.ImageButton = new Cube.Forms.Button();
            this.RadioButtonGroupBox = new System.Windows.Forms.GroupBox();
            this.ImageRadioButton1 = new Cube.Forms.RadioButton();
            this.ImageRadioButton2 = new Cube.Forms.RadioButton();
            this.ImageRadioButton3 = new Cube.Forms.RadioButton();
            this.ImageRadioButton4 = new Cube.Forms.RadioButton();
            this.ButtonGroupBox.SuspendLayout();
            this.RadioButtonGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // ButtonGroupBox
            // 
            this.ButtonGroupBox.Controls.Add(this.FlatButton);
            this.ButtonGroupBox.Controls.Add(this.ImageButton);
            this.ButtonGroupBox.Location = new System.Drawing.Point(12, 12);
            this.ButtonGroupBox.Name = "ButtonGroupBox";
            this.ButtonGroupBox.Size = new System.Drawing.Size(285, 88);
            this.ButtonGroupBox.TabIndex = 2;
            this.ButtonGroupBox.TabStop = false;
            this.ButtonGroupBox.Text = "Cube.Forms.Button";
            // 
            // FlatButton
            // 
            this.FlatButton.Appearance.CheckedBackColor = System.Drawing.Color.Empty;
            this.FlatButton.Appearance.CheckedBackgroundImage = null;
            this.FlatButton.Appearance.CheckedBorderColor = System.Drawing.Color.Empty;
            this.FlatButton.Appearance.CheckedForeColor = System.Drawing.Color.Empty;
            this.FlatButton.Appearance.CheckedImage = null;
            this.FlatButton.Appearance.MouseDownBackColor = System.Drawing.Color.Empty;
            this.FlatButton.Appearance.MouseDownBackgroundImage = null;
            this.FlatButton.Appearance.MouseDownBorderColor = System.Drawing.Color.Empty;
            this.FlatButton.Appearance.MouseDownForeColor = System.Drawing.Color.Empty;
            this.FlatButton.Appearance.MouseDownImage = null;
            this.FlatButton.Appearance.MouseOverBackColor = System.Drawing.Color.Empty;
            this.FlatButton.Appearance.MouseOverBackgroundImage = null;
            this.FlatButton.Appearance.MouseOverBorderColor = System.Drawing.Color.Empty;
            this.FlatButton.Appearance.MouseOverForeColor = System.Drawing.Color.Empty;
            this.FlatButton.Appearance.MouseOverImage = null;
            this.FlatButton.BackColor = System.Drawing.Color.White;
            this.FlatButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FlatButton.Location = new System.Drawing.Point(78, 20);
            this.FlatButton.Name = "FlatButton";
            this.FlatButton.Size = new System.Drawing.Size(195, 50);
            this.FlatButton.TabIndex = 3;
            this.FlatButton.Text = "SampleText";
            this.FlatButton.UseVisualStyleBackColor = false;
            // 
            // ImageButton
            // 
            this.ImageButton.Appearance.CheckedBackColor = System.Drawing.Color.Empty;
            this.ImageButton.Appearance.CheckedBackgroundImage = null;
            this.ImageButton.Appearance.CheckedBorderColor = System.Drawing.Color.Empty;
            this.ImageButton.Appearance.CheckedForeColor = System.Drawing.Color.Empty;
            this.ImageButton.Appearance.CheckedImage = null;
            this.ImageButton.Appearance.MouseDownBackColor = System.Drawing.Color.Turquoise;
            this.ImageButton.Appearance.MouseDownBackgroundImage = null;
            this.ImageButton.Appearance.MouseDownBorderColor = System.Drawing.Color.Empty;
            this.ImageButton.Appearance.MouseDownForeColor = System.Drawing.Color.Empty;
            this.ImageButton.Appearance.MouseDownImage = null;
            this.ImageButton.Appearance.MouseOverBackColor = System.Drawing.Color.PaleTurquoise;
            this.ImageButton.Appearance.MouseOverBackgroundImage = null;
            this.ImageButton.Appearance.MouseOverBorderColor = System.Drawing.Color.RoyalBlue;
            this.ImageButton.Appearance.MouseOverForeColor = System.Drawing.Color.Empty;
            this.ImageButton.Appearance.MouseOverImage = global::Cube.Forms.Demo.Properties.Resources.LogoCubeIce;
            this.ImageButton.BackColor = System.Drawing.Color.White;
            this.ImageButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ImageButton.Image = global::Cube.Forms.Demo.Properties.Resources.LogoCube;
            this.ImageButton.Location = new System.Drawing.Point(12, 20);
            this.ImageButton.Name = "ImageButton";
            this.ImageButton.Size = new System.Drawing.Size(60, 50);
            this.ImageButton.TabIndex = 2;
            this.ImageButton.UseVisualStyleBackColor = false;
            // 
            // RadioButtonGroupBox
            // 
            this.RadioButtonGroupBox.Controls.Add(this.ImageRadioButton4);
            this.RadioButtonGroupBox.Controls.Add(this.ImageRadioButton3);
            this.RadioButtonGroupBox.Controls.Add(this.ImageRadioButton2);
            this.RadioButtonGroupBox.Controls.Add(this.ImageRadioButton1);
            this.RadioButtonGroupBox.Location = new System.Drawing.Point(12, 106);
            this.RadioButtonGroupBox.Name = "RadioButtonGroupBox";
            this.RadioButtonGroupBox.Size = new System.Drawing.Size(285, 88);
            this.RadioButtonGroupBox.TabIndex = 3;
            this.RadioButtonGroupBox.TabStop = false;
            this.RadioButtonGroupBox.Text = "Cube.Forms.RadioButton";
            // 
            // ImageRadioButton1
            // 
            this.ImageRadioButton1.Appearance.CheckedBackColor = System.Drawing.Color.MistyRose;
            this.ImageRadioButton1.Appearance.CheckedBackgroundImage = null;
            this.ImageRadioButton1.Appearance.CheckedBorderColor = System.Drawing.Color.DarkRed;
            this.ImageRadioButton1.Appearance.CheckedForeColor = System.Drawing.Color.Empty;
            this.ImageRadioButton1.Appearance.CheckedImage = global::Cube.Forms.Demo.Properties.Resources.LogoCubePdf;
            this.ImageRadioButton1.Appearance.MouseDownBackColor = System.Drawing.Color.Turquoise;
            this.ImageRadioButton1.Appearance.MouseDownBackgroundImage = null;
            this.ImageRadioButton1.Appearance.MouseDownBorderColor = System.Drawing.Color.Empty;
            this.ImageRadioButton1.Appearance.MouseDownForeColor = System.Drawing.Color.Empty;
            this.ImageRadioButton1.Appearance.MouseDownImage = null;
            this.ImageRadioButton1.Appearance.MouseOverBackColor = System.Drawing.Color.PaleTurquoise;
            this.ImageRadioButton1.Appearance.MouseOverBackgroundImage = null;
            this.ImageRadioButton1.Appearance.MouseOverBorderColor = System.Drawing.Color.RoyalBlue;
            this.ImageRadioButton1.Appearance.MouseOverForeColor = System.Drawing.Color.Empty;
            this.ImageRadioButton1.Appearance.MouseOverImage = global::Cube.Forms.Demo.Properties.Resources.LogoCubeIce;
            this.ImageRadioButton1.BackColor = System.Drawing.Color.White;
            this.ImageRadioButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ImageRadioButton1.Image = global::Cube.Forms.Demo.Properties.Resources.LogoCube;
            this.ImageRadioButton1.Location = new System.Drawing.Point(12, 20);
            this.ImageRadioButton1.Name = "ImageRadioButton1";
            this.ImageRadioButton1.Size = new System.Drawing.Size(60, 50);
            this.ImageRadioButton1.TabIndex = 0;
            this.ImageRadioButton1.TabStop = true;
            this.ImageRadioButton1.UseVisualStyleBackColor = false;
            // 
            // ImageRadioButton2
            // 
            this.ImageRadioButton2.Appearance.CheckedBackColor = System.Drawing.Color.MistyRose;
            this.ImageRadioButton2.Appearance.CheckedBackgroundImage = null;
            this.ImageRadioButton2.Appearance.CheckedBorderColor = System.Drawing.Color.DarkRed;
            this.ImageRadioButton2.Appearance.CheckedForeColor = System.Drawing.Color.Empty;
            this.ImageRadioButton2.Appearance.CheckedImage = global::Cube.Forms.Demo.Properties.Resources.LogoCubePdf;
            this.ImageRadioButton2.Appearance.MouseDownBackColor = System.Drawing.Color.Turquoise;
            this.ImageRadioButton2.Appearance.MouseDownBackgroundImage = null;
            this.ImageRadioButton2.Appearance.MouseDownBorderColor = System.Drawing.Color.Empty;
            this.ImageRadioButton2.Appearance.MouseDownForeColor = System.Drawing.Color.Empty;
            this.ImageRadioButton2.Appearance.MouseDownImage = null;
            this.ImageRadioButton2.Appearance.MouseOverBackColor = System.Drawing.Color.PaleTurquoise;
            this.ImageRadioButton2.Appearance.MouseOverBackgroundImage = null;
            this.ImageRadioButton2.Appearance.MouseOverBorderColor = System.Drawing.Color.RoyalBlue;
            this.ImageRadioButton2.Appearance.MouseOverForeColor = System.Drawing.Color.Empty;
            this.ImageRadioButton2.Appearance.MouseOverImage = global::Cube.Forms.Demo.Properties.Resources.LogoCubeIce;
            this.ImageRadioButton2.BackColor = System.Drawing.Color.White;
            this.ImageRadioButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ImageRadioButton2.Image = global::Cube.Forms.Demo.Properties.Resources.LogoCube;
            this.ImageRadioButton2.Location = new System.Drawing.Point(78, 20);
            this.ImageRadioButton2.Name = "ImageRadioButton2";
            this.ImageRadioButton2.Size = new System.Drawing.Size(60, 50);
            this.ImageRadioButton2.TabIndex = 1;
            this.ImageRadioButton2.TabStop = true;
            this.ImageRadioButton2.UseVisualStyleBackColor = false;
            // 
            // ImageRadioButton3
            // 
            this.ImageRadioButton3.Appearance.CheckedBackColor = System.Drawing.Color.MistyRose;
            this.ImageRadioButton3.Appearance.CheckedBackgroundImage = null;
            this.ImageRadioButton3.Appearance.CheckedBorderColor = System.Drawing.Color.DarkRed;
            this.ImageRadioButton3.Appearance.CheckedForeColor = System.Drawing.Color.Empty;
            this.ImageRadioButton3.Appearance.CheckedImage = global::Cube.Forms.Demo.Properties.Resources.LogoCubePdf;
            this.ImageRadioButton3.Appearance.MouseDownBackColor = System.Drawing.Color.Turquoise;
            this.ImageRadioButton3.Appearance.MouseDownBackgroundImage = null;
            this.ImageRadioButton3.Appearance.MouseDownBorderColor = System.Drawing.Color.Empty;
            this.ImageRadioButton3.Appearance.MouseDownForeColor = System.Drawing.Color.Empty;
            this.ImageRadioButton3.Appearance.MouseDownImage = null;
            this.ImageRadioButton3.Appearance.MouseOverBackColor = System.Drawing.Color.PaleTurquoise;
            this.ImageRadioButton3.Appearance.MouseOverBackgroundImage = null;
            this.ImageRadioButton3.Appearance.MouseOverBorderColor = System.Drawing.Color.RoyalBlue;
            this.ImageRadioButton3.Appearance.MouseOverForeColor = System.Drawing.Color.Empty;
            this.ImageRadioButton3.Appearance.MouseOverImage = global::Cube.Forms.Demo.Properties.Resources.LogoCubeIce;
            this.ImageRadioButton3.BackColor = System.Drawing.Color.White;
            this.ImageRadioButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ImageRadioButton3.Image = global::Cube.Forms.Demo.Properties.Resources.LogoCube;
            this.ImageRadioButton3.Location = new System.Drawing.Point(144, 20);
            this.ImageRadioButton3.Name = "ImageRadioButton3";
            this.ImageRadioButton3.Size = new System.Drawing.Size(60, 50);
            this.ImageRadioButton3.TabIndex = 2;
            this.ImageRadioButton3.TabStop = true;
            this.ImageRadioButton3.UseVisualStyleBackColor = false;
            // 
            // ImageRadioButton4
            // 
            this.ImageRadioButton4.Appearance.CheckedBackColor = System.Drawing.Color.MistyRose;
            this.ImageRadioButton4.Appearance.CheckedBackgroundImage = null;
            this.ImageRadioButton4.Appearance.CheckedBorderColor = System.Drawing.Color.DarkRed;
            this.ImageRadioButton4.Appearance.CheckedForeColor = System.Drawing.Color.Empty;
            this.ImageRadioButton4.Appearance.CheckedImage = global::Cube.Forms.Demo.Properties.Resources.LogoCubePdf;
            this.ImageRadioButton4.Appearance.MouseDownBackColor = System.Drawing.Color.Turquoise;
            this.ImageRadioButton4.Appearance.MouseDownBackgroundImage = null;
            this.ImageRadioButton4.Appearance.MouseDownBorderColor = System.Drawing.Color.Empty;
            this.ImageRadioButton4.Appearance.MouseDownForeColor = System.Drawing.Color.Empty;
            this.ImageRadioButton4.Appearance.MouseDownImage = null;
            this.ImageRadioButton4.Appearance.MouseOverBackColor = System.Drawing.Color.PaleTurquoise;
            this.ImageRadioButton4.Appearance.MouseOverBackgroundImage = null;
            this.ImageRadioButton4.Appearance.MouseOverBorderColor = System.Drawing.Color.RoyalBlue;
            this.ImageRadioButton4.Appearance.MouseOverForeColor = System.Drawing.Color.Empty;
            this.ImageRadioButton4.Appearance.MouseOverImage = global::Cube.Forms.Demo.Properties.Resources.LogoCubeIce;
            this.ImageRadioButton4.BackColor = System.Drawing.Color.White;
            this.ImageRadioButton4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ImageRadioButton4.Image = global::Cube.Forms.Demo.Properties.Resources.LogoCube;
            this.ImageRadioButton4.Location = new System.Drawing.Point(210, 20);
            this.ImageRadioButton4.Name = "ImageRadioButton4";
            this.ImageRadioButton4.Size = new System.Drawing.Size(60, 50);
            this.ImageRadioButton4.TabIndex = 3;
            this.ImageRadioButton4.TabStop = true;
            this.ImageRadioButton4.UseVisualStyleBackColor = false;
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(309, 222);
            this.Controls.Add(this.RadioButtonGroupBox);
            this.Controls.Add(this.ButtonGroupBox);
            this.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Cube.Forms Demo";
            this.ButtonGroupBox.ResumeLayout(false);
            this.RadioButtonGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox ButtonGroupBox;
        private Button FlatButton;
        private Button ImageButton;
        private System.Windows.Forms.GroupBox RadioButtonGroupBox;
        private RadioButton ImageRadioButton1;
        private RadioButton ImageRadioButton2;
        private RadioButton ImageRadioButton3;
        private RadioButton ImageRadioButton4;






    }
}

