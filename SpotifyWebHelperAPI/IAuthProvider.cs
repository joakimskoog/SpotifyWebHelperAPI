namespace SpotifyWebHelperAPI
{
    public interface IAuthProvider
    {
        string GetAuth();

        string GetCFID();
    }
}