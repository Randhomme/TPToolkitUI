using System.Windows;
using TPToolkitUI.ViewModels;

namespace TPToolkitUI.Dialogs
{
    /// <summary>
    /// Interaction logic for MsbElementNamePicker.xaml
    /// </summary>
    public partial class MsbElementNamePicker : DialogWindow
    {
        public MsbElementNamePicker(Window owner) : base(owner)
        {
            InitializeComponent();
        }

        protected new void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            var vm = (MsbElementNamePickerViewModel)DataContext;
            try
            {
                vm.SetElementName(MsbElementNameTextBox.Text);
                this.DialogResult = true;
            }
            catch(Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Invalid name", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
