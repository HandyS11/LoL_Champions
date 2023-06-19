using LoL_Champions.ViewModels;

namespace LoL_Champions.Views.Pages;

public partial class ChampionSkinPage : ContentPage
{
    public AppVM AppVM => (Application.Current as App).AppVM;

    public ChampionSkinPage()
	{
		InitializeComponent();

		BindingContext = AppVM;
	}
}