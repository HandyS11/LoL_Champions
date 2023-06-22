using System.Diagnostics;
using System.Windows.Input;
using Model;

namespace VM
{
    public class AddOrEditChampionVM : ChampionVM
    {
        public ICommand AddStatEditCommand { get; private set; }
        public ICommand DeleteStatEditCommand { get; private set; }

        public ICommand DeleteSkillEditCommand { get; private set; }

        public bool IsNewChamp
        {
            get => isNewChamp;
            set => SetProperty(ref isNewChamp, value);
        }
        private bool isNewChamp = false;


        public string EditName
        {
            get => editName;
            set => SetProperty(ref editName, value);
        }
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

        public string Stat
        {
            get => stat;
            set
            {
                SetProperty(ref stat, value);
            }
        }
        private string stat;

        public int StatValue
        {
            get => statValue;
            set
            {
                SetProperty(ref statValue, value);
            }
        }
        private int statValue = 0;

        public AddOrEditChampionVM() : base(new Champion(""))
        {
            AddStatEditCommand = new Command(AddStatEdit);
            DeleteStatEditCommand = new Command<string>(RemoveStatEdit);

            DeleteSkillEditCommand = new Command<SkillVM>(RemoveSkillEdit);
        }

        public ChampionVM ChampionVM()
        {
            Champion champ = new Champion(EditName, Class, Icon, Image, Bio);
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

        private void AddStatEdit()
        {
            AddStat(Stat, StatValue);
            LoadStats();
            Stat = "";
            StatValue = 0;
        }

        private void RemoveStatEdit(string key)
        {
            RemoveStat(key);
            LoadStats();
        }

        private void RemoveSkillEdit(SkillVM vm)
        {
            RemoveSkill(vm.Model);
            LoadSkills();
        }
    } 
}
