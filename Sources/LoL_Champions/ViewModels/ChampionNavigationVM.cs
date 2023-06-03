using LoL_Champions.Views.Pages;
using System.Windows.Input;

namespace LoL_Champions.ViewModels
{
    public class ChampionNavigationVM
    {
        private readonly INavigation _navigation;

        public ICommand EditChampionCommand { get; private set; }

        public ChampionNavigationVM(INavigation navigation)
        {
            _navigation = navigation;

            EditChampionCommand = new Command(async () => await GoToEditChampionPage());
        }

        private async Task GoToEditChampionPage()
        {
            await _navigation.PushAsync(new AddOrEditChampionPage());
        }
    }
}
