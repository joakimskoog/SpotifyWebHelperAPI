using System.Net;
using SpotifyWebHelperAPI.Serialization;
using WebClient = SpotifyWebHelperAPI.Web.WebClient;

namespace SpotifyWebHelperAPI
{
    public static class SpotifyWebHelperApi
    {
        public static ISpotifyWebHelperCommunicationService Create()
        {
            var headers = new WebHeaderCollection
            {
                {"Origin", "https://embed.spotify.com"},
                {"Referer", "https://embed.spotify.com/?uri=spotify:track:7skutlFh5m9qOpfgZMSenH"}
            };

            var client = new WebClient(headers);

            return new SpotifyWebHelperCommunicationService(
                client,
                new UnixTimeStampConverter(),
                new SpotifyEmbededAuthProvider(client),
                new JsonDeserializer());
        }
    }
}