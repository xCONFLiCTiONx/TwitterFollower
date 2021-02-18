using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace TwitterFollower
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            int tries = 60;
        TryAgain:;
            try
            {
                if (!SQLConnection.IsServerConnected(Properties.Settings.Default.FollowersConnectionString))
                {
                    tries--;
                    if (tries > 0)
                    {
                        EasyLogger.Warning("SQL Server is not responding. I'll try again " + tries + " more times until I require user input...");
                        Thread.Sleep(2000);
                        goto TryAgain;
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("SQL Server is not responding. Would you like to try again?", "Social Post Scheduler", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            goto TryAgain;
                        }
                        else
                        {
                            Environment.Exit(0);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                EasyLogger.Error(ex);
            }

            try
            {
                System.Reflection.Assembly assembly = typeof(Program).Assembly;
                GuidAttribute attribute = (GuidAttribute)assembly.GetCustomAttributes(typeof(GuidAttribute), true)[0];
                string id = attribute.Value;

                StartApp();
            }
            catch (Exception ex)
            {
                EasyLogger.Error("Program - @Main(1): " + ex);
                MessageBox.Show(ex.Message, "TwitterFollower", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static void StartApp()
        {
            AppDomain.CurrentDomain.UnhandledException += AppDomain_UnhandledException;
            Application.ThreadException += Application_ThreadException;
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);


            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
            }
            catch (Exception ex)
            {
                EasyLogger.Error("Program - @StartApp(2): " + ex);
                MessageBox.Show(ex.Message, "TwitterFollower", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            EasyLogger.Error(e.Exception.Message + " Application.ThreadException");
        }

        private static void AppDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            EasyLogger.Error(((Exception)e.ExceptionObject).Message + " AppDomain.UnhandledException");
        }
    }
}
