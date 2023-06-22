using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Diagnostics;
using Model;
using System.Collections.ObjectModel;
using System.Linq;

namespace VM
{
    public partial class AddOrEditChampionVM : ChampionVM
    {
        [ObservableProperty]
        private bool isNewChamp = false;

        [ObservableProperty]
        private string editName;

        public string RadioButton
        {
            get => Model.Class.ToString();
            set
            {
                if (Model.Class.ToString() == value) return;
                try
                {
                    ChampionClass c = (ChampionClass)Enum.Parse(typeof(ChampionClass), value);
                    Model.Class = c;
                }
                catch (Exception e)
                {
                    Model.Class = ChampionClass.Marksman;       // Do not ask me why I don't understand
                    Debug.WriteLine(e.Message);
                }
                OnPropertyChanged(nameof(Class));
                OnPropertyChanged(nameof(RadioButton));
            }
        }

        [ObservableProperty]
        private string stat;

        [ObservableProperty]
        private int statValue = 0;

        public AddOrEditChampionVM() : base(new Champion("")) { }

        public ChampionVM ChampionVM()
        {
            Champion champ = new(EditName, Class, Icon, Image, Bio);
            Skills.ToList().ForEach(s => champ.AddSkill(s.Model));
            Skins.ToList().ForEach(s => champ.AddSkin(s.Model));
            Stats.ToList().ForEach(s => champ.AddCharacteristics(Tuple.Create<string, int>(s.Key, s.Value)));
            return new(champ);
        }

        public void Clone(ChampionVM vm)
        {
            if (vm == null)
            {
                IsNewChamp = true;
                Model = new Champion("");
                ClearStats();
                ClearSkills();
                ClearSkins();
            }
            else
            {
                IsNewChamp = false;
                Model = new(vm.Name, vm.Class, vm.Icon, vm.Image, vm.Bio);
                vm.Stats.ToList().ForEach(s => AddStat(s.Key, s.Value));
                vm.Skills.ToList().ForEach(s => AddSkill(s.Model));
                vm.Skins.ToList().ForEach(s => AddSkin(s.Model));
                EditName = vm.Name;
            }
            ResetDatas();          
        }

        public void ResetDatas()
        {
            Stat = string.Empty;
            StatValue = 0;
        }

        [RelayCommand]
        private void AddStatEdit()
        {
            AddStat(Stat, StatValue);
            ResetDatas();
        }

        [RelayCommand]
        private void DeleteStatEdit(string key)
        {
            RemoveStat(key);
        }

        [RelayCommand]
        private void DeleteSkillEdit(SkillVM vm)
        {
            RemoveSkill(vm.Model);
        }
    } 
}
