using System.Diagnostics;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using Model;

namespace VM
{
    public partial class AddOrEditChampionVM : ChampionVM
    {
        public ICommand AddStatEditCommand { get; private set; }
        public ICommand DeleteStatEditCommand { get; private set; }

        public ICommand DeleteSkillEditCommand { get; private set; }

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

        public AddOrEditChampionVM() : base(new Champion(""))
        {
            AddStatEditCommand = new Command(AddStatEdit);
            DeleteStatEditCommand = new Command<string>(RemoveStatEdit);

            DeleteSkillEditCommand = new Command<SkillVM>(RemoveSkillEdit);
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
