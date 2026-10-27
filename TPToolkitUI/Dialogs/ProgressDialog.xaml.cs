using System.Windows;
using TPToolkitUI.ViewModels;

namespace TPToolkitUI.Dialogs
{
    /// <summary>
    /// Interaction logic for ProgessDialog.xaml
    /// </summary>
    public partial class ProgressDialog : DialogWindow
    {
        private readonly ProgressViewModel vm;

        public ProgressDialog(Window owner, ProgressViewModel vm) : base(owner)
        {
            this.vm = vm;
            InitializeComponent();
            DataContext = vm;
        }

        public void Start(bool autoClose, bool notifyOnFinish)
        {
            Task.Run(vm.DoWork).ContinueWith((t) =>
            {
                Dispatcher.Invoke(() =>
                {
                    if (autoClose && string.IsNullOrEmpty(LogsTextBox.Text))
                        Close();
                    if (notifyOnFinish)
                        MessageBox.Show($"{ProgressLabel.Content}", Title, MessageBoxButton.OK, MessageBoxImage.Information);
                }, System.Windows.Threading.DispatcherPriority.SystemIdle);
                
            });
            ShowDialog();
        }
    }
}
