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

        public string[] GetURIsFromFile()
        {
            string latestPathName = getLatestPathName();

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

        public void SaveURIsToFile(string[] uris, string playlist_uri, string playlist_name)
        {
            string jetztDate = DateTime.Now.ToShortDateString();
            string jetztZeit = DateTime.Now.ToString("hh_mm");
            string filename = jetztDate + "_" + jetztZeit + ".shm";

            StreamWriter w = File.CreateText(savepath + filename);

            string header = "# " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();
            string playlistinfo = "# " + playlist_uri + " (" + playlist_name + ")";

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

        private string getLatestPathName()
        {
            string[] files = Directory.GetFileSystemEntries(savepath);
            string[] files_names = new string[files.Length];

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
                return files[latestIndex];
            }
            else return null;
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
