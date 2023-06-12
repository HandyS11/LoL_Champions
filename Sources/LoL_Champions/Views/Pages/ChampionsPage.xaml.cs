namespace LoL_Champions.Views.Pages;

public partial class ChampionsPage : ContentPage
{
    public ChampionsPage()
	{
		InitializeComponent();

        BindingContext = (Application.Current as App).AppVM;
    }
}