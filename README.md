# spotify_history_manager
An application inspired by git, where I press a button to create a new "commit", that saves added or removed songs from my public playlist since the last "commit". A friend of mine wanted me to do this and I think i am up to the challenge.

Notiz für Freigabe:
  Die Spotify API benötigt eine Authentifizierung per Client-Secret (siehe Steuerung.InitializeAPIAsync() bei auth)
  Da dies irgendwas persönliches bei Spotify ist bitte ich um keine Verbreitung dieses Schlüssels. Vielleicht gibts bald eine Alternative, bis dahin ist der Key tabu.

Used Libraries:

<a href="https://github.com/JohnnyCrazy/SpotifyAPI-NET">SpotifyAPI-NET</a>
<a href="https://github.com/JamesNK/Newtonsoft.Json">Newtonsoft-JSON</a>
