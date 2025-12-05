namespace Kids_Converter.MVVM.Views;

public partial class MenuView : ContentPage
{
	public MenuView()
	{
		InitializeComponent();
	
	}

    private async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
       
        await Shell.Current.GoToAsync("///ConverterView");
    }
}