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

        private async void BStart_Click(object sender, EventArgs e)
        {
            if (txtUrl.Text != "" && txtFile.Text != "")
            {
                progressBar1.Value = 0;
                progressBar1.Visible = true;
                progressBar1.Maximum = 65000;

                try
                {
                        using var client = new HttpClientDownloadWithProgress(txtUrl.Text, txtFile.Text);

                        client.ProgressChanged += (totalFileSize, totalBytesDownloaded, progressPercentage) =>
                        {
                            client.ProgressTypeAbsolute(ChkProgressType.Checked);
                            
                            //Console.WriteLine($"{progressPercentage}% ({totalBytesDownloaded}/{totalFileSize})");
                            progressBar1.Value = progressPercentage != null ? (int)(progressPercentage * 650) : 0;
                        };

                    await client.StartAppendFile();
                    progressBar1.Visible = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Download repair : erreur", MessageBoxButtons.OK);
                    throw;
                }
            }
        }

        private void BPaste_Click(object sender, EventArgs e)
        {
            txtUrl.Text = Clipboard.GetText();
        }

        private void txtFile_TextChanged(object sender, EventArgs e)
        {
            bOpen.Visible = txtFile.Text != "";
        }

        private void bOpen_Click(object sender, EventArgs e)
        {
            var p = new Process();
            p.StartInfo = new ProcessStartInfo(txtFile.Text)
            {
                UseShellExecute = true
            };
            p.Start();
        }
    }
}
