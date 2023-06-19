using Model;

namespace VM
{
    public class AddOrEditChampionVM : ChampionVM
    {
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
                Model.Class = (ChampionClass)Enum.Parse(typeof(ChampionClass), value);
                OnPropertyChanged(nameof(Class));
                OnPropertyChanged(nameof(RadioButton));
            }
        }

        public AddOrEditChampionVM() : base(new Champion("")) { }

        public ChampionVM ChampionVM => new(Model);
    } 
}
