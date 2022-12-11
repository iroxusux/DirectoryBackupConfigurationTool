using Engine.Core;
using Engine.IO;
using System.Diagnostics;
using System.Timers;

namespace DirectoryBackupConfigurationTool.Classes
{
    [Serializable]
    public class DirectoryBackupConfiguration
    {
        public string? Name { get; set; }
        public string? BackupDirectory { get; set; }
        public string? BackupDestination { get; set; }
        public double EventInterval { get; set; } = 10_000; // Default 10 second timer for testing

        [NonSerialized]
        private System.Timers.Timer EventTimer;

        public void Init()
        {if(EventInterval > 0)
            {
                InitEventTimer();
            }
            
        }
        private void InitEventTimer()
        {
            if(EventTimer == null) EventTimer = new System.Timers.Timer();

            EventTimer = new System.Timers.Timer();
            EventTimer.Interval = EventInterval;
            EventTimer.Elapsed += new ElapsedEventHandler(TimerEventTrigger);
            EventTimer.Start();
        }
        private void TimerEventTrigger(object sender, ElapsedEventArgs e)
        {
            System.Timers.Timer timer = (System.Timers.Timer)sender;
            timer.Interval = EventInterval;
            Debug.WriteLine(String.Format("{0} event triggered!", Name));
            if (BackupDirectory == null || BackupDestination == null) return;
            var dateTime = DateTime.Now;
            var date = dateTime.Date;
            string dateString = String.Format("{0}_{1}_{2}", date.Month, date.Day, date.Year);
            if (Directory.Exists(BackupDestination + "/autobackup_" + dateString)) return;
            IoManager.CopyDirectory(BackupDirectory, BackupDestination + "/autobackup_" + dateString);
        }
    }
}
