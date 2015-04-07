using System;

namespace SpotifyWebHelperAPI
{
    /// <summary>
    /// Interface for converting from a date to an unix time stamp.
    /// An unix time stamp is the number of seconds between a given date and the Unix Epoch (1970-01-01 UTC).
    /// </summary>
    public interface IUnixTimeStampConverter
    {
        /// <summary>
        /// Converts a DateTime into an unix time stamp.
        /// </summary>
        /// <param name="date">The DateTime that should be converted into an unix time stamp.</param>
        /// <returns>The number of seconds between the given date and the Unix Epoch.</returns>
        int ConvertToTimeStamp(DateTime date);
    }
}