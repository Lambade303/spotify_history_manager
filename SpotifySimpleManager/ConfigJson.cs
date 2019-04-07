using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace SpotifySimpleManager
{
    public class ConfigJson
    {
        public string Username { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string Playlist { get; set; }

        public static ConfigJson DeserializeFile(string path)
        {
            return JsonConvert.DeserializeObject<ConfigJson>(File.ReadAllText(path));
        }
    }
}
