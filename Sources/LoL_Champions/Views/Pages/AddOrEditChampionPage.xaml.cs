using LoL_Champions.ViewModels;

namespace LoL_Champions.Views.Pages;

public partial class AddOrEditChampionPage : ContentPage
{
	public AddOrEditChampionNavigationVM _navigation { get; private set; }

	public AddOrEditChampionPage()
	{
		InitializeComponent();

		BindingContext = this;
	}
}