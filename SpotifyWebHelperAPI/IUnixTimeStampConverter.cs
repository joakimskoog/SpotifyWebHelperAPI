using System;

namespace SpotifyWebHelperAPI
{
    /// <summary>
    /// Interface for converting from a date to a unix time stamp.
    /// A unix time stamp is the number of seconds between a given date and the Unix Epoch (1970-01-01 UTC).
    /// </summary>
    public interface IUnixTimeStampConverter
    {
        /// <summary>
        /// Converts a DateTime into a unix time stamp.
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        int ConvertToTimeStamp(DateTime date);
    }
}