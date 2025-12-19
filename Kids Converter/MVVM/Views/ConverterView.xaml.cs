using Kids_Converter.MVVM.Models; // import the namespace
using static Kids_Converter.MVVM.Models.Measurement;

namespace Kids_Converter.MVVM.Views
{
    public partial class ConverterView : ContentPage
    {
        public ConverterView(MeasurementCategory category)
        {
            InitializeComponent();
            BindingContext = new ConverterViewModel(category);
        }
    }
}