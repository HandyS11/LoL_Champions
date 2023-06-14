using LoL_Champions.ViewModels;
using VM;

namespace LoL_Champions.Views.Pages;

public partial class ChampionDetailPage : ContentPage
{
	public ChampionVM ChampionVM { get; private set; }
	public AppVM AppVM => (Application.Current as App).AppVM;

	public ChampionDetailPage()
	{
		InitializeComponent();

		BindingContext = AppVM;
	}
}
