using System.Diagnostics;
using System.Windows.Input;
using Model;

namespace VM
{
    public class AddOrEditChampionVM : ChampionVM
    {
        public ICommand AddStatEditCommand { get; private set; }

        public bool IsNewChamp
        {
            get => isNewChamp;
            set
            {
                SetProperty(ref isNewChamp, value);
                if (value)
                {
                    EditName = Name;
                }
            }
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

        public ChampionVM ChampionVM
        {
            get
            {
                var champ = new Champion(EditName, (ChampionClass)Class, Icon, Image, Bio);
                _ = Skills.Select(s => champ.AddSkill(s.Model));
                _ = Skins.Select(s => champ.AddSkin(s.Model));
                Stats.ToList().ForEach(s => champ.AddCharacteristics(new Tuple<string, int>(s.Key, s.Value)));
                return new(champ);
            }
        }

        public AddOrEditChampionVM() : base(new Champion(""))
        {
            AddStatEditCommand = new Command(AddStatEdit);
        }

        private void AddStatEdit()
        {
            AddStat(Stat, StatValue);
            Stat = "";
            StatValue = 0;
        }
    } 
}
