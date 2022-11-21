namespace ComputerVision
{
    partial class MainForm
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
            this.panelSource = new System.Windows.Forms.Panel();
            this.panelDestination = new System.Windows.Forms.Panel();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.egalizareBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.contrastTrackBar = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonGrayscale = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.reflexieComboBox = new System.Windows.Forms.ComboBox();
            this.reflexieBtn = new System.Windows.Forms.Button();
            this.textBoxZgomot = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.markovBtn = new System.Windows.Forms.Button();
            this.FTSButton = new System.Windows.Forms.Button();
            this.unsharpMaskBtn = new System.Windows.Forms.Button();
            this.kirschBtn = new System.Windows.Forms.Button();
            this.PrewittBtn = new System.Windows.Forms.Button();
            this.FreiChenBtn = new System.Windows.Forms.Button();
            this.GaborBtn = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.contrastTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelSource
            // 
            this.panelSource.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelSource.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelSource.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.panelSource.Location = new System.Drawing.Point(12, 12);
            this.panelSource.Name = "panelSource";
            this.panelSource.Size = new System.Drawing.Size(320, 240);
            this.panelSource.TabIndex = 0;
            // 
            // panelDestination
            // 
            this.panelDestination.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelDestination.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelDestination.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.panelDestination.Location = new System.Drawing.Point(348, 12);
            this.panelDestination.Name = "panelDestination";
            this.panelDestination.Size = new System.Drawing.Size(320, 240);
            this.panelDestination.TabIndex = 1;
            // 
            // buttonLoad
            // 
            this.buttonLoad.Location = new System.Drawing.Point(12, 439);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(75, 23);
            this.buttonLoad.TabIndex = 2;
            this.buttonLoad.Text = "Load";
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.egalizareBtn);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.contrastTrackBar);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.trackBar1);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.buttonGrayscale);
            this.panel1.Location = new System.Drawing.Point(348, 271);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(320, 190);
            this.panel1.TabIndex = 3;
            // 
            // egalizareBtn
            // 
            this.egalizareBtn.Location = new System.Drawing.Point(189, 155);
            this.egalizareBtn.Name = "egalizareBtn";
            this.egalizareBtn.Size = new System.Drawing.Size(105, 23);
            this.egalizareBtn.TabIndex = 19;
            this.egalizareBtn.Text = "Egalizare";
            this.egalizareBtn.UseVisualStyleBackColor = true;
            this.egalizareBtn.Click += new System.EventHandler(this.egalizareBtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Contrast";
            // 
            // contrastTrackBar
            // 
            this.contrastTrackBar.Location = new System.Drawing.Point(80, 52);
            this.contrastTrackBar.Maximum = 130;
            this.contrastTrackBar.Minimum = -130;
            this.contrastTrackBar.Name = "contrastTrackBar";
            this.contrastTrackBar.Size = new System.Drawing.Size(226, 45);
            this.contrastTrackBar.TabIndex = 17;
            this.contrastTrackBar.Scroll += new System.EventHandler(this.contrastTrackBar_Scroll);
            this.contrastTrackBar.ValueChanged += new System.EventHandler(this.contrastTrackBar_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Luminozitate";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(80, 106);
            this.trackBar1.Maximum = 255;
            this.trackBar1.Minimum = -255;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(226, 45);
            this.trackBar1.TabIndex = 15;
            this.trackBar1.ValueChanged += new System.EventHandler(this.trackBar1_ValueChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(99, 155);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 14;
            this.button1.Text = "Negativare";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonGrayscale
            // 
            this.buttonGrayscale.Location = new System.Drawing.Point(7, 155);
            this.buttonGrayscale.Name = "buttonGrayscale";
            this.buttonGrayscale.Size = new System.Drawing.Size(75, 23);
            this.buttonGrayscale.TabIndex = 13;
            this.buttonGrayscale.Text = "Grayscale";
            this.buttonGrayscale.UseVisualStyleBackColor = true;
            this.buttonGrayscale.Click += new System.EventHandler(this.buttonGrayscale_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "label1";
            // 
            // reflexieComboBox
            // 
            this.reflexieComboBox.FormattingEnabled = true;
            this.reflexieComboBox.Items.AddRange(new object[] {
            "Orizontala",
            "Verticala",
            "Aleatoriu"});
            this.reflexieComboBox.Location = new System.Drawing.Point(104, 273);
            this.reflexieComboBox.Name = "reflexieComboBox";
            this.reflexieComboBox.Size = new System.Drawing.Size(121, 21);
            this.reflexieComboBox.TabIndex = 5;
            this.reflexieComboBox.Text = "Orizontala";
            this.reflexieComboBox.SelectedIndexChanged += new System.EventHandler(this.reflexieComboBox_SelectedIndexChanged);
            // 
            // reflexieBtn
            // 
            this.reflexieBtn.Location = new System.Drawing.Point(12, 271);
            this.reflexieBtn.Name = "reflexieBtn";
            this.reflexieBtn.Size = new System.Drawing.Size(75, 23);
            this.reflexieBtn.TabIndex = 20;
            this.reflexieBtn.Text = "Reflexie";
            this.reflexieBtn.UseVisualStyleBackColor = true;
            this.reflexieBtn.Click += new System.EventHandler(this.reflexieBtn_Click);
            // 
            // textBoxZgomot
            // 
            this.textBoxZgomot.Location = new System.Drawing.Point(119, 316);
            this.textBoxZgomot.Name = "textBoxZgomot";
            this.textBoxZgomot.Size = new System.Drawing.Size(106, 20);
            this.textBoxZgomot.TabIndex = 21;
            this.textBoxZgomot.TextChanged += new System.EventHandler(this.textBoxZgomot_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 319);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Reducere zgomot";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(240, 314);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 22;
            this.button2.Text = "Zgomot";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(240, 346);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 23;
            this.button3.Text = "Zgomot";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // markovBtn
            // 
            this.markovBtn.Location = new System.Drawing.Point(12, 400);
            this.markovBtn.Name = "markovBtn";
            this.markovBtn.Size = new System.Drawing.Size(75, 23);
            this.markovBtn.TabIndex = 24;
            this.markovBtn.Text = "Markov";
            this.markovBtn.UseVisualStyleBackColor = true;
            this.markovBtn.Click += new System.EventHandler(this.markovBtn_Click);
            // 
            // FTSButton
            // 
            this.FTSButton.Location = new System.Drawing.Point(96, 400);
            this.FTSButton.Name = "FTSButton";
            this.FTSButton.Size = new System.Drawing.Size(75, 23);
            this.FTSButton.TabIndex = 25;
            this.FTSButton.Text = "FTS";
            this.FTSButton.UseVisualStyleBackColor = true;
            this.FTSButton.Click += new System.EventHandler(this.FTSButton_Click);
            // 
            // unsharpMaskBtn
            // 
            this.unsharpMaskBtn.Location = new System.Drawing.Point(180, 400);
            this.unsharpMaskBtn.Name = "unsharpMaskBtn";
            this.unsharpMaskBtn.Size = new System.Drawing.Size(75, 23);
            this.unsharpMaskBtn.TabIndex = 26;
            this.unsharpMaskBtn.Text = "Unsharp Mask";
            this.unsharpMaskBtn.UseVisualStyleBackColor = true;
            this.unsharpMaskBtn.Click += new System.EventHandler(this.unsharpMaskBtn_Click);
            // 
            // kirschBtn
            // 
            this.kirschBtn.Location = new System.Drawing.Point(96, 438);
            this.kirschBtn.Name = "kirschBtn";
            this.kirschBtn.Size = new System.Drawing.Size(75, 23);
            this.kirschBtn.TabIndex = 27;
            this.kirschBtn.Text = "Kirsch";
            this.kirschBtn.UseVisualStyleBackColor = true;
            this.kirschBtn.Click += new System.EventHandler(this.kirschBtn_Click);
            // 
            // PrewittBtn
            // 
            this.PrewittBtn.Location = new System.Drawing.Point(182, 439);
            this.PrewittBtn.Name = "PrewittBtn";
            this.PrewittBtn.Size = new System.Drawing.Size(75, 23);
            this.PrewittBtn.TabIndex = 28;
            this.PrewittBtn.Text = "Prewitt ";
            this.PrewittBtn.UseVisualStyleBackColor = true;
            this.PrewittBtn.Click += new System.EventHandler(this.PrewittBtn_Click);
            // 
            // FreiChenBtn
            // 
            this.FreiChenBtn.Location = new System.Drawing.Point(267, 400);
            this.FreiChenBtn.Name = "FreiChenBtn";
            this.FreiChenBtn.Size = new System.Drawing.Size(75, 23);
            this.FreiChenBtn.TabIndex = 29;
            this.FreiChenBtn.Text = "Frei-Chen";
            this.FreiChenBtn.UseVisualStyleBackColor = true;
            this.FreiChenBtn.Click += new System.EventHandler(this.FreiChenBtn_Click);
            // 
            // GaborBtn
            // 
            this.GaborBtn.Location = new System.Drawing.Point(267, 438);
            this.GaborBtn.Name = "GaborBtn";
            this.GaborBtn.Size = new System.Drawing.Size(75, 23);
            this.GaborBtn.TabIndex = 30;
            this.GaborBtn.Text = "Gabor";
            this.GaborBtn.UseVisualStyleBackColor = true;
            this.GaborBtn.Click += new System.EventHandler(this.GaborBtn_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 473);
            this.Controls.Add(this.GaborBtn);
            this.Controls.Add(this.FreiChenBtn);
            this.Controls.Add(this.PrewittBtn);
            this.Controls.Add(this.kirschBtn);
            this.Controls.Add(this.unsharpMaskBtn);
            this.Controls.Add(this.FTSButton);
            this.Controls.Add(this.markovBtn);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxZgomot);
            this.Controls.Add(this.reflexieBtn);
            this.Controls.Add(this.reflexieComboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.buttonLoad);
            this.Controls.Add(this.panelDestination);
            this.Controls.Add(this.panelSource);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.contrastTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelSource;
        private System.Windows.Forms.Panel panelDestination;
        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonGrayscale;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar contrastTrackBar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button egalizareBtn;
        private System.Windows.Forms.ComboBox reflexieComboBox;
        private System.Windows.Forms.Button reflexieBtn;
        private System.Windows.Forms.TextBox textBoxZgomot;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button markovBtn;
        private System.Windows.Forms.Button FTSButton;
        private System.Windows.Forms.Button unsharpMaskBtn;
        private System.Windows.Forms.Button kirschBtn;
        private System.Windows.Forms.Button PrewittBtn;
        private System.Windows.Forms.Button FreiChenBtn;
        private System.Windows.Forms.Button GaborBtn;
    }
}

