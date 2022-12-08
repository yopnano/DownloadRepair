using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace DownloadRepair
{
    public class FileDownload
    {
        private volatile bool _allowedToRun;    // Start / stop mechanism
        private readonly string _sourceUrl;     // url to the file, to download.
        private readonly string _destination;   // path to save the file
        private readonly int _chunkSize;        // Buffer size
        private readonly IProgress<double> _progress;   // Progression status
        private readonly Lazy<long> _contentLength;
        
        private readonly Stopwatch _sw; // Chronomètre
        private double _swOld;
        private double _bytesWrittenOld;
        private double _bps;
        private TimeSpan _rTime;
        

        public long BytesWritten { get; private set; }
        public long ContentLength => _contentLength.Value;

        public double CalcFrequency;
        public double DownloadSpeed => _bps;
        public TimeSpan RemainingTime => _rTime;

        public bool Done => ContentLength == BytesWritten;


        public FileDownload(string source, string destination, int chunkSize = 5120, IProgress<double> progress = null)
        {
            if (string.IsNullOrEmpty(source))
                throw new ArgumentNullException("source is empty");
            if (string.IsNullOrEmpty(destination))
                throw new ArgumentNullException("destination is empty");

            _allowedToRun = true;

            _sourceUrl = source;
            _destination = destination;
            _chunkSize = chunkSize;
            _progress = progress;
            _contentLength = new Lazy<long>(() => GetContentLength());
            _sw = Stopwatch.StartNew();
            _swOld = _sw.Elapsed.TotalSeconds;
            CalcFrequency = 1.0;
            _bps = 0.0;
            _rTime = TimeSpan.Zero;

            // Récupération de la taille du fichier de destination
            if (File.Exists(destination))
            {
                try
                {
                    BytesWritten = new FileInfo(destination).Length;
                }
                catch
                {
                    BytesWritten = 0;
                }
            }
            else
                BytesWritten = 0;
        }

        // Méthode de vérification d'url
        public bool UrlValiator(string url)
        {
            Uri validatedUrl;
            return Uri.TryCreate(url, UriKind.Absolute, out validatedUrl);
        }

        // Méthode de récupération de la taille du contenu
        private long GetContentLength()
        {
            if (!UrlValiator(_sourceUrl))
                throw new Exception("invalid url");
            
            var request = (HttpWebRequest)WebRequest.Create(_sourceUrl);
            request.Method = "HEAD";

            using var response = request.GetResponse();
            return response.ContentLength;
        }

        // Méthode d'éxécution de la requette et de l'écriture du fichier de destination
        private async Task Start(long range)
        {
            if (!_allowedToRun)
                throw new InvalidOperationException();

            if (Done)
                //file has been found in folder destination and is already fully downloaded 
                return;

            var request = (HttpWebRequest)WebRequest.Create(_sourceUrl);
            request.Method = "GET";
            request.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)";
            request.AddRange(range);

            using (var response = await request.GetResponseAsync())
            {
                using (var responseStream = response.GetResponseStream())
                {
                    using (var fs = new FileStream(_destination, FileMode.Append, FileAccess.Write, FileShare.ReadWrite))
                    {
                        while (_allowedToRun)
                        {
                            var buffer = new byte[_chunkSize];
                            var bytesRead = await responseStream.ReadAsync(buffer).ConfigureAwait(false);

                            if (bytesRead == 0) break;

                            SpeedCalculation();

                            await fs.WriteAsync(buffer.AsMemory(0, bytesRead));
                            BytesWritten += bytesRead;
                            _progress?.Report((double)BytesWritten / ContentLength);
                        }

                        await fs.FlushAsync();
                    }
                }
            }
        }


        private void SpeedCalculation()
        {
            if (_sw.Elapsed.TotalSeconds - _swOld > CalcFrequency)
            {
                double dBytes = BytesWritten - _bytesWrittenOld ; // Octets téléchargé depuis le dernier cycle
                double second = _sw.Elapsed.TotalSeconds - _swOld; // Temps écoulé depuis le dernier cycle (sec)

                _bps = dBytes / second; // Vitesse de téléchargement en octets par seconde

                // Estimation du temps en heure minute seconde
                double rBytes = ContentLength - BytesWritten;
                double rTimeSec = rBytes / _bps;

                _rTime = TimeSpan.FromSeconds(rTimeSec);

                // Actualisation des valeurs pour le prochain calcul
                _bytesWrittenOld = BytesWritten;
                _swOld = _sw.Elapsed.TotalSeconds;
            }
        }

        // Début / reprise du téléchargement
        public Task Start()
        {
            _allowedToRun = true;

            _sw.Restart();
            _bytesWrittenOld = BytesWritten;
            _swOld = _sw.Elapsed.TotalSeconds;

            return Start(BytesWritten);
        }

        // Interruption du téléchargement
        public void Pause()
        {
            _allowedToRun = false;
            _sw.Stop();
        }
    }
}
