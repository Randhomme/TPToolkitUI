using CommunityToolkit.Mvvm.ComponentModel;

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
        public partial string CurrentOperation { get; private set; } = "Working...";

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsWorkOnGoing))]
        public partial bool IsWorkDone { get; private set; } = false;

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
    }
}
