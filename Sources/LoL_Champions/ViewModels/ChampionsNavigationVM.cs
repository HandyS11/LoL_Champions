using LoL_Champions.Views.Pages;
using System.Windows.Input;

namespace LoL_Champions.ViewModels
{
    public class ChampionsNavigationVM
    {
        private readonly INavigation _navigation;

        public ICommand AddChampionCommand { get; private set; }

        public ChampionsNavigationVM(INavigation navigation)
        {
            _navigation = navigation;

            AddChampionCommand = new Command(async () => await GoToAddChampionPage());
        }

        private async Task GoToAddChampionPage()
        {
            await _navigation.PushAsync(new AddOrEditChampionPage());
        }
    }
}
