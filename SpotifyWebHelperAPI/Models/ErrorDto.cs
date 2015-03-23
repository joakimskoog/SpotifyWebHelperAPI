using System.Runtime.Serialization;

namespace SpotifyWebHelperAPI.Models
{
    [DataContract(Name = "error")]
    public class ErrorDto
    {
        [DataMember(Name = "type")]
        public string Type { get; set; }

        [DataMember(Name = "message")]
        public string Message { get; set; }
    }
}