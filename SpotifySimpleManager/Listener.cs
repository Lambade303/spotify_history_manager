using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace SpotifySimpleManager
{
    class Listener
    {
        public event EventHandler OnFullHour;

        Timer derTimer;

        int lastHour;

        public Listener()
        {
            lastHour = DateTime.Now.Hour;

            derTimer = new Timer(5000); //Jede 5 Sekunden
            derTimer.Elapsed += DerTimer_Elapsed;
        }

        public void Start() => derTimer.Start();

        public void Stop() => derTimer.Stop();

        public bool GetEnabled() => derTimer.Enabled;

        private void DerTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            int newHour = DateTime.Now.Hour;
            if (lastHour < newHour || (lastHour == 23 && newHour == 0)) //Jede volle Stunde
            {
                lastHour = DateTime.Now.Hour; //letzte Stunde updaten
                OnFullHour?.Invoke(this, new EventArgs()); //Event auslösen bei neuer Stunde
            }
        }
    }
}
