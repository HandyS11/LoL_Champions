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
            set => SetProperty(ref isNewChamp, value);
        }
        private bool isNewChamp = false;


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

        public ChampionVM ChampionVM => new(Model);

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
