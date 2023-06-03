using LoL_Champions.ViewModels;
using VM;

namespace LoL_Champions.Views.Pages;

public partial class ChampionDetailPage : ContentPage
{
	public ChampionVM _vm { get; private set; }
	public ChampionNavigationVM _navigation { get ; private set; }

	public ChampionDetailPage(ChampionVM championVM)
	{
		InitializeComponent();

		_vm = championVM;
		_navigation = new ChampionNavigationVM(Navigation);

		BindingContext = this;
	}
}
