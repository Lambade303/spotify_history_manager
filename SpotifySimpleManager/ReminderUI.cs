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
        public ReminderUI()
        {
            InitializeComponent();
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
    }
}
