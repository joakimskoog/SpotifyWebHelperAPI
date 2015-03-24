using System;
using System.Threading.Tasks;

namespace SpotifyWebHelperAPI.Web
{
    public interface IWebClient
    {
        string DownloadString(string address);

        string DownloadString(Uri address);

        Task<string> DownloadStringAsync(string address);

        Task<string> DownloadStringAsync(Uri address);
    }
}