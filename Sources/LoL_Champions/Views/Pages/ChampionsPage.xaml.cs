using LoL_Champions.ViewModels;
using VM;

namespace LoL_Champions.Views.Pages;

public partial class ChampionsPage : ContentPage
{
    public ChampionManagerVM _vm { get; private set; }
	public ChampionsNavigationVM _navigation { get; private set; }

    public ChampionsPage(ChampionManagerVM vm)
	{
		InitializeComponent();

        _vm = vm;
        _navigation = new ChampionsNavigationVM(Navigation);

        BindingContext = this;
    }
}