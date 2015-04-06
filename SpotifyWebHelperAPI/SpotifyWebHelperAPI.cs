using System;
using System.Net;
using SpotifyWebHelperAPI.Models;
using SpotifyWebHelperAPI.Serialization;
using SpotifyWebHelperAPI.Web;

namespace SpotifyWebHelperAPI
{
    public static class SpotifyWebHelperApi
    {
        public static ISpotifyWebHelperCommunicationService Create()
        {
            try
            {
                var headers = new WebHeaderCollection
                {
                    {"Origin", "https://embed.spotify.com"},
                    {"Referer", "https://embed.spotify.com/?uri=spotify:track:7skutlFh5m9qOpfgZMSenH"},
                    {
                        HttpRequestHeader.UserAgent,
                        @"Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/535.2 (KHTML, like Gecko) Chrome/15.0.874.121 Safari/535.2"
                    }
                };

                var requestService = new RequestService(headers, "127.0.0.1", 4380, new UnixTimeStampConverter());
                var deserializer = new JsonDeserializer();

                var authProvider = new SpotifyEmbededAuthProvider(requestService, deserializer);

                var auth = authProvider.GetAuth();
                var cfid = authProvider.GetCFID();

                if (!AreTokensValid(auth, cfid))
                {
                    throw new Exception("Failed to generate auths");
                }

                return new SpotifyWebHelperCommunicationService(requestService, deserializer, auth, cfid.Token);

            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Failed to create the ISpotifyWebHelperCommunicationService due to the reason '{0}'", ex), ex);
            }
        }

        private static bool AreTokensValid(string auth, CFIDDto cfid)
        {
            return !string.IsNullOrEmpty(auth) && cfid != null && cfid.Error == null &&
                   !string.IsNullOrEmpty(cfid.Token);
        }
    }
}