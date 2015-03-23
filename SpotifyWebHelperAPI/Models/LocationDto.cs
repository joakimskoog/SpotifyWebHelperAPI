using System.Runtime.Serialization;

namespace SpotifyWebHelperAPI.Models
{
    [DataContract(Name = "location")]
    public class LocationDto
    {
        [DataMember(Name = "og")]
        public string Og { get; set; }
    }
}