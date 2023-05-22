using Model;
using VM.Utils;

namespace VM
{
    public class ChampionVM : BaseViewModel
    {
        public Champion Model
        {
            get => model;
            set => SetProperty(ref model, value);
        }
        private Champion model;

        public string Name
        {
            get => model?.Name;
        }

        public string Bio
        {
            get => model?.Bio;
            set
            {
                if (model.Bio == value) return;
                Bio = value;
                OnPropertyChanged();
            }
        }

        public string Icon
        {
            get => model?.Icon;
            set
            {
                if (model.Icon == value) return;
                Icon = value; 
                OnPropertyChanged();
            }
        }

        public ChampionClass? Class
        {
            get => model?.Class;
            set
            {
                if (model.Class == value) return;
                Class = value;
                OnPropertyChanged();
            }
        }

        public ChampionVM(Champion model)
        {
            this.model = model;
        }
    }
}
