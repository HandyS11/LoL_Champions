using CommunityToolkit.Mvvm.Input;
using LoL_Champions.Utils;
using LoL_Champions.Views.Pages;
using VM;
using VM.Utils;

namespace LoL_Champions.ViewModels
{
    // I should maybe split this class
    public partial class AppVM
    {
        public INavigation Navigation => Application.Current.MainPage.Navigation;

        public ChampionManagerVM ChampionManagerVM { get; private set; }

        public AddOrEditChampionVM AddOrEditChampionVM { get; private set; }
        public AddOrEditSkinVM AddOrEditSkinVM { get; private set; }
        public AddOrEditSkillVM AddOrEditSkillVM { get; private set; }

        public AppVM(ChampionManagerVM championManagerVM, AddOrEditChampionVM addOrEditChampionVM, AddOrEditSkinVM addOrEditSkinVM, AddOrEditSkillVM addOrEditSkillVM)
        {
            ChampionManagerVM = championManagerVM;

            AddOrEditChampionVM = addOrEditChampionVM;
            AddOrEditSkinVM = addOrEditSkinVM;
            AddOrEditSkillVM = addOrEditSkillVM;
        }

        [RelayCommand]
        private async Task NavigateBack()
        {
            await Navigation.PopAsync();
        }

        [RelayCommand]
        private async Task GoToChampionDetail(ChampionVM vm)
        {
            ChampionManagerVM.SelectedChampion = vm;
            await Navigation.PushAsync(new ChampionDetailPage());
        }

        [RelayCommand]
        private async Task GoToAddChampion()
        {
            AddOrEditChampionVM.Clone(null);
            await Navigation.PushAsync(new AddOrEditChampionPage());
        }

        [RelayCommand]
        private async Task GoToEditChampion(ChampionVM vm)
        {
            AddOrEditChampionVM.Clone(vm);
            ChampionManagerVM.SelectedChampion = vm;
            await Navigation.PushAsync(new AddOrEditChampionPage());
        }

        [RelayCommand]
        private async Task GoToChampionSkin(SkinVM vm)
        {
            ChampionManagerVM.SelectedChampion.SelectedSkin = vm;
            await Navigation.PushAsync(new ChampionSkinPage());
        }

        [RelayCommand]
        private async Task GoToAddSkin()
        {
            AddOrEditSkinVM.Clone(null);
            await Navigation.PushAsync(new AddOrEditSkinPage());
        }

        [RelayCommand]
        private async Task GoToEditSkin(SkinVM vm)
        {
            AddOrEditSkinVM.Clone(vm);
            AddOrEditChampionVM.SelectedSkin = vm;
            await Navigation.PushAsync(new AddOrEditSkinPage());
        }

        [RelayCommand]
        private async Task GoToAddSkill()
        {
            AddOrEditSkillVM.Clone(null);
            await Navigation.PushModalAsync(new AddOrEditSkillPage());
        }

        [RelayCommand]
        private async Task GoToEditSkill(SkillVM vm)
        {
            AddOrEditSkillVM.Clone(vm);
            AddOrEditChampionVM.SelectedSkill = vm;
            await Navigation.PushModalAsync(new AddOrEditSkillPage());
        }

        [RelayCommand]
        private async Task AddChampion()
        {
            await ChampionManagerVM.AddChampion(AddOrEditChampionVM.ToChampionVM());
            await NavigateBack();
        }

        [RelayCommand]
        private async Task EditChampion()
        {
            await ChampionManagerVM.EditChampion(AddOrEditChampionVM.ToChampionVM());
            await NavigateBack();
        }

        [RelayCommand]
        private async Task AddSkin()
        {
            var vm = AddOrEditSkinVM.SkinVM();
            if (vm == null) return;
            ChampionManagerVM.SelectedChampion.AddSkin(vm.Model);
            await NavigateBack();
        }

        [RelayCommand]
        private async Task EditSkin()
        {
            var vm = AddOrEditSkinVM.SkinVM();
            if (vm == null) return;
            ChampionManagerVM.SelectedChampion.UpdateSkin(vm.Model);
            await NavigateBack();
        }

        [RelayCommand]
        private async Task AddSkill()
        {
            var vm = AddOrEditSkillVM.SkillVM();
            if (vm == null) return;
            AddOrEditChampionVM.AddSkill(vm.Model);
            await Navigation.PopModalAsync();
        }

        [RelayCommand]
        private async Task EditSkill()
        {
            var vm = AddOrEditSkillVM.SkillVM();
            if (vm == null) return;
            AddOrEditChampionVM.UpdateSkill(vm.Model);
            await Navigation.PopModalAsync();
        }

        [RelayCommand]
        private async Task ChooseImage()
        {
            AddOrEditChampionVM.Image = await ImagePickerUtils.ChooseImageB64();
        }

        [RelayCommand]
        private async Task ChooseIcon()
        {
            AddOrEditChampionVM.Icon = await ImagePickerUtils.ChooseImageB64();
        }

        [RelayCommand]
        private async Task ChooseSkinImage()
        {
            AddOrEditSkinVM.Image = await ImagePickerUtils.ChooseImageB64();
        }

        [RelayCommand]
        private async Task ChooseSkinIcon()
        {
            AddOrEditSkinVM.Icon = await ImagePickerUtils.ChooseImageB64();
        }
    }
}
