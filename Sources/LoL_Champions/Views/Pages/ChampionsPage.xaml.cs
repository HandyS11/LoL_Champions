using LoL_Champions.ViewModels;

namespace LoL_Champions.Views.Pages;

public partial class ChampionsPage : ContentPage
{
    private AppVM AppVM => (Application.Current as App).AppVM;

    public ChampionsPage()
	{
		InitializeComponent();

        BindingContext = AppVM;
    }
}