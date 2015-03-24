using System;
using System.Net;
using System.Threading.Tasks;

namespace SpotifyWebHelperAPI.Web
{
    public class WebClient : IWebClient
    {
        private readonly WebHeaderCollection _headers;

        public WebClient(WebHeaderCollection headers)
        {
            if (headers == null) throw new ArgumentNullException("headers");
            _headers = headers;
        }

        public string DownloadString(string address)
        {
            return DownloadString(new Uri(address));
        }

        public string DownloadString(Uri address)
        {
            string result = string.Empty;

            using (var client = new System.Net.WebClient { Headers = _headers })
            {
                result = client.DownloadString(address);
            }

            return result;
        }

        public Task<string> DownloadStringAsync(string address)
        {
            throw new NotImplementedException();
        }

        public Task<string> DownloadStringAsync(Uri address)
        {
            throw new NotImplementedException();
        }
    }
}