using System;
using Newtonsoft.Json;
using SpotifyWebHelperAPI.Models;
using SpotifyWebHelperAPI.Web;

namespace SpotifyWebHelperAPI
{
    public class SpotifyWebHelperCommunicationService : ISpotifyWebHelperCommunicationService
    {
        private const string Host = "127.0.0.1";
        private const int Port = 4380;

        #region Endpoint constants

        private const string StatusEndpoint = "remote/status.json?";
        private const string PlayEndpoint = "remote/play.json?uri={0}";
        private const string ResumeEndpoint = "remote/pause.json?pause=false";
        private const string PauseEndpoint = "remote/pause.json?pause=true";
        private const string ClientVersionEndpoint = "service/version.json?service=remote";

        #endregion

        #region Dependencies

        private readonly IWebClient _webClient;
        private readonly IUnixTimeStampConverter _timeStampConverter;
        private readonly IAuthProvider _authProvider;
        private readonly ICFIDProvider _cfidProvider;

        #endregion

        public SpotifyWebHelperCommunicationService(IWebClient webClient, IUnixTimeStampConverter timeStampConverter, IAuthProvider authProvider, ICFIDProvider cfidProvider)
        {
            if (webClient == null) throw new ArgumentNullException("webClient");
            if (timeStampConverter == null) throw new ArgumentNullException("timeStampConverter");
            if (authProvider == null) throw new ArgumentNullException("authProvider");
            if (cfidProvider == null) throw new ArgumentNullException("cfidProvider");
            _webClient = webClient;
            _timeStampConverter = timeStampConverter;
            _authProvider = authProvider;
            _cfidProvider = cfidProvider;
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
            var auth = _authProvider.GetAuth();
            var cfid = _cfidProvider.GetCFID();
            var unixTimeStamp = _timeStampConverter.ConvertToTimeStamp(DateTime.UtcNow);
            var address = string.Format("http://{0}:{1}/{2}&ref=&cors=&_={3}&oauth={4}&csrf={5}", Host, Port, request, unixTimeStamp, auth, cfid);

            var response = _webClient.DownloadString(address);

            return JsonConvert.DeserializeObject<T>(response);
        }
    }
}