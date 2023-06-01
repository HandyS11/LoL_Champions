using VM;

namespace LoL_Champions.Views.Pages;

public partial class ChampionDetailPage : ContentPage
{
	private readonly ChampionVM vm;
	public ChampionDetailPage(ChampionVM championVM)
	{
		InitializeComponent();

		vm = championVM;
		BindingContext = vm;
	}
}
