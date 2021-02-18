using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace TwitterFollower
{
    internal static class BackupDatabase
    {
        private static readonly string sourceBackup = AppDomain.CurrentDomain.BaseDirectory + "Followers.mdf", databaseBackup = AppDomain.CurrentDomain.BaseDirectory + "BACKUPS\\Followers.mdf", databaseOLDBackup = AppDomain.CurrentDomain.BaseDirectory + "BACKUPS\\Followers_" + DateTime.Now.DayOfWeek + ".mdf";

        internal static bool ErrorsHaveOccurred = false;

        internal static void ExecuteBackup()
        {
            try
            {
                Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "BACKUPS");
                EasyLogger.Info("Creating a new backup of the database...");

                ProcessStartInfo startInfo = new ProcessStartInfo()
                {
                    FileName = "sqllocaldb",
                    Arguments = "stop MSSQLLocalDB",
                    CreateNoWindow = true,
                    WindowStyle = ProcessWindowStyle.Hidden
                };
                Process process = new Process
                {
                    StartInfo = startInfo
                };
                process.Start();
                process.WaitForExit();
            }
            catch (Exception ex)
            {
                ErrorsHaveOccurred = true;
                EasyLogger.Error("BackupDatabase - @ExecuteBackup(1): " + ex);
                MessageBox.Show(ex.Message, "Followers", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                if (File.Exists(databaseBackup))
                {
                    File.Copy(databaseBackup, databaseOLDBackup, true);
                }
                if (File.Exists(sourceBackup))
                {
                    File.Copy(sourceBackup, databaseBackup, true);
                }
                if (File.Exists(databaseBackup))
                {
                    File.SetLastWriteTime(databaseBackup, DateTime.Now);
                }
            }
            catch (Exception ex)
            {
                ErrorsHaveOccurred = true;
                EasyLogger.Error("BackupDatabase - @ExecuteBackup(2): " + ex);
                MessageBox.Show(ex.Message, "Followers", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
