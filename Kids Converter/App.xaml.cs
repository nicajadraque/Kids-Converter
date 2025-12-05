using Kids_Converter.MVVM.Views;

namespace Kids_Converter
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

        }
        protected override Window CreateWindow(IActivationState? activationState)
        {
           
            return new Window(new AppShell());
        }
    }

}