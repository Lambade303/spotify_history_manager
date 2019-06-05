# spotify_history_manager
An application inspired by git, where I press a button to create a new "commit", that saves added or removed songs from my public playlist since the last "commit". A friend of mine wanted me to do this and I think i am up to the challenge.

The application has a Listener that periodically checks for changes and creates a toast message at the bottom right corner of the screen if there are any and suggests a new commit.

Options-Tab is not working lmao.

You require a Spotify-Api ID and Secret, that you may get here: https://developer.spotify.com/dashboard
Just paste it into the id and secret fields of the conf.json.

Additionally you will require the Spotify-Internal URI of your Playlist of choice (without the spotify:playlist:) and paste it into the playlist-field of the conf.json.

Used Libraries:

<a href="https://github.com/JohnnyCrazy/SpotifyAPI-NET">SpotifyAPI-NET</a><br/>
<a href="https://github.com/JamesNK/Newtonsoft.Json">Newtonsoft-JSON</a>
