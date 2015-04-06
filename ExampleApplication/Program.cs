using System;
using System.Threading;
using SpotifyWebHelperAPI;

namespace ExampleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Creating the communication service...");
            var communicationService = SpotifyWebHelperApi.Create();
            Sleep();

            Console.WriteLine("Retrieving client data...");
            var clientVersion = communicationService.GetClientVersion();
            Sleep();
            Console.WriteLine("Which version of Spotify are we using? {0}", clientVersion.ClientVersion);
            Sleep();

            Console.WriteLine("Retrieving the current status...");
            var status = communicationService.GetStatus();
            Sleep();

            Console.WriteLine("Are we currently playing a song? {0}", status.Playing ? "Yes" : "No");
            Sleep();

            if (status.Playing)
            {
                Console.WriteLine("Which song are we playing? {0} by {1}", status.Track.TrackResource.Name, status.Track.ArtistResource.Name);
                Sleep();

                Console.WriteLine("Meh, this song isn't that great. Let's pause it!");
                var pausedStatus = communicationService.Pause();
                Sleep();
                Console.WriteLine("Are we paused? {0}", !pausedStatus.Playing ? "Yes" : "No");
                Sleep();
            }
 
            Console.WriteLine("Let's start a new song. Hmm...everybody loves the movie Frozen, right?");
            Sleep();
            var playedStatus = communicationService.Play("spotify:track:600HVBpzF1WfBdaRwbEvLz");
            Console.WriteLine("That's more like it!");
            Sleep();
            Console.WriteLine("Currently playing the song {0} by {1}", playedStatus.Track.TrackResource.Name, playedStatus.Track.ArtistResource.Name);

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }

        private static void Sleep()
        {
            Thread.Sleep(2000);
        }
    }
}