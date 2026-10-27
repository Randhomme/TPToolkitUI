using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TPToolkitUI.ViewModels
{
    public partial class ProgressViewModel : ObservableObject
    {
        private readonly Action<IProgress<string>, IProgress<string>> work;

        public IProgress<string> Progress { get; }

        public IProgress<string> ProgressLogs { get; }

        [ObservableProperty]
        public partial string Logs { get; set; } = string.Empty;

        [ObservableProperty]
        public partial string CurrentOperation { get; set; } = "Working...";

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsWorkOnGoing))]
        public partial bool IsWorkDone { get; set; } = false;

        public bool IsWorkOnGoing { get => !IsWorkDone; }

        public ProgressViewModel(Action<IProgress<string>, IProgress<string>> work)
        {
            Progress = new Progress<string>(ProgressReport);
            ProgressLogs = new Progress<string>(ProgressLogsReport);
            this.work = work;
        }

        private void ProgressReport(string s)
        {
            CurrentOperation = s;
        }

        private void ProgressLogsReport(string s)
        {
            Logs += s + Environment.NewLine;
        }

        public void DoWork()
        {
            work(Progress, ProgressLogs);
            IsWorkDone = true;
        }

        //public void RunAction(Action<IProgress<string>, IProgress<string>> action, bool autoClose = false, bool notifyOnAutoClose = true)
        //{
        //    Logs = string.Empty;
        //    this.AutoClose = autoClose;
        //    this.NotifyOnAutoClose = notifyOnAutoClose;
        //    Task.Run(() =>
        //    {
        //        action?.Invoke(this.Progress, this.ProgressLogs);
        //        this.Dispatcher.Invoke(() => { CanClose = true; }, System.Windows.Threading.DispatcherPriority.SystemIdle);
        //    });
        //    this.ShowDialog();
        //}

        //public void RunActionSameThread(Action<IProgress<string>, IProgress<string>> action, bool autoClose = false, bool notifyOnAutoClose = true)
        //{
        //    Logs = string.Empty;
        //    this.AutoClose = autoClose;
        //    this.NotifyOnAutoClose = notifyOnAutoClose;
        //    this.Dispatcher.InvokeAsync(() =>
        //    {
        //        action?.Invoke(this.Progress, this.ProgressLogs);
        //        this.Dispatcher.Invoke(() => { CanClose = true; }, System.Windows.Threading.DispatcherPriority.SystemIdle);
        //    }, System.Windows.Threading.DispatcherPriority.SystemIdle);
        //    this.ShowDialog();
        //}

        //partial void OnCanCloseChanged(bool value)
        //{
        //    if (value)
        //    {
        //        ProgressBarIndeterminate = false;
        //        if (AutoClose && string.IsNullOrEmpty(Logs))
        //        {
        //            this.Dispatcher.Invoke(() => this.Close());
        //            if (NotifyOnAutoClose)
        //                MessageBox.Show($"{CurrentOperation}", Title, MessageBoxButton.OK, MessageBoxImage.Information);
        //        }
        //    }
        //}
    }
}
