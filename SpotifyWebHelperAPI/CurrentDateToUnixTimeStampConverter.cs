using System;

namespace SpotifyWebHelperAPI
{
    public class UnixTimeStampConverter : IUnixTimeStampConverter
    {
        public int ConvertToTimeStamp(DateTime date)
        {
            return Convert.ToInt32((date - new DateTime(1970, 1, 1, 0, 0, 0)).TotalSeconds);
        }
    }
}