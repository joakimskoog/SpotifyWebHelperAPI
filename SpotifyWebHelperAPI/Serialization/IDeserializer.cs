namespace SpotifyWebHelperAPI.Serialization
{
    /// <summary>
    /// Responsible for deserializing strings into objects.
    /// </summary>
    public interface IDeserializer
    {
        /// <summary>
        /// Deserialize the given string into the given object type.
        /// </summary>
        /// <typeparam name="T">The type that the string should be deserialized into.</typeparam>
        /// <param name="value">The string that should be deserialized.</param>
        /// <returns>The deserialized object.</returns>
        T DeserializeObject<T>(string value);
    }
}