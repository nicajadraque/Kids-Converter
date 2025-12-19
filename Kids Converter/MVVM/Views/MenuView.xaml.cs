using Kids_Converter.MVVM.Models;
using Kids_Converter.MVVM.Views;
using static Kids_Converter.MVVM.Models.Measurement;

namespace Kids_Converter.MVVM.Views
{
    public partial class MenuView : ContentPage
    {
        public MenuView()
        {
            InitializeComponent();
        }

        private async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
        {
            var frame = (Frame)sender; // sender is now Frame
            var stack = (StackLayout)frame.Content; // get the StackLayout inside
            var label = (Label)stack.Children.Last(); // label is the last child in StackLayout
            var categoryName = label.Text;

            // Parse string to MeasurementCategory enum
            var category = (MeasurementCategory)Enum.Parse(
                typeof(MeasurementCategory), categoryName);

            // Navigate to ConverterView with selected category
            await Navigation.PushAsync(new ConverterView(category));
        }
    }
}
