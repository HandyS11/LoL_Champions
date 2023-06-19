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
            set
            {
                SetProperty(ref model, value);
                Bio = model.Bio;
                Icon = model.Icon;
                Image = model.Image;
                Class = model.Class;
                stats = new ObservableCollection<KeyValuePair<string, int>>(model?.Characteristics);
                skins = new ObservableCollection<SkinVM>(model?.Skins.Select(a => new SkinVM(a)));
                skills = new ObservableCollection<SkillVM>(model?.Skills.Select(a => new SkillVM(a)));
            }
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

        public ReadOnlyObservableCollection<KeyValuePair<string, int>> Stats { get; private set; }
        private ObservableCollection<KeyValuePair<string, int>> stats { get; set; }

        public ReadOnlyObservableCollection<SkinVM> Skins { get; private set; }
        private ObservableCollection<SkinVM> skins { get; set; }

        public ReadOnlyObservableCollection<SkillVM> Skills { get; private set; }
        private ObservableCollection<SkillVM> skills { get; set; }

        public ChampionVM(Champion model)
        {
            this.model = model;

            stats = new ObservableCollection<KeyValuePair<string, int>>(model?.Characteristics);
            Stats = new ReadOnlyObservableCollection<KeyValuePair<string, int>>(stats);

            skins = new ObservableCollection<SkinVM>(model?.Skins.Select(a => new SkinVM(a)));
            skills = new ObservableCollection<SkillVM>(model?.Skills.Select(a => new SkillVM(a)));

            Skins = new ReadOnlyObservableCollection<SkinVM>(skins);
            Skills = new ReadOnlyObservableCollection<SkillVM>(skills);
        }
    }
}
