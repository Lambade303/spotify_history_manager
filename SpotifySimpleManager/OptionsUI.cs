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

        bool isReadOnly;
        bool textChanged;

        public OptionsUI()
        {
            InitializeComponent();
            textChanged = false;
        }

        public new DialogResult ShowDialog()
        {
            setReadOnlyProperties(true);

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
            DialogResult d = fileDialog_confjson.ShowDialog();
            if (d == DialogResult.OK)
            {
                try
                {
                    string filepath = fileDialog_confjson.FileName;
                    string commitspeicher = tB_speicherort.Text;
                    ConfigJson attempt = ConfigJson.DeserializeFile(filepath);
                    Options o = new Options(attempt, filepath, commitspeicher);
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

        private void changeCommitDir()
        {
            DialogResult d = fileDialog_commitspeicher.ShowDialog();
            if (d == DialogResult.OK)
            {
                string filepath = tB_configfile.Text;
                string commitspeicher = fileDialog_commitspeicher.SelectedPath;
                bool dirIsValid = System.IO.Directory.Exists(commitspeicher);

                if (dirIsValid)
                {
                    ConfigJson attempt = ConfigJson.DeserializeFile(filepath);
                    Options o = new Options(attempt, filepath, commitspeicher);
                    LoadOptions(o);
                    b_save.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Fehlerhaftes Verzeichnis ausgewählt.");
                }
            }
        }

        private void reloadOptionsData()
        {
            tB_speicherort.Text = _opt.Commitspeicherort;
            tB_confjson_clientid.Text = _opt.ClientId;
            tB_confjson_clientsecret.Text = _opt.ClientSecret;
            tB_confjson_playlistid.Text = _opt.Playlist;
            tB_confjson_username.Text = _opt.Username;
            tB_configfile.Text = _opt.Origin;
        }

        private void setReadOnlyProperties(bool readOnly)
        {
            isReadOnly = readOnly;

            tB_speicherort.ReadOnly = readOnly;
            tB_configfile.ReadOnly = readOnly;
            tB_confjson_clientid.ReadOnly = readOnly;
            tB_confjson_clientsecret.ReadOnly = readOnly;
            tB_confjson_playlistid.ReadOnly = readOnly;
            tB_confjson_username.ReadOnly = readOnly;

            b_commitspeicher_change.Enabled = !readOnly;
            b_configfile_change.Enabled = !readOnly;

            textChanged = readOnly ? textChanged : false;
        }



        private void b_configfile_change_Click(object sender, EventArgs e)
        {
            changeConfigFile();
        }


        private void b_save_Click(object sender, EventArgs e)
        {
            if (!isReadOnly)
            {
                if (textChanged)
                {
                    DialogResult = DialogResult.Yes;
                }
                else
                {
                    DialogResult = DialogResult.No;
                }
            }

            Close();
        }

        private void b_unlock_Click(object sender, EventArgs e)
        {
            setReadOnlyProperties(false);
            b_unlock.Enabled = false;
        }

        private void b_commitspeicher_change_Click(object sender, EventArgs e)
        {
            changeCommitDir();
        }

        private void lbl_TextChanged(object sender, EventArgs e)
        {
            textChanged = true;
        }
    }
}
