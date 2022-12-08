using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace DownloadRepair
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Bouton coller l'url
        private void BPaste_Click(object sender, EventArgs e)
        {
            txtUrl.Text = Clipboard.GetText();
        }
        
        // Bouton Explorateur de fichier
        private void BBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new();

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txtFile.Text = ofd.FileName;
            }
        }
        
        // Animation du bouton open champ vide
        private void TxtFile_TextChanged(object sender, EventArgs e)
        {
            bOpen.Visible = txtFile.Text != "";
        }

        // Bouton Ouverture du fichier avec le programme par défaut
        private void BOpen_Click(object sender, EventArgs e)
        {
            var p = new Process
            {
                StartInfo = new ProcessStartInfo(txtFile.Text)
                {
                    UseShellExecute = true
                }
            };
            p.Start();
        }
        
        // Bouton démarrer
        private void BStart_Click(object sender, EventArgs e)
        {            
            if (txtUrl.Text != "" && txtFile.Text != "")
            {
                Start();
               /* try
                {
                    client.Init(txtUrl.Text, txtFile.Text);
                    await client.StartAppendFile();
                    Stop();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Download repair : erreur", MessageBoxButtons.OK);
                    Stop();
                    throw;
                }*/
            }
        }

        // Fonction de démarrage appelée par le bouton start
        private async void Start()
        {
            var progressReport = new Progress<double>(UpdateProgressBar);
            
            fd = new FileDownload(txtUrl.Text, txtFile.Text, 5120, progressReport);
            DisplayStart();
            fd.CalcFrequency = 5;
            await fd.Start();

            if (fd.Done)
                Stop();
        }

        // Animation en mode téléchargement
        private void DisplayStart()
        {
            bStart.Visible = false;
            bStop.Visible = true;

            lTxtSpeed.Visible = true;
            lSpeed.Visible = true;

            lTxtETime.Visible = true;
            lETime.Visible = true;

            progressBar1.Value = 0;
            progressBar1.Maximum = 65000;
            progressBar1.Visible = true;
        }
        
        // Animation barre de progression
        private void UpdateProgressBar(double progressValue)
        {
            double progress = progressValue * progressBar1.Maximum;
            progressBar1.Value = (int)progress;

            UpdateSpeed();
        }
        
        // Affichage de la vitesse et du temps restant
        private void UpdateSpeed()
        {
            double speedMO = Math.Round(fd.DownloadSpeed / 1000000, 2); // Mo/s
            TimeSpan ts = fd.RemainingTime;

            String format = @"hh\:mm\:ss";

            if (ts.TotalSeconds < 3600 && ts.TotalSeconds >= 60)
                format = @"mm\:ss";

            else if (ts.TotalSeconds < 60)
                format = @"ss";

            String strTime = ts.ToString(format);            

            // Affichage
            lSpeed.Text = speedMO.ToString() + " Mo/s";           
            lETime.Text = strTime;
        }
        
        // Bouton d'arrêt
        private void BStop_Click(object sender, EventArgs e)
        {
            Stop();
        }

        // Fonction d'arrêt appelée par le bouton d'arrêt
        private void Stop()
        {
            fd.Pause();
            DisplayStop();
        }

        private void DisplayStop()
        {
            bStop.Visible = false;
            bStart.Visible = true;

            lTxtSpeed.Visible = false;
            lSpeed.Visible = false;

            lTxtETime.Visible = false;
            lETime.Visible = false;

            progressBar1.Visible = false;
        }
    }
}
