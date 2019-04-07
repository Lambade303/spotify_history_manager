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
    public partial class OptionsUI : Form
    {
        Options _opt;

        public OptionsUI()
        {
            InitializeComponent();
        }

        private void b_configfile_change_Click(object sender, EventArgs e)
        {
            changeConfigFile();
        }

        private void b_save_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        public new DialogResult ShowDialog()
        {
            DialogResult = DialogResult.Cancel;
            return base.ShowDialog();
        }

        public Options GetOptionsData()
        {
            _opt.Username = tB_confjson_username.Text;
            _opt.ClientId = tB_confjson_clientid.Text;
            _opt.ClientSecret = tB_confjson_clientsecret.Text;
            _opt.Playlist = tB_confjson_playlistid.Text;
            _opt.Origin = tB_configfile.Text;

            return _opt;
        }

        public void LoadOptions(Options load)
        {
            _opt = load;
            reloadOptionsData();
        }

        private void changeConfigFile()
        {
            DialogResult d = fileDialog.ShowDialog();
            if (d == DialogResult.OK)
            {
                try
                {
                    string filepath = fileDialog.FileName;
                    ConfigJson attempt = ConfigJson.DeserializeFile(filepath);
                    Options o = new Options(attempt, filepath);
                    LoadOptions(o);
                    b_save.Enabled = true;
                }
                catch
                {
                    MessageBox.Show("No valid .json selected. Please make sure your .json covers the following variables:\n" +
                        "Username, ClientId, ClientSecret, Playlist");
                    b_save.Enabled = false;
                }
            }
        }

        private void reloadOptionsData()
        {
            tB_confjson_clientid.Text = _opt.ClientId;
            tB_confjson_clientsecret.Text = _opt.ClientSecret;
            tB_confjson_playlistid.Text = _opt.Playlist;
            tB_confjson_username.Text = _opt.Username;
            tB_configfile.Text = _opt.Origin;
        }
    }
}
