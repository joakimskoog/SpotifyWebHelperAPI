namespace SpotifyWebHelperAPI.Web
{
    public interface IRequestService
    {
        /// <summary>
        /// Sends a simple request as is.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        string SendSimpleRequest(string request);

        /// <summary>
        /// Sends a request by adding a bunch of parameters to the given request.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="auth"></param>
        /// <param name="cfid"></param>
        /// <returns></returns>
        string SendRequest(string request, string auth = "", string cfid = "");
    }
}