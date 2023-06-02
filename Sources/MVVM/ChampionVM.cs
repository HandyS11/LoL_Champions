using Model;
using System.Collections.ObjectModel;
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
                if (model.Bio == value || value == null) return;
                Bio = value;
                OnPropertyChanged();
            }
        }

        public string Icon
        {
            get => model?.Icon;
            set
            {
                if (model.Icon == value || value == null) return;
                Icon = value; 
                OnPropertyChanged();
            }
        }

        public LargeImage Image
        {
            get => model?.Image;
            set
            {
                if (model.Image == value || value == null) return;
                Image = value;
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

        public ReadOnlyObservableCollection<Skin> Skins { get; private set; }
        private ObservableCollection<Skin> skins { get; set; }

        public ReadOnlyObservableCollection<Skill> Skills { get; private set; }
        private ObservableCollection<Skill> skills { get; set; }

        public ChampionVM(Champion model)
        {
            this.model = model;

            skins = new ObservableCollection<Skin>(model?.Skins);
            skills = new ObservableCollection<Skill>(model?.Skills);

            Skins = new ReadOnlyObservableCollection<Skin>(skins);
            Skills = new ReadOnlyObservableCollection<Skill>(skills);
        }
    }
}
