using System.Runtime.Serialization;

namespace SpotifyWebHelperAPI.Models
{
    [DataContract(Name = "CFID")]
    public class CFIDDto
    {
        [DataMember(Name = "error")]
        public ErrorDto ErrorDto { get; set; }

        [DataMember(Name = "token")]
        public string Token { get; set; }
    }
}