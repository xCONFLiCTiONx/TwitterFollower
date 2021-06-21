using System;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TwitterFollower
{
    public partial class Form1 : Form
    {
        private string _API_KEY = Properties.Settings.Default.API_KEY;
        private string _ACCESS_TOKEN = Properties.Settings.Default.ACCESS_TOKEN;
        private string _API_SECRET_KEY = Properties.Settings.Default.API_SECRET_KEY;
        private string _ACCESS_TOKEN_SECRET = Properties.Settings.Default.ACCESS_TOKEN_SECRET;
        private string _BEARER_TOKEN = Properties.Settings.Default.BEARER_TOKEN;
        private string _SCREEN_NAME = Properties.Settings.Default.SCREEN_NAME;
        Thread thread;

        public Form1()
        {
            if (Properties.Settings.Default.UpgradeRequired)
            {
                Properties.Settings.Default.Upgrade();
                Properties.Settings.Default.Reload();
            }

            EasyLogger.BackupLogs(EasyLogger.LogFile, 7);
            EasyLogger.AddListener(EasyLogger.LogFile);

            InitializeComponent();

            Properties.Settings.Default.Channel = AppDomain.CurrentDomain.BaseDirectory;
            Text += " - Directory Name: " + Properties.Settings.Default.Channel;
            Properties.Settings.Default.Save();

            API_KEY_BOX.Text = _API_KEY;
            ACCESS_TOKEN_BOX.Text = _ACCESS_TOKEN;
            API_SECRET_KEY_BOX.Text = _API_SECRET_KEY;
            ACCESS_TOKEN_SECRET_BOX.Text = _ACCESS_TOKEN_SECRET;
            BEARER_TOKEN_BOX.Text = _BEARER_TOKEN;
            SCREEN_NAME_BOX.Text = _SCREEN_NAME;

            FormClosing += Form1_FormClosing;
            VERSION_LABEL.Text = "Version: " + Assembly.GetEntryAssembly().GetName().Version;

            _ = BackupAsync();

            Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            API_KEY_BOX.TextChanged += API_KEY_BOX_TextChanged;
            ACCESS_TOKEN_BOX.TextChanged += ACCESS_TOKEN_BOX_TextChanged;
            API_SECRET_KEY_BOX.TextChanged += API_SECRET_KEY_BOX_TextChanged;
            ACCESS_TOKEN_SECRET_BOX.TextChanged += ACCESS_TOKEN_SECRET_BOX_TextChanged;
            BEARER_TOKEN_BOX.TextChanged += BEARER_TOKEN_BOX_TextChanged;
            SCREEN_NAME_BOX.TextChanged += SCREEN_NAME_BOX_TextChanged;
        }

        private void SaveSettings(bool wait)
        {
            if (wait)
            {
                Thread.Sleep(1000);
            }

            Properties.Settings.Default.API_KEY = API_KEY_BOX.Text;
            Properties.Settings.Default.ACCESS_TOKEN = ACCESS_TOKEN_BOX.Text;
            Properties.Settings.Default.API_SECRET_KEY = API_SECRET_KEY_BOX.Text;
            Properties.Settings.Default.ACCESS_TOKEN_SECRET = ACCESS_TOKEN_SECRET_BOX.Text;
            Properties.Settings.Default.BEARER_TOKEN = BEARER_TOKEN_BOX.Text;
            Properties.Settings.Default.SCREEN_NAME = SCREEN_NAME_BOX.Text;
            Properties.Settings.Default.Save();
            Properties.Settings.Default.Reload();

            _API_KEY = Properties.Settings.Default.API_KEY;
            _ACCESS_TOKEN = Properties.Settings.Default.ACCESS_TOKEN;
            _API_SECRET_KEY = Properties.Settings.Default.API_SECRET_KEY;
            _ACCESS_TOKEN_SECRET = Properties.Settings.Default.ACCESS_TOKEN_SECRET;
            _BEARER_TOKEN = Properties.Settings.Default.BEARER_TOKEN;
            _SCREEN_NAME = Properties.Settings.Default.SCREEN_NAME;
        }

        private void SCREEN_NAME_BOX_TextChanged(object sender, EventArgs e)
        {
            if (thread != null)
            {
                if (!thread.IsAlive)
                {
                    thread = new Thread(() => SaveSettings(true))
                    {
                        IsBackground = true
                    };
                    thread.Start();
                }
            }
            else
            {
                thread = new Thread(() => SaveSettings(true))
                {
                    IsBackground = true
                };
                thread.Start();
            }
        }

        private void BEARER_TOKEN_BOX_TextChanged(object sender, EventArgs e)
        {
            if (thread != null)
            {
                if (!thread.IsAlive)
                {
                    thread = new Thread(() => SaveSettings(true))
                    {
                        IsBackground = true
                    };
                    thread.Start();
                }
            }
            else
            {
                thread = new Thread(() => SaveSettings(true))
                {
                    IsBackground = true
                };
                thread.Start();
            }
        }

        private void ACCESS_TOKEN_SECRET_BOX_TextChanged(object sender, EventArgs e)
        {
            if (thread != null)
            {
                if (!thread.IsAlive)
                {
                    thread = new Thread(() => SaveSettings(true))
                    {
                        IsBackground = true
                    };
                    thread.Start();
                }
            }
            else
            {
                thread = new Thread(() => SaveSettings(true))
                {
                    IsBackground = true
                };
                thread.Start();
            }
        }

        private void API_SECRET_KEY_BOX_TextChanged(object sender, EventArgs e)
        {
            if (thread != null)
            {
                if (!thread.IsAlive)
                {
                    thread = new Thread(() => SaveSettings(true))
                    {
                        IsBackground = true
                    };
                    thread.Start();
                }
            }
            else
            {
                thread = new Thread(() => SaveSettings(true))
                {
                    IsBackground = true
                };
                thread.Start();
            }
        }

        private void ACCESS_TOKEN_BOX_TextChanged(object sender, EventArgs e)
        {
            if (thread != null)
            {
                if (!thread.IsAlive)
                {
                    thread = new Thread(() => SaveSettings(true))
                    {
                        IsBackground = true
                    };
                    thread.Start();
                }
            }
            else
            {
                thread = new Thread(() => SaveSettings(true))
                {
                    IsBackground = true
                };
                thread.Start();
            }
        }

        private void API_KEY_BOX_TextChanged(object sender, EventArgs e)
        {
            if (thread != null)
            {
                if (!thread.IsAlive)
                {
                    thread = new Thread(() => SaveSettings(true))
                    {
                        IsBackground = true
                    };
                    thread.Start();
                }
            }
            else
            {
                thread = new Thread(() => SaveSettings(true))
                {
                    IsBackground = true
                };
                thread.Start();
            }
        }

        private async Task BackupAsync()
        {
            GoButton.Enabled = false;
            progressBar1.Style = ProgressBarStyle.Marquee;
            progressBar1.MarqueeAnimationSpeed = 100;

            await Task.Run(BackupDatabase.ExecuteBackup);

            progressBar1.MarqueeAnimationSpeed = 0;
            progressBar1.Style = ProgressBarStyle.Blocks;
            progressBar1.Value = progressBar1.Minimum;
            GoButton.Enabled = true;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveSettings(false);
        }

        private void GoButton_Click(object sender, System.EventArgs e)
        {
            Start();
        }

        private async void Start()
        {
            GoButton.Enabled = false;
            progressBar1.Style = ProgressBarStyle.Marquee;
            progressBar1.MarqueeAnimationSpeed = 100;

            string success = await FollowAsync();

            progressBar1.MarqueeAnimationSpeed = 0;
            progressBar1.Style = ProgressBarStyle.Blocks;
            progressBar1.Value = progressBar1.Minimum;
            GoButton.Enabled = true;

            if (success != "OK")
            {
                MessageBox.Show("Task completed...", "TwitterFollower", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private async Task<string> FollowAsync()
        {
            string response = null;

            Follow twitter = new Follow(_API_KEY, _ACCESS_TOKEN, _API_SECRET_KEY, _ACCESS_TOKEN_SECRET, _BEARER_TOKEN);
            response = await Task.Run(() => twitter.FollowAsync(_SCREEN_NAME));

            if (response != "OK")
            {
                EasyLogger.Warning(response);

                MessageBox.Show(response, "Social Post Scheduler", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                EasyLogger.Info("Requested message posted successfully!");
            }

            return "OK";
        }
    }
}
