using System.Runtime.Serialization;

namespace SpotifyWebHelperAPI.Models
{
    [DataContract(Name = "open_graph_state")]
    public class OpenGraphStateDto
    {
        [DataMember(Name = "private_session")]
        public bool PrivateSession { get; set; }

        [DataMember(Name = "posting_disabled")]
        public bool PostingDisabled { get; set; }
    }
}