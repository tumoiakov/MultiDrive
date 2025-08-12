using MultiDrive.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MultiDrive.ViewModels
{
    internal class MainViewModel: INotifyPropertyChanged
    {
        public string Text => "Sample text from ViewModel";
        string info = "";
        public string Info {  
            get => info; 
            set
            {
                if (info != value)
                {
                    info = value;
                    OnPropertyChanged();
                }
            }
        }

        FileSystemWatcher fileSystemWatcher;

        public event PropertyChangedEventHandler? PropertyChanged;

        public MainViewModel()
        {
            Debug.WriteLine("MainViewModel loaded");
            Drives drives = new Drives();
            foreach(DriveInfo driveInfo in drives.DrivesInfo)
            {
                Info += driveInfo.Name + "; ";
            }
            try
            {
                fileSystemWatcher = new FileSystemWatcher(); //drives.DrivesInfo[1].RootDirectory.FullName
                fileSystemWatcher.Path = "C:\\temp";
                fileSystemWatcher.NotifyFilter = NotifyFilters.Attributes
                                 | NotifyFilters.CreationTime
                                 | NotifyFilters.DirectoryName
                                 | NotifyFilters.FileName
                                 | NotifyFilters.LastAccess
                                 | NotifyFilters.LastWrite
                                 | NotifyFilters.Security
                                 | NotifyFilters.Size;
                fileSystemWatcher.Created += OnChanged;
                fileSystemWatcher.Deleted += OnChanged;
                fileSystemWatcher.Changed += OnChanged;
                fileSystemWatcher.Renamed += OnChanged;
                fileSystemWatcher.Error += OnError;

                fileSystemWatcher.EnableRaisingEvents = true;

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        private void OnChanged(object sender, FileSystemEventArgs e)
        {
            Info = $"Файл {e.FullPath} был {e.ChangeType}";
            Debug.WriteLine($"Файл {e.FullPath} был {e.ChangeType}");
        }

        private static void OnError(object sender, ErrorEventArgs e) =>
            PrintException(e.GetException());

        private static void PrintException(Exception? ex)
        {
            if (ex != null)
            {
                Debug.WriteLine($"Message: {ex.Message}");
                Debug.WriteLine("Stacktrace:");
                Debug.WriteLine(ex.StackTrace);
                PrintException(ex.InnerException);
            }
        }

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
