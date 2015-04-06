using System;
using System.Net;

namespace SpotifyWebHelperAPI.Web
{
    public class RequestService : IRequestService
    {
        private const string RequestWithAuths = "http://{0}:{1}/{2}&ref=&cors=&_={3}&oauth={4}&csrf={5}";
        private const string RequestWithoutAuths = "http://{0}:{1}/{2}&ref=&cors=&_={3}";

        private readonly WebHeaderCollection _headers;
        private readonly string _host;
        private readonly int _port;
        private readonly IUnixTimeStampConverter _timeStampConverter;

        public RequestService(WebHeaderCollection headers, string host, int port, IUnixTimeStampConverter timeStampConverter)
        {
            if (headers == null) throw new ArgumentNullException("headers");
            if (host == null) throw new ArgumentNullException("host");
            if (timeStampConverter == null) throw new ArgumentNullException("timeStampConverter");
            _headers = headers;
            _host = host;
            _port = port;
            _timeStampConverter = timeStampConverter;
        }

        public string SendSimpleRequest(string request)
        {
           return GetResponse(request);
        }

        public string SendRequest(string request, string auth = "", string cfid = "")
        {
            var unixTimeStamp = _timeStampConverter.ConvertToTimeStamp(DateTime.UtcNow);

            var builtRequest = string.IsNullOrEmpty(auth) && string.IsNullOrEmpty(cfid)
                ? BuildRequestWithoutAuths(request, unixTimeStamp)
                : BuildRequestWithAuth(request, auth, cfid, unixTimeStamp);

            var response = GetResponse(builtRequest);

            return response;
        }

        private string BuildRequestWithAuth(string request, string auth, string cfid, int unixTimeStamp)
        {
            return string.Format(RequestWithAuths, _host, _port, request, unixTimeStamp, auth, cfid);
        }

        private string BuildRequestWithoutAuths(string request, int unixTimeStamp)
        {
            return string.Format(RequestWithoutAuths, _host, _port, request, unixTimeStamp);
        }

        private string GetResponse(string request)
        {
            using (var client = new WebClient { Headers = _headers })
            {
                return client.DownloadString(request);
            }
        }
    }
}