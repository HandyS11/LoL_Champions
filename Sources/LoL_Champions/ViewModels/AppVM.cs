using LoL_Champions.Utils;
using LoL_Champions.Views.Pages;
using Model;
using System.Windows.Input;
using VM;
using VM.Enums;
using VM.Utils;

namespace LoL_Champions.ViewModels
{
    public class AppVM
    {
        public INavigation Navigation => Application.Current.MainPage.Navigation;

        public ChampionManagerVM ChampionManagerVM { get; private set; }

        public AddOrEditChampionVM AddOrEditChampionVM { get; private set; }
        public AddOrEditSkinVM AddOrEditSkinVM { get; private set; }
        public AddOrEditSkillVM AddOrEditSkillVM { get; private set; }

        public ICommand NavigateBackCommand { get; private set; }

        public ICommand GoToChampionDetailCommand { get; private set; }
        public ICommand GoToChampionSkinCommand { get; private set; }

        public ICommand GoToAddChampionCommand { get; private set; }
        public ICommand GoToEditChampionCommand { get; private set; }

        public ICommand GoToAddSkinCommand { get ; private set; }
        public ICommand GoToEditSkinCommand { get; private set; }

        public ICommand GoToAddSkillCommand { get; private set; }
        public ICommand GoToEditSkillCommand { get; private set; }

        public ICommand AddChampionCommand { get; private set; }
        public ICommand EditChampionCommand { get; private set; }

        public ICommand AddSkinCommand { get; private set; }
        public ICommand EditSkinCommand { get; private set; }

        public ICommand AddSkillCommand { get; private set; }
        public ICommand EditSkillCommand { get; private set; }

        public ICommand ChooseImageCommand { get; private set; }
        public ICommand ChooseIconCommand { get; private set; }

        public ICommand ChooseSkinImageCommand { get; private set; }
        public ICommand ChooseSkinIconCommand { get; private set; }

        public AppVM(ChampionManagerVM championManagerVM, AddOrEditChampionVM addOrEditChampionVM, AddOrEditSkinVM addOrEditSkinVM, AddOrEditSkillVM addOrEditSkillVM)
        {
            NavigateBackCommand = new Command(async () => await NavigateBack());

            GoToChampionDetailCommand = new Command<ChampionVM>(async (vm) => await GoToChampionDetail(vm));
            GoToChampionSkinCommand = new Command<SkinVM>(async (vm) => await GoToChampionSkin(vm));

            GoToAddChampionCommand = new Command(async () => await GoToAddChampion());
            GoToEditChampionCommand = new Command<ChampionVM>(async (vm) => await GoToEditChampion(vm));
            
            GoToAddSkinCommand = new Command(async () => await GoToAddSkin());
            GoToEditSkinCommand = new Command<SkinVM>(async (vm) => await GoToEditSkin(vm));

            GoToAddSkillCommand = new Command(async () => await GoToAddSkill());
            GoToEditSkillCommand = new Command<SkillVM>(async (vm) => await GoToEditSkill(vm));

            AddChampionCommand = new Command(async () => await AddChampion());
            EditChampionCommand = new Command(async () => await EditChampion());

            AddSkinCommand = new Command(async () => await AddSkin(AddOrEditSkinVM.SkinVM));
            EditSkinCommand = new Command(async () => await EditSkin(AddOrEditSkinVM.SkinVM));

            AddSkillCommand = new Command(async () => await AddSkill(AddOrEditSkillVM.SkillVM));
            EditSkillCommand = new Command(async () => await EditSkill(AddOrEditSkillVM.SkillVM));

            ChooseIconCommand = new Command(async () => await ChooseIcon());
            ChooseImageCommand = new Command(async () => await ChooseImage());

            ChooseSkinIconCommand = new Command(async () => await ChooseSkinIcon());
            ChooseSkinImageCommand = new Command(async () => await ChooseSkinImage());

            ChampionManagerVM = championManagerVM;
            AddOrEditChampionVM = addOrEditChampionVM;
            AddOrEditSkinVM = addOrEditSkinVM;
            AddOrEditSkillVM = addOrEditSkillVM;
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
            AddOrEditChampionVM.LoadStats();
            AddOrEditChampionVM.LoadSkills();
            AddOrEditChampionVM.LoadSkins();
            AddOrEditChampionVM.EditName = vm.Name;
            await Navigation.PushAsync(new AddOrEditChampionPage());
        }

        private async Task GoToChampionSkin(SkinVM vm)
        {
            ChampionManagerVM.SelectedChampion.SelectedSkin = vm;
            await Navigation.PushAsync(new ChampionSkinPage());
        }

        private async Task GoToAddSkin()
        {
            AddOrEditSkinVM.IsNewSkin = true;
            ChampionManagerVM.SelectedChampion.SelectedSkin = null;
            await Navigation.PushAsync(new AddOrEditSkinPage());
        }

        private async Task GoToEditSkin(SkinVM vm)
        {
            AddOrEditSkinVM.IsNewSkin = false;
            AddOrEditSkinVM.Model = vm.Model; 
            AddOrEditSkinVM.EditName = vm.Name;
            ChampionManagerVM.SelectedChampion.SelectedSkin = vm;
            await Navigation.PushAsync(new AddOrEditSkinPage());
        }

        private async Task GoToAddSkill()
        {
            AddOrEditSkillVM.IsNewSkill = true;
            AddOrEditSkillVM.Model = null;
            AddOrEditSkillVM.EditName = "Compétence";
            AddOrEditSkillVM.SkillPicker = TypeSkill.Unknown;
            ChampionManagerVM.SelectedChampion.SelectedSkill = null;
            await Navigation.PushModalAsync(new AddOrEditSkillPage());
        }

        private async Task GoToEditSkill(SkillVM vm)
        {
            AddOrEditSkillVM.IsNewSkill = false;
            AddOrEditSkillVM.Model = vm.Model;
            AddOrEditSkillVM.EditName = vm.Name;
            AddOrEditSkillVM.EditDesc = vm.Description;
            AddOrEditSkillVM.SkillPicker = (TypeSkill)Enum.Parse(typeof(TypeSkill), vm.Type);
            ChampionManagerVM.SelectedChampion.SelectedSkill = vm;
            await Navigation.PushModalAsync(new AddOrEditSkillPage());
        }

        private async Task AddChampion()
        {
            await ChampionManagerVM.AddChampion(AddOrEditChampionVM.ToChampionVM());
            ChampionManagerVM.SelectedChampion.LoadSkills();
            await NavigateBack();
        }

        private async Task EditChampion()
        {
            await ChampionManagerVM.EditChampion(AddOrEditChampionVM.ToChampionVM());
            ChampionManagerVM.SelectedChampion.LoadSkills();
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

        private async Task AddSkill(SkillVM vm)
        {
            if (vm == null) return;
            ChampionManagerVM.SelectedChampion.SelectedSkill = vm;
            ChampionManagerVM.SelectedChampion.AddSkill(vm.Model);
            AddOrEditChampionVM.LoadSkills();
            await Navigation.PopModalAsync();
        }

        private async Task EditSkill(SkillVM vm)
        {
            if (vm == null) return;
            ChampionManagerVM.SelectedChampion.SelectedSkill = vm;
            ChampionManagerVM.SelectedChampion.UpdateSkill(vm.Model);
            AddOrEditChampionVM.LoadSkills();
            await Navigation.PopModalAsync();
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
