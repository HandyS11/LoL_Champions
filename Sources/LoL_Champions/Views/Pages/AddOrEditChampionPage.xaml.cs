using LoL_Champions.ViewModels;

namespace LoL_Champions.Views.Pages;

public partial class AddOrEditChampionPage : ContentPage
{
	private AppVM AppVM => (Application.Current as App).AppVM;

	public AddOrEditChampionPage()
	{
		InitializeComponent();

		BindingContext = AppVM;
    }
}