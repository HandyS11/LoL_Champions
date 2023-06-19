using LoL_Champions.Utils;
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

        public ICommand GoToChampionDetailCommand { get; private set; }
        public ICommand GoToAddChampionCommand { get; private set; }
        public ICommand GoToEditChampionCommand { get; private set; }

        public ICommand DeleteChampionCommand { get; private set; }
        public ICommand AddChampionCommand { get; private set; }
        public ICommand EditChampionCommand { get; private set; }

        public ICommand ChooseImageCommand { get; private set; }
        public ICommand ChooseIconCommand { get; private set; }

        public AppVM(ChampionManagerVM championManagerVM, AddOrEditChampionVM addOrEditChampionVM)
        {
            NavigateBackCommand = new Command(async () => await NavigateBack());

            GoToChampionDetailCommand = new Command<ChampionVM>(async (vm) => await GoToChampionDetail(vm));
            GoToAddChampionCommand = new Command(async () => await GoToAddChampion());
            GoToEditChampionCommand = new Command<ChampionVM>(async (vm) => await GoToEditChampion(vm));

            DeleteChampionCommand = new Command<ChampionVM>(async (vm) => await DeleteChampion(vm));
            AddChampionCommand = new Command(async () => await AddChampion(AddOrEditChampionVM.ChampionVM));
            EditChampionCommand = new Command(async () => await EditChampion(AddOrEditChampionVM.ChampionVM));

            ChooseIconCommand = new Command(async () => await ChooseIcon());
            ChooseImageCommand = new Command(async () => await ChooseImage());

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
            AddOrEditChampionVM.IsNewChamp = true;
            ChampionManagerVM.SelectedChampion = null;
            await Navigation.PushAsync(new AddOrEditChampionPage());
        }

        private async Task GoToEditChampion(ChampionVM vm)
        {
            AddOrEditChampionVM.IsNewChamp = false;
            AddOrEditChampionVM.Model = vm.Model;
            await Navigation.PushAsync(new AddOrEditChampionPage());
        }

        private async Task DeleteChampion(ChampionVM vm)
        {
            await ChampionManagerVM.DeleteChampion(vm);
        }

        private async Task ChooseImage()
        {
            AddOrEditChampionVM.Image = await ImagePickerUtils.ChooseImageB64();
        }

        private async Task ChooseIcon()
        {
            AddOrEditChampionVM.Icon = await ImagePickerUtils.ChooseImageB64();
        }

        private async Task AddChampion(ChampionVM vm)
        {
            if (vm == null) return;
            await ChampionManagerVM.AddChampion(vm);
            await NavigateBack();
        }

        private async Task EditChampion(ChampionVM vm)
        {
            if (vm == null) return;
            await ChampionManagerVM.EditChampion(vm);
            await NavigateBack();
        }
    }
}
