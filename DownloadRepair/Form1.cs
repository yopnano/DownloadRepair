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

namespace DownloadRepair
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        private void BBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new();

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txtFile.Text = ofd.FileName;
            }
        }

        private void Stop()
        {
            client.Cancel();
            client.Dispose();
            bStop.Visible = false;
            progressBar1.Visible = false;
            lTxtSpeed.Visible = false;
            lSpeed.Visible = false;
            lTxtETime.Visible = false;
            lETime.Visible = false;
            bStart.Visible = true;
        }

        private async void BStart_Click(object sender, EventArgs e)
        {
            Stopwatch sw = Stopwatch.StartNew(); // Chronomètre

            if (txtUrl.Text != "" && txtFile.Text != "")
            {
                progressBar1.Value = 0;
                progressBar1.Visible = true;
                bStart.Visible = false;
                bStop.Visible = true;
                progressBar1.Maximum = 65000;

                double last_sec = 0;
                double mem_sec = 0;
                double last_Bytes = 0;

                try
                {
                    client.Init(txtUrl.Text, txtFile.Text);

                    sw.Start();
                    double dtTime = 0;
                    double speed = 0;
                    
                    client.ProgressChanged += (totalFileSize, totalBytesDownloaded, progressPercentage) =>
                    {
                        client.ProgressTypeAbsolute(ChkProgressType.Checked);

                        //Console.WriteLine($"{progressPercentage}% ({totalBytesDownloaded}/{totalFileSize})");
                        progressBar1.Value = progressPercentage != null ? (int)(progressPercentage * 650) : 0;
                                               
                        
                        // Calcul vitesse
                        double dtMByte = totalBytesDownloaded - last_Bytes;
                                
                        if ((sw.Elapsed.TotalSeconds - mem_sec) > 5)
                        {
                            dtTime = sw.Elapsed.TotalSeconds - last_sec;
                            speed = dtMByte / dtTime; // Byte/s
                            mem_sec = sw.Elapsed.TotalSeconds;
                        }

                        if (dtTime > 0.0 && speed > 0.0 && totalFileSize > 0)
                        {
                            double speedMO = Math.Round(speed / 1000000, 2); // Mo/s

                            // Calcul temps
                            double byteDiff = (double)(totalFileSize - totalBytesDownloaded);
                            double etTotalSecond = byteDiff / speed;

                            // Mise en forme HH:MM:SS
                            TimeSpan time = TimeSpan.FromSeconds(etTotalSecond);
                            String format = @"hh\:mm\:ss";

                            if (etTotalSecond < 3600 && etTotalSecond >= 60)
                                format = @"mm\:ss";

                            else if (etTotalSecond < 60)
                                format = @"ss";

                            String strTime = time.ToString(format);

                            // Memo cycle
                            last_Bytes = totalBytesDownloaded;
                            last_sec = sw.Elapsed.TotalSeconds;

                            // Affichage
                            lTxtSpeed.Visible = speedMO > 0;
                            lSpeed.Visible = lTxtSpeed.Visible;
                            lSpeed.Text = speedMO.ToString() + " Mo/s";

                            lTxtETime.Visible = etTotalSecond > 0;
                            lETime.Visible = lTxtETime.Visible;
                            lETime.Text = strTime;
                        }
                    };

                    await client.StartAppendFile();
                    Stop();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Download repair : erreur", MessageBoxButtons.OK);
                    Stop();
                    throw;
                }
            }
        }

        private void BPaste_Click(object sender, EventArgs e)
        {
            txtUrl.Text = Clipboard.GetText();
        }

        private void TxtFile_TextChanged(object sender, EventArgs e)
        {
            bOpen.Visible = txtFile.Text != "";
        }

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

        private void BStop_Click(object sender, EventArgs e)
        {
            Stop();
        }
    }
}
