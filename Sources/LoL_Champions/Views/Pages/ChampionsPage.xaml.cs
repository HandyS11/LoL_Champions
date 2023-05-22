using VM;

namespace LoL_Champions.Views.Pages;

public partial class ChampionsPage : ContentPage
{
	private readonly ChampionManagerVM _vm;

	public ChampionsPage(ChampionManagerVM vm)
	{
		InitializeComponent();
		_vm = vm;
		BindingContext = _vm;
	}
}