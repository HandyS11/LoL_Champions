using LoL_Champions.Utils;
using LoL_Champions.Views.Pages;
using Model;
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

        public ICommand InsertAddChampionCommand { get; private set; }
        public ICommand InsertUpdateChampionCommand { get; private set; }

        public ICommand ChooseImageCommand { get; private set; }
        public ICommand ChooseIconCommand { get; private set; }

        public AppVM(ChampionManagerVM championManagerVM, AddOrEditChampionVM addOrEditChampionVM)
        {
            NavigateBackCommand = new Command(async () => await NavigateBack());
            ChampionDetailCommand = new Command<ChampionVM>(async (vm) => await GoToChampionDetail(vm));
            AddChampionCommand = new Command(async () => await GoToAddChampion());
            EditChampionCommand = new Command<ChampionVM>(async (vm) => await GoToEditChampion(vm));
            DeleteChampionCommand = new Command<ChampionVM>(DeleteChampion);

            InsertAddChampionCommand = new Command<Champion>(async (m) => await AddChampion(m));
            InsertUpdateChampionCommand = new Command<Champion>(async (m) => await EditChampion(m));

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
            AddOrEditChampionVM.VM = vm;
            await Navigation.PushAsync(new AddOrEditChampionPage());
        }

        private void DeleteChampion(ChampionVM champion)
        {
            ChampionManagerVM.DeleteChampionCommand.Execute(champion);
        }

        private async Task ChooseImage()
        {
            AddOrEditChampionVM.Image = await ImagePickerUtils.ChooseImageB64();
        }

        private async Task ChooseIcon()
        {
            AddOrEditChampionVM.Icon = await ImagePickerUtils.ChooseImageB64();
        }

        private async Task AddChampion(Champion m)
        {
            ChampionManagerVM.AddChampionCommand.Execute(new ChampionVM(m));
            await NavigateBack();
        }

        private async Task EditChampion(Champion m)
        {
            ChampionManagerVM.EditChampionCommand.Execute(new ChampionVM(m));
            await NavigateBack();
        }
    }
}
