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
            this.bPaste = new System.Windows.Forms.Button();
            this.txtFile = new System.Windows.Forms.TextBox();
            this.bStart = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.ChkProgressType = new System.Windows.Forms.CheckBox();
            this.bOpen = new System.Windows.Forms.Button();
            this.lTxtSpeed = new System.Windows.Forms.Label();
            this.lSpeed = new System.Windows.Forms.Label();
            this.lETime = new System.Windows.Forms.Label();
            this.lTxtETime = new System.Windows.Forms.Label();
            this.bStop = new System.Windows.Forms.Button();
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
            // txtFile
            // 
            this.txtFile.Location = new System.Drawing.Point(52, 32);
            this.txtFile.Name = "txtFile";
            this.txtFile.Size = new System.Drawing.Size(789, 23);
            this.txtFile.TabIndex = 4;
            this.txtFile.TextChanged += new System.EventHandler(this.TxtFile_TextChanged);
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
            // ChkProgressType
            // 
            this.ChkProgressType.AutoSize = true;
            this.ChkProgressType.Checked = true;
            this.ChkProgressType.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ChkProgressType.Location = new System.Drawing.Point(15, 73);
            this.ChkProgressType.Name = "ChkProgressType";
            this.ChkProgressType.Size = new System.Drawing.Size(132, 19);
            this.ChkProgressType.TabIndex = 7;
            this.ChkProgressType.Text = "Progression absolue";
            this.ChkProgressType.UseVisualStyleBackColor = true;
            // 
            // bOpen
            // 
            this.bOpen.Location = new System.Drawing.Point(859, 70);
            this.bOpen.Name = "bOpen";
            this.bOpen.Size = new System.Drawing.Size(70, 22);
            this.bOpen.TabIndex = 6;
            this.bOpen.Text = "Ouvrir";
            this.bOpen.UseVisualStyleBackColor = true;
            this.bOpen.Visible = false;
            this.bOpen.Click += new System.EventHandler(this.BOpen_Click);
            // 
            // lTxtSpeed
            // 
            this.lTxtSpeed.AutoSize = true;
            this.lTxtSpeed.Location = new System.Drawing.Point(167, 75);
            this.lTxtSpeed.Name = "lTxtSpeed";
            this.lTxtSpeed.Size = new System.Drawing.Size(49, 15);
            this.lTxtSpeed.TabIndex = 8;
            this.lTxtSpeed.Text = "Vitesse :";
            this.lTxtSpeed.Visible = false;
            // 
            // lSpeed
            // 
            this.lSpeed.AutoSize = true;
            this.lSpeed.Location = new System.Drawing.Point(215, 75);
            this.lSpeed.Name = "lSpeed";
            this.lSpeed.Size = new System.Drawing.Size(35, 15);
            this.lSpeed.TabIndex = 9;
            this.lSpeed.Text = "Mo/s";
            this.lSpeed.Visible = false;
            // 
            // lETime
            // 
            this.lETime.AutoSize = true;
            this.lETime.Location = new System.Drawing.Point(386, 76);
            this.lETime.Name = "lETime";
            this.lETime.Size = new System.Drawing.Size(59, 15);
            this.lETime.TabIndex = 11;
            this.lETime.Text = "hh mm ss";
            this.lETime.Visible = false;
            // 
            // lTxtETime
            // 
            this.lTxtETime.AutoSize = true;
            this.lTxtETime.Location = new System.Drawing.Point(299, 76);
            this.lTxtETime.Name = "lTxtETime";
            this.lTxtETime.Size = new System.Drawing.Size(88, 15);
            this.lTxtETime.TabIndex = 10;
            this.lTxtETime.Text = "Durée estimée :";
            this.lTxtETime.Visible = false;
            // 
            // bStop
            // 
            this.bStop.Location = new System.Drawing.Point(859, 95);
            this.bStop.Name = "bStop";
            this.bStop.Size = new System.Drawing.Size(70, 23);
            this.bStop.TabIndex = 12;
            this.bStop.Text = "Arreter";
            this.bStop.UseVisualStyleBackColor = true;
            this.bStop.Visible = false;
            this.bStop.Click += new System.EventHandler(this.BStop_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(944, 129);
            this.Controls.Add(this.bStop);
            this.Controls.Add(this.lETime);
            this.Controls.Add(this.lTxtETime);
            this.Controls.Add(this.lSpeed);
            this.Controls.Add(this.lTxtSpeed);
            this.Controls.Add(this.bOpen);
            this.Controls.Add(this.ChkProgressType);
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
            this.PerformLayout();

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
        private CheckBox ChkProgressType;
        private Button bOpen;
        private Label lTxtSpeed;
        private Label lSpeed;
        private Label lETime;
        private Label lTxtETime;
        private Button bStop;
        private HttpClientDownloadWithProgress client = new HttpClientDownloadWithProgress();
    }
}