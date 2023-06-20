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
        public AddOrEditSkinVM AddOrEditSkinVM { get; private set; }

        public ICommand NavigateBackCommand { get; private set; }

        public ICommand GoToChampionDetailCommand { get; private set; }
        public ICommand GoToChampionSkinCommand { get; private set; }

        public ICommand GoToAddChampionCommand { get; private set; }
        public ICommand GoToEditChampionCommand { get; private set; }

        public ICommand GoToAddChampionSkinCommand { get ; private set; }
        public ICommand GoToEditChampionSkinCommand { get; private set; }

        public ICommand AddChampionCommand { get; private set; }
        public ICommand EditChampionCommand { get; private set; }

        public ICommand AddSkinCommand { get; private set; }
        public ICommand EditSkinCommand { get; private set; }

        public ICommand ChooseImageCommand { get; private set; }
        public ICommand ChooseIconCommand { get; private set; }

        public ICommand ChooseSkinImageCommand { get; private set; }
        public ICommand ChooseSkinIconCommand { get; private set; }

        public AppVM(ChampionManagerVM championManagerVM, AddOrEditChampionVM addOrEditChampionVM, AddOrEditSkinVM addOrEditSkinVM)
        {
            NavigateBackCommand = new Command(async () => await NavigateBack());

            GoToChampionDetailCommand = new Command<ChampionVM>(async (vm) => await GoToChampionDetail(vm));
            GoToChampionSkinCommand = new Command<SkinVM>(async (vm) => await GoToChampionSkin(vm));

            GoToAddChampionCommand = new Command(async () => await GoToAddChampion());
            GoToEditChampionCommand = new Command<ChampionVM>(async (vm) => await GoToEditChampion(vm));
            
            GoToAddChampionSkinCommand = new Command(async () => await GoToAddChampionSkin());
            GoToEditChampionSkinCommand = new Command<SkinVM>(async (vm) => await GoToEditChampionSkin(vm));

            AddChampionCommand = new Command(async () => await AddChampion(AddOrEditChampionVM.ChampionVM));
            EditChampionCommand = new Command(async () => await EditChampion(AddOrEditChampionVM.ChampionVM));

            ChooseIconCommand = new Command(async () => await ChooseIcon());
            ChooseImageCommand = new Command(async () => await ChooseImage());

            ChooseSkinIconCommand = new Command(async () => await ChooseSkinIcon());
            ChooseSkinImageCommand = new Command(async () => await ChooseSkinImage());

            ChampionManagerVM = championManagerVM;
            AddOrEditChampionVM = addOrEditChampionVM;
            AddOrEditSkinVM = addOrEditSkinVM;
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
            AddOrEditChampionVM.Stat = "";
            AddOrEditChampionVM.StatValue = 0;
            ChampionManagerVM.SelectedChampion = null;
            await Navigation.PushAsync(new AddOrEditChampionPage());
        }

        private async Task GoToEditChampion(ChampionVM vm)
        {
            ChampionManagerVM.SelectedChampion = vm;
            AddOrEditChampionVM.IsNewChamp = false;
            AddOrEditChampionVM.Stat = "";
            AddOrEditChampionVM.StatValue = 0;
            AddOrEditChampionVM.Model = vm.Model;
            await Navigation.PushAsync(new AddOrEditChampionPage());
        }

        private async Task GoToChampionSkin(SkinVM vm)
        {
            ChampionManagerVM.SelectedChampion.SelectedSkin = vm;
            await Navigation.PushAsync(new ChampionSkinPage());
        }

        private async Task GoToAddChampionSkin()
        {
            AddOrEditSkinVM.IsNewSkin = true;
            await Navigation.PushAsync(new AddOrEditSkinPage());
        }

        private async Task GoToEditChampionSkin(SkinVM vm)
        {
            AddOrEditSkinVM.IsNewSkin = false;
            ChampionManagerVM.SelectedChampion.SelectedSkin = vm;
            await Navigation.PushAsync (new AddOrEditSkinPage());
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

        private async Task AddSkin(SkinVM vm)
        {
            if (vm == null) return;
            ChampionManagerVM.SelectedChampion.AddSkin(vm.Model);
            await NavigateBack();
        }

        private async Task EditSkin(SkinVM vm)
        {
            if (vm == null) return;
            ChampionManagerVM.SelectedChampion.UpdateSkin(vm.Model);
            await NavigateBack();
        }

        private async Task ChooseImage()
        {
            AddOrEditChampionVM.Image = await ImagePickerUtils.ChooseImageB64();
        }

        private async Task ChooseIcon()
        {
            AddOrEditChampionVM.Icon = await ImagePickerUtils.ChooseImageB64();
        }

        private async Task ChooseSkinImage()
        {
            AddOrEditSkinVM.Image = await ImagePickerUtils.ChooseImageB64();
        }

        private async Task ChooseSkinIcon()
        {
            AddOrEditSkinVM.Icon = await ImagePickerUtils.ChooseImageB64();
        }
    }
}
