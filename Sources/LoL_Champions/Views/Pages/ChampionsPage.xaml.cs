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

    private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
    {
		var b = e.Item as ChampionVM;
		await Navigation.PushAsync(new ChampionDetailPage(b));
    }
}