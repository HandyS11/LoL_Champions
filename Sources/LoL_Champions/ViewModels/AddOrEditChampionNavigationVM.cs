using System.Windows.Input;

namespace LoL_Champions.ViewModels
{
    public class AddOrEditChampionNavigationVM
    {
        private readonly INavigation _navigation;

        public ICommand NavigateBackCommand { get; private set; }

        public AddOrEditChampionNavigationVM(INavigation navigation)
        {
            _navigation = navigation;

            NavigateBackCommand = new Command(async () => await NavigateBack());
        }

        private async Task NavigateBack()
        {
            await _navigation.PopAsync();
        }
    }
}
