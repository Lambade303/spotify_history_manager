using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpotifySimpleManager
{
    public partial class ReminderUI : Form
    {
        GUI dieGUI;

        public ReminderUI(GUI pGUI)
        {
            InitializeComponent();

            //Assoziieren
            dieGUI = pGUI;

            //Position setzen
            Rectangle workArea = Screen.GetWorkingArea(this);
            Location = new Point()
            {
                X = workArea.Right - this.Size.Width - 20,
                Y = workArea.Bottom - Size.Height - 10,
            };
        }

        public async void Show(string Message, bool FadeIn, int Lifetime)
        {
            //KommHerein
            if (FadeIn)
            {
                lbl_message.Text = Message;
                fadeIn(60);
            }
            else
            {
                lbl_message.Text = Message;
                Opacity = 1;
                Show();
            }
            //Warte Lifetime Millisekunden
            await Task.Delay(Lifetime);

            //GehHeraus
            if (FadeIn)
            {
                fadeOut(60);
            }
            else
            {
                Hide();
            }
        }

        private async void fadeIn(int interval)
        {
            Opacity = 0;
            Show();

            while (Opacity <= 0.85)
            {
                await Task.Delay(interval);
                Opacity += 0.05;
            }
        }

        private async void fadeOut(int interval)
        {
            while (Opacity > 0)
            {
                await Task.Delay(interval);
                Opacity -= 0.05;
            }
            Hide();
        }

        private void Reminder_Load(object sender, EventArgs e)
        {
            Hide();
        }

        private void irgendwas_click(object sender, EventArgs e)
        {
            dieGUI.ReminderUI_Clicked();
        }
    }
}
