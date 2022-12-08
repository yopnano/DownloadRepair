using System.Net.Http.Headers;
using System;
using System.ComponentModel;
using Microsoft.VisualBasic;

namespace DownloadRepair
{
    public class HttpClientDownloadWithProgress : IDisposable
    {
        private string _downloadUrl;
        private string _destinationFilePath;
        private long _fileSize;
        private long _progressType;
        private bool _allowedToRun;

        private HttpClient? _httpClient;
        private CancellationTokenSource _cts = new();

        public delegate void ProgressChangedHandler(long? totalFileSize, long totalBytesDownloaded, double? progressPercentage);

        public event ProgressChangedHandler? ProgressChanged;


        public HttpClientDownloadWithProgress(string downloadUrl, string destinationFilePath)
        {
            _downloadUrl = downloadUrl;
            _destinationFilePath = destinationFilePath;
            _fileSize = 0;
            _progressType = 0;
        }

        public HttpClientDownloadWithProgress()
        {
            _downloadUrl = "";
            _destinationFilePath = "";
            _fileSize = 0;
            _progressType = 0;
        }

        public void Init(string downloadUrl, string destinationFilePath)
        {
            _downloadUrl = downloadUrl;
            _destinationFilePath = destinationFilePath;
        }
        public bool UrlValiator(string url)
        {
            Uri validatedUrl;
            return Uri.TryCreate(url, UriKind.Absolute, out validatedUrl);
        }

        public async Task StartAppendFile()
        {
            _httpClient = new HttpClient { Timeout = TimeSpan.FromDays(1) };
                        
            if (UrlValiator(_downloadUrl))
            {
                using var response = await _httpClient.GetAsync(_downloadUrl, HttpCompletionOption.ResponseHeadersRead);

                _fileSize = GetFileLenght();
                long end = GetContentLenght(response);

                if (end > 0)
                {
                    _httpClient.DefaultRequestHeaders.Range = new RangeHeaderValue(_fileSize, end);

                    using var data = await _httpClient.GetAsync(_downloadUrl, HttpCompletionOption.ResponseHeadersRead);
                    await DownloadFileFromHttpResponseMessage(data);
                }
            }
            else
            {
                MessageBox.Show("Veuillez saisir une url valide", "Url invalide", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }        
        }


        public async Task StartDownload()
        {
            _httpClient = new HttpClient { Timeout = TimeSpan.FromDays(1) };

            using var response = await _httpClient.GetAsync(_downloadUrl, HttpCompletionOption.ResponseHeadersRead, _cts.Token);
            await DownloadFileFromHttpResponseMessage(response);
        }

        public void Cancel()
        {
            _cts.Cancel();
            _cts = new CancellationTokenSource();
        }

        public void ProgressTypeAbsolute(bool type)
        {
            _progressType = type ? _fileSize : 0;
        }

        private async Task DownloadFileFromHttpResponseMessage(HttpResponseMessage response)
        {
            response.EnsureSuccessStatusCode();

            var totalBytes = response.Content.Headers.ContentLength;

            using var contentStream = await response.Content.ReadAsStreamAsync();
            await ProcessContentStream(totalBytes, contentStream);
        }

        private static long GetContentLenght(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
            {
                return (long)response.Content.Headers.ContentLength;
            }
            else
            {
                MessageBox.Show("Url invalide ou accès restreint", "Erreur d'acces au fichier", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return 0;
        }

        private long GetFileLenght()
        {
            FileInfo fi = new(_destinationFilePath);
            if (fi.Exists)
            {
                return fi.Length;
            }
            return 0;
        }

        private async Task ProcessContentStream(long? totalDownloadSize, Stream contentStream)
        {
            var totalBytesRead = 0L;
            var readCount = 0L;
            var buffer = new byte[8192];
            var isMoreToRead = true;

            using FileStream? fileStream = new(_destinationFilePath, FileMode.Append, FileAccess.Write, FileShare.Read, 8192, true);
            do
            {
                int bytesRead = await contentStream.ReadAsync(buffer);
                if (bytesRead == 0)
                {
                    isMoreToRead = false;
                    TriggerProgressChanged(totalDownloadSize, totalBytesRead);
                    continue;
                }

                await fileStream.WriteAsync(buffer.AsMemory(0, bytesRead));

                totalBytesRead += bytesRead;
                readCount += 1;

                if (readCount % 100 == 0)
                    TriggerProgressChanged(totalDownloadSize, totalBytesRead);
            }
            while (isMoreToRead);
        }

        private void TriggerProgressChanged(long? totalDownloadSize, long totalBytesRead)
        {
            if (ProgressChanged == null)
                return;

            double? progressPercentage = null;
            if (totalDownloadSize.HasValue)
                progressPercentage = Math.Round( (double) (_progressType + totalBytesRead) / (_progressType + totalDownloadSize.Value) * 100, 2 );

            ProgressChanged(totalDownloadSize, totalBytesRead, progressPercentage);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}