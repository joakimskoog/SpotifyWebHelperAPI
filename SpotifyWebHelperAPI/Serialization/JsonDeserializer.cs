using Newtonsoft.Json;

namespace SpotifyWebHelperAPI.Serialization
{
    public class JsonDeserializer : IDeserializer
    {
        public T DeserializeObject<T>(string value)
        {
            return JsonConvert.DeserializeObject<T>(value);
        }
    }
}