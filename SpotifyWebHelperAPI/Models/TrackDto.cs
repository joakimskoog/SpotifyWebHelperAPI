using System.Runtime.Serialization;

namespace SpotifyWebHelperAPI.Models
{
    [DataContract(Name = "track")]
    public class TrackDto
    {
        [DataMember(Name = "track_resource")]
        public ResourceDto TrackResource { get; set; }

        [DataMember(Name = "artist_resource")]
        public ResourceDto ArtistResource { get; set; }

        [DataMember(Name = "album_resource")]
        public ResourceDto AlbumResource { get; set; }

        [DataMember(Name = "length")]
        public int Length { get; set; }

        [DataMember(Name = "track_type")]
        public string TrackType { get; set; }
    }
}