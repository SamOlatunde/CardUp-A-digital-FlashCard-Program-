
namespace Digital_Falshcard_Program
{
    partial class DigiCards
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
            this.btnNext = new System.Windows.Forms.Button();
            this.btnShow = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnHelp = new System.Windows.Forms.Button();
            this.lblFDisplay = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnPrev = new System.Windows.Forms.Button();
            this.Title = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(143, 463);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(56, 26);
            this.btnNext.TabIndex = 0;
            this.btnNext.Text = ">>";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.UseWaitCursor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnShow
            // 
            this.btnShow.Location = new System.Drawing.Point(290, 455);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(63, 55);
            this.btnShow.TabIndex = 1;
            this.btnShow.Text = "Show ";
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.UseWaitCursor = true;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(431, 474);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(63, 67);
            this.btnLoad.TabIndex = 2;
            this.btnLoad.Text = "Load ";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.UseWaitCursor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(561, 474);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(120, 40);
            this.btnHelp.TabIndex = 3;
            this.btnHelp.Text = "Help";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.UseWaitCursor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // lblFDisplay
            // 
            this.lblFDisplay.AllowDrop = true;
            this.lblFDisplay.BackColor = System.Drawing.Color.White;
            this.lblFDisplay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblFDisplay.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.lblFDisplay.Location = new System.Drawing.Point(81, 80);
            this.lblFDisplay.Name = "lblFDisplay";
            this.lblFDisplay.Size = new System.Drawing.Size(600, 359);
            this.lblFDisplay.TabIndex = 4;
            this.lblFDisplay.Text = " \r\n";
            this.lblFDisplay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblFDisplay.UseWaitCursor = true;
            this.lblFDisplay.Click += new System.EventHandler(this.lblFDisplay_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnPrev
            // 
            this.btnPrev.Location = new System.Drawing.Point(81, 463);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(56, 26);
            this.btnPrev.TabIndex = 5;
            this.btnPrev.Text = "<<";
            this.btnPrev.UseVisualStyleBackColor = true;
            this.btnPrev.UseWaitCursor = true;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // Title
            // 
            this.Title.Location = new System.Drawing.Point(196, 31);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(346, 29);
            this.Title.TabIndex = 6;
            // 
            // DigiCards
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LavenderBlush;
            this.ClientSize = new System.Drawing.Size(747, 580);
            this.Controls.Add(this.Title);
            this.Controls.Add(this.btnPrev);
            this.Controls.Add(this.lblFDisplay);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnShow);
            this.Controls.Add(this.btnNext);
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "DigiCards";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Digital Flashcards";
            this.UseWaitCursor = true;
            this.Load += new System.EventHandler(this.btnNext_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.Label lblFDisplay;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Label Title;
    }
}

