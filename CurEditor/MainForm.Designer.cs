namespace CurEditor
{
    sealed partial class Form1
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
            this.SelectFolderButton = new System.Windows.Forms.Button();
            this.SelectCursorButton = new System.Windows.Forms.Button();
            this.MinScaleSlider = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.InterpolationSlider = new System.Windows.Forms.TrackBar();
            this.SaveAllButton = new System.Windows.Forms.Button();
            this.InterpolationIn = new System.Windows.Forms.GroupBox();
            this.radioButton5 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.InterpolationOut = new System.Windows.Forms.GroupBox();
            this.radioButton6 = new System.Windows.Forms.RadioButton();
            this.radioButton7 = new System.Windows.Forms.RadioButton();
            this.radioButton8 = new System.Windows.Forms.RadioButton();
            this.radioButton9 = new System.Windows.Forms.RadioButton();
            this.radioButton10 = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.RotationSlider = new System.Windows.Forms.TrackBar();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.UseRotation = new System.Windows.Forms.CheckBox();
            this.UseScalingInterpolation = new System.Windows.Forms.CheckBox();
            this.UseScaling = new System.Windows.Forms.CheckBox();
            this.CursorTreeView = new System.Windows.Forms.TreeView();
            ((System.ComponentModel.ISupportInitialize) (this.MinScaleSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.InterpolationSlider)).BeginInit();
            this.InterpolationIn.SuspendLayout();
            this.InterpolationOut.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.RotationSlider)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // SelectFolderButton
            // 
            this.SelectFolderButton.Location = new System.Drawing.Point(12, 139);
            this.SelectFolderButton.Name = "SelectFolderButton";
            this.SelectFolderButton.Size = new System.Drawing.Size(76, 26);
            this.SelectFolderButton.TabIndex = 0;
            this.SelectFolderButton.Text = "Select folder";
            this.SelectFolderButton.UseVisualStyleBackColor = true;
            this.SelectFolderButton.Click += new System.EventHandler(this.SelectFolderOnClick);
            // 
            // SelectCursorButton
            // 
            this.SelectCursorButton.Location = new System.Drawing.Point(94, 139);
            this.SelectCursorButton.Name = "SelectCursorButton";
            this.SelectCursorButton.Size = new System.Drawing.Size(93, 26);
            this.SelectCursorButton.TabIndex = 2;
            this.SelectCursorButton.Text = "Select cursor";
            this.SelectCursorButton.UseVisualStyleBackColor = true;
            // 
            // MinScaleSlider
            // 
            this.MinScaleSlider.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.MinScaleSlider.LargeChange = 1;
            this.MinScaleSlider.Location = new System.Drawing.Point(376, 32);
            this.MinScaleSlider.Minimum = 5;
            this.MinScaleSlider.Name = "MinScaleSlider";
            this.MinScaleSlider.Size = new System.Drawing.Size(412, 45);
            this.MinScaleSlider.TabIndex = 3;
            this.MinScaleSlider.Value = 5;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label2.Location = new System.Drawing.Point(627, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(161, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Minimum cursor scale";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label1.Location = new System.Drawing.Point(656, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Interpolation time";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // InterpolationSlider
            // 
            this.InterpolationSlider.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.InterpolationSlider.LargeChange = 1;
            this.InterpolationSlider.Location = new System.Drawing.Point(376, 83);
            this.InterpolationSlider.Minimum = 1;
            this.InterpolationSlider.Name = "InterpolationSlider";
            this.InterpolationSlider.Size = new System.Drawing.Size(412, 45);
            this.InterpolationSlider.TabIndex = 5;
            this.InterpolationSlider.Value = 5;
            // 
            // SaveAllButton
            // 
            this.SaveAllButton.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveAllButton.Location = new System.Drawing.Point(713, 415);
            this.SaveAllButton.Name = "SaveAllButton";
            this.SaveAllButton.Size = new System.Drawing.Size(75, 23);
            this.SaveAllButton.TabIndex = 7;
            this.SaveAllButton.Text = "Apply";
            this.SaveAllButton.UseVisualStyleBackColor = true;
            this.SaveAllButton.Click += new System.EventHandler(this.SaveAllOnClick);
            // 
            // InterpolationIn
            // 
            this.InterpolationIn.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.InterpolationIn.Controls.Add(this.radioButton5);
            this.InterpolationIn.Controls.Add(this.radioButton4);
            this.InterpolationIn.Controls.Add(this.radioButton3);
            this.InterpolationIn.Controls.Add(this.radioButton2);
            this.InterpolationIn.Controls.Add(this.radioButton1);
            this.InterpolationIn.Location = new System.Drawing.Point(12, 241);
            this.InterpolationIn.Name = "InterpolationIn";
            this.InterpolationIn.Size = new System.Drawing.Size(175, 197);
            this.InterpolationIn.TabIndex = 8;
            this.InterpolationIn.TabStop = false;
            this.InterpolationIn.Text = "Interpolation (in)";
            // 
            // radioButton5
            // 
            this.radioButton5.AutoSize = true;
            this.radioButton5.Location = new System.Drawing.Point(7, 15);
            this.radioButton5.Name = "radioButton5";
            this.radioButton5.Size = new System.Drawing.Size(54, 17);
            this.radioButton5.TabIndex = 4;
            this.radioButton5.TabStop = true;
            this.radioButton5.Text = "Linear";
            this.radioButton5.UseVisualStyleBackColor = true;
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Location = new System.Drawing.Point(7, 35);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(93, 17);
            this.radioButton4.TabIndex = 3;
            this.radioButton4.TabStop = true;
            this.radioButton4.Text = "EaseOutCubic";
            this.radioButton4.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(7, 58);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(97, 17);
            this.radioButton3.TabIndex = 2;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "EaseOutElastic";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(7, 81);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(90, 17);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "EaseOutExpo";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(7, 104);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(92, 17);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "EaseOutQuart";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // InterpolationOut
            // 
            this.InterpolationOut.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.InterpolationOut.Controls.Add(this.radioButton6);
            this.InterpolationOut.Controls.Add(this.radioButton7);
            this.InterpolationOut.Controls.Add(this.radioButton8);
            this.InterpolationOut.Controls.Add(this.radioButton9);
            this.InterpolationOut.Controls.Add(this.radioButton10);
            this.InterpolationOut.Location = new System.Drawing.Point(212, 241);
            this.InterpolationOut.Name = "InterpolationOut";
            this.InterpolationOut.Size = new System.Drawing.Size(175, 197);
            this.InterpolationOut.TabIndex = 9;
            this.InterpolationOut.TabStop = false;
            this.InterpolationOut.Text = "Interpolation (out)";
            // 
            // radioButton6
            // 
            this.radioButton6.AutoSize = true;
            this.radioButton6.Location = new System.Drawing.Point(7, 15);
            this.radioButton6.Name = "radioButton6";
            this.radioButton6.Size = new System.Drawing.Size(54, 17);
            this.radioButton6.TabIndex = 9;
            this.radioButton6.TabStop = true;
            this.radioButton6.Text = "Linear";
            this.radioButton6.UseVisualStyleBackColor = true;
            // 
            // radioButton7
            // 
            this.radioButton7.AutoSize = true;
            this.radioButton7.Location = new System.Drawing.Point(7, 35);
            this.radioButton7.Name = "radioButton7";
            this.radioButton7.Size = new System.Drawing.Size(93, 17);
            this.radioButton7.TabIndex = 8;
            this.radioButton7.TabStop = true;
            this.radioButton7.Text = "EaseOutCubic";
            this.radioButton7.UseVisualStyleBackColor = true;
            // 
            // radioButton8
            // 
            this.radioButton8.AutoSize = true;
            this.radioButton8.Location = new System.Drawing.Point(7, 58);
            this.radioButton8.Name = "radioButton8";
            this.radioButton8.Size = new System.Drawing.Size(97, 17);
            this.radioButton8.TabIndex = 7;
            this.radioButton8.TabStop = true;
            this.radioButton8.Text = "EaseOutElastic";
            this.radioButton8.UseVisualStyleBackColor = true;
            // 
            // radioButton9
            // 
            this.radioButton9.AutoSize = true;
            this.radioButton9.Location = new System.Drawing.Point(7, 81);
            this.radioButton9.Name = "radioButton9";
            this.radioButton9.Size = new System.Drawing.Size(90, 17);
            this.radioButton9.TabIndex = 6;
            this.radioButton9.TabStop = true;
            this.radioButton9.Text = "EaseOutExpo";
            this.radioButton9.UseVisualStyleBackColor = true;
            // 
            // radioButton10
            // 
            this.radioButton10.AutoSize = true;
            this.radioButton10.Location = new System.Drawing.Point(7, 104);
            this.radioButton10.Name = "radioButton10";
            this.radioButton10.Size = new System.Drawing.Size(92, 17);
            this.radioButton10.TabIndex = 5;
            this.radioButton10.TabStop = true;
            this.radioButton10.Text = "EaseOutQuart";
            this.radioButton10.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label3.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label3.Location = new System.Drawing.Point(546, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(242, 20);
            this.label3.TabIndex = 10;
            this.label3.Text = "Max. rotation angle (1 step = 45*)";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // RotationSlider
            // 
            this.RotationSlider.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RotationSlider.LargeChange = 1;
            this.RotationSlider.Location = new System.Drawing.Point(376, 134);
            this.RotationSlider.Maximum = 8;
            this.RotationSlider.Minimum = 1;
            this.RotationSlider.Name = "RotationSlider";
            this.RotationSlider.Size = new System.Drawing.Size(412, 45);
            this.RotationSlider.TabIndex = 11;
            this.RotationSlider.Value = 3;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.UseRotation);
            this.groupBox3.Controls.Add(this.UseScalingInterpolation);
            this.groupBox3.Controls.Add(this.UseScaling);
            this.groupBox3.Location = new System.Drawing.Point(212, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(158, 153);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Settings";
            // 
            // UseRotation
            // 
            this.UseRotation.AutoSize = true;
            this.UseRotation.Location = new System.Drawing.Point(7, 66);
            this.UseRotation.Name = "UseRotation";
            this.UseRotation.Size = new System.Drawing.Size(83, 17);
            this.UseRotation.TabIndex = 2;
            this.UseRotation.Text = "Use rotation";
            this.UseRotation.UseVisualStyleBackColor = true;
            // 
            // UseScalingInterpolation
            // 
            this.UseScalingInterpolation.AutoSize = true;
            this.UseScalingInterpolation.Location = new System.Drawing.Point(7, 43);
            this.UseScalingInterpolation.Name = "UseScalingInterpolation";
            this.UseScalingInterpolation.Size = new System.Drawing.Size(141, 17);
            this.UseScalingInterpolation.TabIndex = 1;
            this.UseScalingInterpolation.Text = "Use scaling interpolation";
            this.UseScalingInterpolation.UseVisualStyleBackColor = true;
            // 
            // UseScaling
            // 
            this.UseScaling.AccessibleName = "";
            this.UseScaling.AutoSize = true;
            this.UseScaling.Location = new System.Drawing.Point(7, 20);
            this.UseScaling.Name = "UseScaling";
            this.UseScaling.Size = new System.Drawing.Size(81, 17);
            this.UseScaling.TabIndex = 0;
            this.UseScaling.Text = "Use scaling";
            this.UseScaling.UseVisualStyleBackColor = true;
            // 
            // CursorTreeView
            // 
            this.CursorTreeView.Location = new System.Drawing.Point(12, 9);
            this.CursorTreeView.Name = "CursorTreeView";
            this.CursorTreeView.Size = new System.Drawing.Size(175, 119);
            this.CursorTreeView.TabIndex = 13;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.CursorTreeView);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.RotationSlider);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.InterpolationOut);
            this.Controls.Add(this.InterpolationIn);
            this.Controls.Add(this.SaveAllButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.InterpolationSlider);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.MinScaleSlider);
            this.Controls.Add(this.SelectCursorButton);
            this.Controls.Add(this.SelectFolderButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnFormClosing);
            ((System.ComponentModel.ISupportInitialize) (this.MinScaleSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.InterpolationSlider)).EndInit();
            this.InterpolationIn.ResumeLayout(false);
            this.InterpolationIn.PerformLayout();
            this.InterpolationOut.ResumeLayout(false);
            this.InterpolationOut.PerformLayout();
            ((System.ComponentModel.ISupportInitialize) (this.RotationSlider)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.TreeView CursorTreeView;

        private System.Windows.Forms.GroupBox InterpolationIn;
        private System.Windows.Forms.GroupBox InterpolationOut;
        private System.Windows.Forms.TrackBar InterpolationSlider;
        private System.Windows.Forms.TrackBar RotationSlider;
        private System.Windows.Forms.Button SelectCursorButton;
        private System.Windows.Forms.Button SelectFolderButton;

        private System.Windows.Forms.TrackBar MinScaleSlider;

        private System.Windows.Forms.Button SaveAllButton;
        private System.Windows.Forms.CheckBox UseRotation;
        private System.Windows.Forms.CheckBox UseScalingInterpolation;

        private System.Windows.Forms.CheckBox UseScaling;

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton radioButton5;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton6;
        private System.Windows.Forms.RadioButton radioButton7;
        private System.Windows.Forms.RadioButton radioButton8;
        private System.Windows.Forms.RadioButton radioButton9;
        private System.Windows.Forms.RadioButton radioButton10;
    }
}