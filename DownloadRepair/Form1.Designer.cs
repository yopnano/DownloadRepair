namespace DownloadRepair
{
    partial class Form1
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
            this.lblUrl = new System.Windows.Forms.Label();
            this.lblFile = new System.Windows.Forms.Label();
            this.bBrowse = new System.Windows.Forms.Button();
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtFile = new System.Windows.Forms.TextBox();
            this.bStart = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.bPaste = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblUrl
            // 
            this.lblUrl.AutoSize = true;
            this.lblUrl.Location = new System.Drawing.Point(3, 6);
            this.lblUrl.Name = "lblUrl";
            this.lblUrl.Size = new System.Drawing.Size(28, 15);
            this.lblUrl.TabIndex = 0;
            this.lblUrl.Text = "Url :";
            // 
            // lblFile
            // 
            this.lblFile.AutoSize = true;
            this.lblFile.Location = new System.Drawing.Point(0, 38);
            this.lblFile.Name = "lblFile";
            this.lblFile.Size = new System.Drawing.Size(48, 15);
            this.lblFile.TabIndex = 1;
            this.lblFile.Text = "Fichier :";
            // 
            // bBrowse
            // 
            this.bBrowse.Location = new System.Drawing.Point(847, 32);
            this.bBrowse.Name = "bBrowse";
            this.bBrowse.Size = new System.Drawing.Size(70, 23);
            this.bBrowse.TabIndex = 2;
            this.bBrowse.Text = "Parcourir";
            this.bBrowse.UseVisualStyleBackColor = true;
            this.bBrowse.Click += new System.EventHandler(this.BBrowse_Click);
            // 
            // txtUrl
            // 
            this.txtUrl.Location = new System.Drawing.Point(52, 3);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(789, 23);
            this.txtUrl.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.bPaste);
            this.panel1.Controls.Add(this.txtFile);
            this.panel1.Controls.Add(this.bBrowse);
            this.panel1.Controls.Add(this.lblFile);
            this.panel1.Controls.Add(this.txtUrl);
            this.panel1.Controls.Add(this.lblUrl);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(920, 60);
            this.panel1.TabIndex = 4;
            // 
            // txtFile
            // 
            this.txtFile.Location = new System.Drawing.Point(52, 32);
            this.txtFile.Name = "txtFile";
            this.txtFile.Size = new System.Drawing.Size(789, 23);
            this.txtFile.TabIndex = 4;
            // 
            // bStart
            // 
            this.bStart.Location = new System.Drawing.Point(859, 94);
            this.bStart.Name = "bStart";
            this.bStart.Size = new System.Drawing.Size(70, 23);
            this.bStart.TabIndex = 5;
            this.bStart.Text = "Démarrer";
            this.bStart.UseVisualStyleBackColor = true;
            this.bStart.Click += new System.EventHandler(this.BStart_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(15, 94);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(838, 23);
            this.progressBar1.TabIndex = 6;
            this.progressBar1.Visible = false;
            // 
            // bPaste
            // 
            this.bPaste.Location = new System.Drawing.Point(847, 3);
            this.bPaste.Name = "bPaste";
            this.bPaste.Size = new System.Drawing.Size(70, 23);
            this.bPaste.TabIndex = 5;
            this.bPaste.Text = "Coller";
            this.bPaste.UseVisualStyleBackColor = true;
            this.bPaste.Click += new System.EventHandler(this.BPaste_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(944, 129);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.bStart);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(960, 168);
            this.MinimumSize = new System.Drawing.Size(960, 168);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Downlad repair";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Label lblUrl;
        private Label lblFile;
        private Button bBrowse;
        private TextBox txtUrl;
        private Panel panel1;
        private TextBox txtFile;
        private Button bStart;
        private ProgressBar progressBar1;
        private Button bPaste;
    }
}