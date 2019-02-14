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
        }

        public string[] GetURIsFromFile()
        {
            createDirectory();

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

        public void SaveURIsToFile(string[] uris)
        {
            createDirectory();

            string jetztDate = DateTime.Now.ToShortDateString();
            string jetztZeit = DateTime.Now.ToString("hh_mm");
            string filename = jetztDate + "_" + jetztZeit;

            StreamWriter w = File.CreateText(savepath + filename); //pot. IOError (verbotene Zeichen)

            w.WriteLine("# " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString()); //Header
            w.WriteLine(); //Header Ende

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

        private string getLatestPathName()
        {
            createDirectory();

            string[] files = Directory.GetFiles(savepath);
            if (files.Length > 0)
            {
                int latestIndex = -1;
                DateTime max = DateTime.MinValue;
                for (int i = 0; i < files.Length; i++)
                {
                    DateTime compare = File.GetLastAccessTime(files[i]);

                    if (compare > max)
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
