using System.Runtime.Serialization;

namespace SpotifyWebHelperAPI.Models
{
    [DataContract(Name = "resource")]
    public class ResourceDto
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "uri")]
        public string Uri { get; set; }

        [DataMember(Name = "location")]
        public LocationDto Location { get; set; }
    }
}