using SpotifyWebHelperAPI.Models;

namespace SpotifyWebHelperAPI
{
    public interface IAuthProvider
    {
        string GetAuth();

        CFIDDto GetCFID();
    }
}