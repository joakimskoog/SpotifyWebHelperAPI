using System.Runtime.Serialization;

namespace SpotifyWebHelperAPI.Models
{
    [DataContract(Name = "Status")]
    public class StatusDto
    {
        [DataMember(Name = "error")]
        public ErrorDto ErrorDto { get; set; }

        [DataMember(Name = "version")]
        public int Version { get; set; }

        [DataMember(Name = "client_version")]
        public string ClientVersion { get; set; }

        [DataMember(Name = "playing")]
        public bool Playing { get; set; }

        [DataMember(Name = "shuffle")]
        public bool Shuffle { get; set; }

        [DataMember(Name = "repeat")]
        public bool Repeat { get; set; }

        [DataMember(Name = "play_enabled")]
        public bool PlayEnabled { get; set; }

        [DataMember(Name = "prev_enabled")]
        public bool PrevEnabled { get; set; }

        [DataMember(Name = "track")]
        public TrackDto TrackDto { get; set; }

        [DataMember(Name = "playing_position")]
        public double PlayingPosition { get; set; }

        [DataMember(Name = "server_time")]
        public int ServerTime { get; set; }

        [DataMember(Name = "volume")]
        public double Volume { get; set; }

        [DataMember(Name = "online")]
        public bool Online { get; set; }

        [DataMember(Name = "open_graph_state")]
        public OpenGraphStateDto OpenGraphState { get; set; }

        [DataMember(Name = "running")]
        public bool Running { get; set; }
    }
}