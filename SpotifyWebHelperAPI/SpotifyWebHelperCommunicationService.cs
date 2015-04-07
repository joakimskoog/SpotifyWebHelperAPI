using System;
using SpotifyWebHelperAPI.Models;
using SpotifyWebHelperAPI.Serialization;
using SpotifyWebHelperAPI.Web;

namespace SpotifyWebHelperAPI
{
    public class SpotifyWebHelperCommunicationService : ISpotifyWebHelperCommunicationService
    {
        #region Endpoint constants

        private const string StatusEndpoint = "remote/status.json?";
        private const string PlayEndpoint = "remote/play.json?uri={0}";
        private const string ResumeEndpoint = "remote/pause.json?pause=false";
        private const string PauseEndpoint = "remote/pause.json?pause=true";
        private const string ClientVersionEndpoint = "service/version.json?service=remote";

        #endregion

        #region Dependencies

        private readonly IRequestService _requestService;
        private readonly IDeserializer _deserializer;

        #endregion

        #region Tokens

        private readonly string _auth;
        private readonly string _cfid;

        #endregion

        public SpotifyWebHelperCommunicationService(IRequestService requestService, IDeserializer deserializer, string auth, string cfid)
        {
            if (requestService == null) throw new ArgumentNullException("requestService");
            if (deserializer == null) throw new ArgumentNullException("deserializer");
            if (auth == null) throw new ArgumentNullException("auth");
            if (cfid == null) throw new ArgumentNullException("cfid");
            _requestService = requestService;
            _deserializer = deserializer;
            _auth = auth;
            _cfid = cfid;
        }

        public StatusDto GetStatus()
        {
            return Send<StatusDto>(StatusEndpoint);
        }

        public StatusDto Play(string uri)
        {
            return Send<StatusDto>(string.Format(PlayEndpoint, uri));
        }

        public StatusDto Pause()
        {
            return Send<StatusDto>(PauseEndpoint);
        }

        public StatusDto Resume()
        {
            return Send<StatusDto>(ResumeEndpoint);
        }

        public ClientVersionDto GetClientVersion()
        {
            return Send<ClientVersionDto>(ClientVersionEndpoint);
        }

        private T Send<T>(string request)
        {
            var response = _requestService.SendRequest(request, _auth, _cfid);
            return _deserializer.DeserializeObject<T>(response);
        }
    }
}