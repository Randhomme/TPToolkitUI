using System.Windows;
using TPToolkitUI.Enums;

namespace TPToolkitUI.Dialogs
{
    /// <summary>
    /// Interaction logic for ModelFormatPickerDialog.xaml
    /// </summary>
    public partial class ModelFormatPickerDialog : DialogWindow
    {
        public File3DFormat SelectedFileFormat{ get; set; }
        public ModelFormatPickerDialog(Window owner) : base(owner)
        {
            InitializeComponent();
        }
    }
}
