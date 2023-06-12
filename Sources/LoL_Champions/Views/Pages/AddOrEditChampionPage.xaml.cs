namespace LoL_Champions.Views.Pages;

public partial class AddOrEditChampionPage : ContentPage
{

	public AddOrEditChampionPage()
	{
		InitializeComponent();

		BindingContext = (Application.Current as App).AppVM;
    }
}