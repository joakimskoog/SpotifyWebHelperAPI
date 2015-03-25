using System;
using SpotifyWebHelperAPI.Web;

namespace SpotifyWebHelperAPI
{
    public class SpotifyEmbededAuthProvider : IAuthProvider
    {
        private readonly IWebClient _webClient;

        public SpotifyEmbededAuthProvider(IWebClient webClient)
        {
            if (webClient == null) throw new ArgumentNullException("webClient");
            _webClient = webClient;
        }

        public string GetAuth()
        {
            throw new System.NotImplementedException();
        }

        public string GetCFID()
        {
            throw new System.NotImplementedException();
        }
    }
}