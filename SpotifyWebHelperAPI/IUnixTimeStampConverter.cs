using System;

namespace SpotifyWebHelperAPI
{
    /// <summary>
    /// Interface for converting from a date to a unix time stamp.
    /// </summary>
    public interface IUnixTimeStampConverter
    {
        int ConvertToTimeStamp(DateTime date);
    }
}