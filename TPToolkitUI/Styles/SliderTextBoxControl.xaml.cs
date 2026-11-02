using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace TPToolkitUI.Styles
{
    public partial class SliderTextBoxControl : ResourceDictionary
    {
        private void Slider_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is Slider slider)
                slider.Focus();
        }
    }
}
