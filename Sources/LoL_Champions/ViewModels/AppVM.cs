using LoL_Champions.Views.Pages;
using System.Windows.Input;
using VM;

namespace LoL_Champions.ViewModels
{
    public class AppVM
    {
        public INavigation Navigation => Application.Current.MainPage.Navigation;

        public ChampionManagerVM ChampionManagerVM { get; private set; }
        public AddOrEditChampionVM AddOrEditChampionVM { get; private set; }

        public ICommand NavigateBackCommand { get; private set; }
        public ICommand ChampionDetailCommand { get; private set; }
        public ICommand AddChampionCommand { get; private set; }
        public ICommand EditChampionCommand { get; private set; }
        public ICommand DeleteChampionCommand { get; private set; }

        public AppVM(ChampionManagerVM championManagerVM, AddOrEditChampionVM addOrEditChampionVM)
        {
            NavigateBackCommand = new Command(async () => await NavigateBack());
            ChampionDetailCommand = new Command<ChampionVM>(async (vm) => await GoToChampionDetail(vm));
            AddChampionCommand = new Command(async () => await GoToAddChampion());
            EditChampionCommand = new Command<ChampionVM>(async (vm) => await GoToEditChampion(vm));
            DeleteChampionCommand = new Command<ChampionVM>(DeleteChampion);

            ChampionManagerVM = championManagerVM;
            AddOrEditChampionVM = addOrEditChampionVM;
        }

        private async Task NavigateBack()
        {
            await Navigation.PopAsync();
        }

        private async Task GoToChampionDetail(ChampionVM vm)
        {
            ChampionManagerVM.SelectedChampion = vm;
            await Navigation.PushAsync(new ChampionDetailPage());
        }

        private async Task GoToAddChampion()
        {
            AddOrEditChampionVM.isNewChamp = true;
            await Navigation.PushAsync(new AddOrEditChampionPage());
        }

        private async Task GoToEditChampion(ChampionVM vm)
        {
            AddOrEditChampionVM.isNewChamp = false;
            AddOrEditChampionVM.VM = vm;
            await Navigation.PushAsync(new AddOrEditChampionPage());
        }

        private void DeleteChampion(ChampionVM champion)
        {
            ChampionManagerVM.DeleteChampionCommand.Execute(champion);
        }
    }
}
