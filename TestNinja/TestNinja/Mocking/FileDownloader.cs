using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TestNinja.Mocking
{
    public interface IFileDownloader
    {
        void DownloadFile(string url, string path);
    }

    public class FileDownloader : IFileDownloader
    {
        private WebClient _webClient;

        public FileDownloader()
        { 
            _webClient = new WebClient();
        }

        public void DownloadFile(string url, string path)
        {
            _webClient.DownloadFile(url, path);
        }
    }
}
