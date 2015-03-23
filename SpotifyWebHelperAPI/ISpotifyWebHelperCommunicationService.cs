using SpotifyWebHelperAPI.Models;

namespace SpotifyWebHelperAPI
{
    /// <summary>
    /// Interface for communicating with the SpotifyWebHelper process that runs locally on user's computers.
    /// </summary>
    public interface ISpotifyWebHelperCommunicationService
    {
        /// <summary>
        /// Retrieve the curren status.
        /// </summary>
        /// <returns>The current status.</returns>
        StatusDto GetStatus();

        /// <summary>
        /// Plays the given URI and returns the updated status.
        /// </summary>
        /// <param name="uri">The uri that should be played.</param>
        /// <returns>The newly updated status.</returns>
        StatusDto Play(string uri);

        /// <summary>
        /// Pauses the current song and returns the updated status.
        /// </summary>
        /// <returns>The newly updated status.</returns>
        StatusDto Pause();

        /// <summary>
        /// Resumes the currently paused song and returns the updated status.
        /// </summary>
        /// <returns>The newly updated status.</returns>
        StatusDto Resume();

        /// <summary>
        /// Retrieves the client version information.
        /// </summary>
        /// <returns>The client version information.</returns>
        ClientVersionDto GetClientVersion();
    }
}