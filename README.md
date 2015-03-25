# SpotifyWebHelperAPI
SpotifyWebHelperAPI is a small and lightweight .NET library for communicating with SpotifyWebHelper. SpotifyWebHelper is a process
that runs locally on user's machines and is used for various things such as the embedded play buttons and players on websites.

## Features
* Play a track by providing a Spotify URI
* Pause the currently playing track
* Resume the currently paused track
* Retrieve detailed information about the current track
* Retrieve information about the Spotify client

## Usage
There are a few different ways you can start using the communication service. The first one is the easy way where you use the default dependencies. This is shown below.
```C# 
  var communicationService = SpotifyWebHelperApi.Create();
  var status = communicationService.GetStatus();

  //Do stuff with the status

  //Pause the currently playing song
  var newStatus = communicationService.Pause(); 
```

There is also a way to create SpotifyCommunicationService by supplying your own dependencies to it. The constructor is shown below.

```C#
public SpotifyWebHelperCommunicationService(IWebClient webClient, IUnixTimeStampConverter timeStampConverter, IAuthProvider authProvider, IDeserializer deserializer)
```

## Contributing
Do you have a new feature? Maybe an API method that is not currently implemented? Here's what to do (in the following order)
* Fork the repository
* Fix the bug/Implement the feature
* Submit a pull request

## Bugs and Feedback
For bugs, questions and discussions please use the [Github Issues](https://github.com/joakimskoog/SpotifyWebHelperAPI/issues)

## License
The MIT License (MIT)

Copyright (c) 2015 Joakim Skoog

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
