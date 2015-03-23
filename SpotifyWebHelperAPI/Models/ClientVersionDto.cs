using System.Runtime.Serialization;

namespace SpotifyWebHelperAPI.Models
{
    [DataContract(Name = "ClientVersion")]
    public class ClientVersionDto
    {
        [DataMember(Name = "error")]
        public ErrorDto Error { get; set; }

        [DataMember(Name = "version")]
        public int Version { get; set; }

        [DataMember(Name = "client_version")]
        public string ClientVersion { get; set; }

        [DataMember(Name = "running")]
        public bool Running { get; set; }
    }
}