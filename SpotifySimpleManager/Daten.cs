using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SpotifySimpleManager
{
    class Daten
    {
        private string savepath;

        public Daten()
        {
            //Standard-Savefile
            savepath = System.Environment.GetEnvironmentVariable("USERPROFILE") + "\\Documents\\SpotifyHistory\\";
            createDirectory();
        }

        public string[] GetURIsFromFile(string playlist_uri)
        {
            string latestPathName = getLatestPathName(playlist_uri);

            string[] lines;

            if (latestPathName != null)
            {
                lines = File.ReadAllLines(latestPathName);
            }
            else return null; //gibt keine Uris

            string[] uris = new string[lines.Length - 2]; // Zwei weniger wegen Header
            for (int i = 2; i < lines.Length; i++)
            {
                uris[i - 2] = lines[i];
            }

            return uris;
        }

        public Commit GetCommitAt(string PathName)
        {
            //Überprüfen ob das auch ein CommitFile ist
            //todo
            //

            string[] lines;

            if (PathName != null)
            {
                lines = File.ReadAllLines(PathName);
            }
            else return null; //gibt keine Uris

            string uri_playlist = lines[1].Substring(12); //Konstant immer auf 12
            int idx_add = Convert.ToInt32(lines[2].Substring(6)); //Konstant ab 6
            int idx_rem = Convert.ToInt32(lines[3].Substring(6));
            int idx_old = Convert.ToInt32(lines[4].Substring(6));

            //TIMESTAMP
            DateTime ts = DateTime.ParseExact(lines[0].Substring(2), "dd.MM.yyyy ~ HH:mm", new System.Globalization.CultureInfo("de-DE"));

            //ADD
            List<string> addList = new List<string>();
            int i = idx_add;
            while (lines[i] != "")
            {
                addList.Add(lines[i]);
                i++;
            }

            string[] uri_add = addList.ToArray();

            List<int> remList = new List<int>();
            //REM
            i = idx_rem;
            while (lines[i] != "")
            {
                remList.Add(Convert.ToInt32(lines[i]));
                i++;
            }

            int[] uri_rem = remList.ToArray();
            //OLD
            string[] old_uris = new string[lines.Length - idx_old];
            for (int j = 0; j < old_uris.Length; j++)
            {
                old_uris[j] = lines[j + idx_old];
            }

            Commit returns = new Commit(ts, uri_playlist, uri_add, uri_rem, old_uris);

            return returns;
        }

        public void SaveURIsToFile(string[] uris, string playlist_uri, string playlist_name)
        {
            string jetztDate = DateTime.Now.ToShortDateString();
            string jetztZeit = DateTime.Now.ToString("hh_mm");
            string filename = jetztDate + "_" + jetztZeit + ".shm";

            StreamWriter w = File.CreateText(savepath + filename);

            string header = "# " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();
            string playlistinfo = "# " + playlist_uri;

            w.WriteLine(header);
            w.WriteLine(playlistinfo);

            for (int i = 0; i < uris.Length; i++)
            {
                w.Write(uris[i]);
                if (i != uris.Length - 1)
                {
                    w.Write("\n"); //Immer außer letzte
                }
            }

            w.Close();
        }

        public void PerformCommit(Commit c)
        {
            //Speichervorgang Commit
            string jetztDate = DateTime.Now.ToShortDateString();
            string jetztZeit = DateTime.Now.ToString("hh_mm");
            string filename = "c_" + jetztDate + "_" + jetztZeit + ".shm";

            StreamWriter w = File.CreateText(savepath + filename);
            string paket = c.GetKomplettpaket();
            w.Write(paket);
            w.Close();
        }

        private string getLatestPathName(string playlist_uri)
        {
            string[] files = Directory.GetFileSystemEntries(savepath);
            string[] files_names = new string[files.Length];
            string latest_file = null;

            for (int i = 0; i < files.Length; i++)
            {
                files_names[i] = files[i].Substring(savepath.Length);
            }

            if (files.Length > 0)
            {
                int latestIndex = -1;
                DateTime max = DateTime.MinValue;
                for (int i = 0; i < files.Length; i++)
                {
                    DateTime compare = File.GetLastAccessTime(files[i]);

                    if (compare > max && files_names[i].EndsWith(".shm") && !files_names[i].StartsWith("c_")) // Compare ist neuer als Max und die Datei ist in der Form "![c_] *.shm"
                    {
                        max = compare;
                        latestIndex = i;
                    }
                }
                latest_file = files[latestIndex];
            }

            if (!String.IsNullOrEmpty(latest_file))
            {
                StreamReader r = new StreamReader(latest_file);
                r.ReadLine(); //Zeitstempel
                string uri_zeile = r.ReadLine();
                string uri = uri_zeile.Substring(2);

                if (uri == playlist_uri)
                {
                    return latest_file;
                }
            }
            return null;
        }

        private void createDirectory()
        {
            //Nächstes Savefile parsen
            bool dirExist = Directory.Exists(savepath);
            if (!dirExist)
            {
                Directory.CreateDirectory(savepath);
            }
        }
    }
}
