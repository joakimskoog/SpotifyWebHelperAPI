namespace SpotifyWebHelperAPI.Serialization
{
    public interface IDeserializer
    {
        T DeserializeObject<T>(string value);
    }
}