using System;
using SpotifyWebHelperAPI.Models;
using SpotifyWebHelperAPI.Serialization;
using SpotifyWebHelperAPI.Web;

namespace SpotifyWebHelperAPI
{
    public class SpotifyEmbededAuthProvider : IAuthProvider
    {
        private const string CfidEndpoint = "simplecsrf/token.json?";
        private const string AuthEndpoint = "https://embed.spotify.com/openplay/?uri=spotify:track:1D7UOeKgTlPWH54038dS6r";

        private readonly IRequestService _requestService;
        private readonly IDeserializer _deserializer;

        public SpotifyEmbededAuthProvider(IRequestService requestService, IDeserializer deserializer)
        {
            if (requestService == null) throw new ArgumentNullException("requestService");
            if (deserializer == null) throw new ArgumentNullException("deserializer");
            _requestService = requestService;
            _deserializer = deserializer;
        }

        public string GetAuth()
        {
            var response = _requestService.SendSimpleRequest(AuthEndpoint);
            return ParseAuthResponse(response);
        }

        private string ParseAuthResponse(string response)
        {
            var resp = response.Replace(" ", "");

            foreach (var line in resp.Split(new[] { "\n" }, StringSplitOptions.RemoveEmptyEntries))
            {
                if (line.StartsWith("tokenData"))
                {
                    var tokenLine = line.Split(new[] { "'" }, StringSplitOptions.RemoveEmptyEntries);
                    return tokenLine.Length > 1 ? tokenLine[1] : string.Empty;
                }
            }

            return string.Empty;
        }

        public CFIDDto GetCFID()
        {
            var response = _requestService.SendRequest(CfidEndpoint);
            return _deserializer.DeserializeObject<CFIDDto>(response);
        }
    }
}