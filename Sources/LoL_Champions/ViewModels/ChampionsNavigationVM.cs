using LoL_Champions.Views.Pages;
using System.Windows.Input;
using VM;

namespace LoL_Champions.ViewModels
{
    public class ChampionsNavigationVM
    {
        private readonly INavigation _navigation;

        public ICommand AddChampionCommand { get; private set; }
        public ICommand ChampionCommand { get; private set; }

        public ChampionsNavigationVM(INavigation navigation)
        {
            _navigation = navigation;

            AddChampionCommand = new Command(async () => await GoToAddChampionPage());
            ChampionCommand = new Command<ChampionVM>(async (vm) => await GoToChampionPage(vm));
        }

        private async Task GoToAddChampionPage()
        {
            await _navigation.PushAsync(new AddOrEditChampionPage());
        }

        private async Task GoToChampionPage(ChampionVM vm)
        {
            await _navigation.PushAsync(new ChampionDetailPage(vm));
        }
    }
}
