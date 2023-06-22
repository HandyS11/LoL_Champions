using Model;
using System.Collections.ObjectModel;
using System.Data;
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
                OnPropertyChanged(nameof(Name));
                OnPropertyChanged(nameof(Bio));
                OnPropertyChanged(nameof(Icon));
                OnPropertyChanged(nameof(Image));
                OnPropertyChanged(nameof(Class));
                OnPropertyChanged(nameof(Stats));
                OnPropertyChanged(nameof(Skills));
                OnPropertyChanged(nameof(Skins));
            }
        }
        private Champion model;

        public SkinVM SelectedSkin
        {
            get => selectedSkin;
            set => SetProperty(ref selectedSkin, value);
        }
        private SkinVM selectedSkin;

        public SkillVM SelectedSkill
        {
            get => SelectedSkill;
            set => SetProperty(ref selectedSkill, value);
        }
        private SkillVM selectedSkill;

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
                Model.Bio = value;
                OnPropertyChanged();
            }
        }

        public string Icon
        {
            get => model?.Icon;
            set
            {
                if (model.Icon == value || value == null) return;
                Model.Icon = value; 
                OnPropertyChanged();
            }
        }

        public string Image
        {
            get => model?.Image.Base64;
            set
            {
                if (model.Image.Base64 == value || value == null) return;
                Model.Image.Base64 = value;
                OnPropertyChanged();
            }
        }

        public ChampionClass Class
        {
            get => model.Class;
            set
            {
                if (model.Class == value) return;
                Model.Class = value;
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
            Skins = new ReadOnlyObservableCollection<SkinVM>(skins);

            skills = new ObservableCollection<SkillVM>(model?.Skills.Select(a => new SkillVM(a)));
            Skills = new ReadOnlyObservableCollection<SkillVM>(skills);
        }

        public void LoadStats()
        {
            stats.Clear();
            foreach(KeyValuePair<string, int> kvp in Model.Characteristics)
            {
                stats.Add(kvp);
            }
        }

        protected void ClearStats()
        {
            stats.Clear();
        }

        public void AddStat(string key, int value)
        {
            if (stats == null) return;
            model.AddCharacteristics(new Tuple<string, int>[]
            {
                new Tuple<string, int>(key, value)
            });
            LoadStats();
        }

        public void RemoveStat(string key)
        {
            if (key == "") return;
            if (model.RemoveCharacteristics(key))
            {
                LoadStats();
            }
        }

        public void LoadSkins()
        {
            skins.Clear();
            foreach (Skin skin in Model.Skins)
            {
                skins.Add(new SkinVM(skin));
            }
        }

        protected void ClearSkins()
        {
            skins.Clear();
        }

        public void AddSkin(Skin skin)
        {
            if (skin == null) return;
            model.AddSkin(skin);
            LoadSkins();
        }

        public void RemoveSkin(Skin skin)
        {
            if (skin == null) return;
            if (model.RemoveSkin(skin))
            {
                LoadSkins();
            }
        }

        public void UpdateSkin(Skin skin)
        {
            if (skin == null) return;
            Model.RemoveSkin(SelectedSkin.Model);
            AddSkin(skin);
            SelectedSkin = new(skin);
            OnPropertyChanged(nameof(SelectedSkin));
        }

        public void LoadSkills()
        {
            skills.Clear();
            foreach (Skill skill in Model.Skills)
            {
                skills.Add(new SkillVM(skill));
            }
        }

        protected void ClearSkills()
        {
            skills.Clear();
        }

        public void AddSkill(Skill skill)
        {
            if (skill == null) return;
            model.AddSkill(skill);
            LoadSkills();
        }

        public void RemoveSkill(Skill skill)
        {
            if (skill == null) return;
            if (model.RemoveSkill(skill))
            {
                LoadSkills();
            }
        }

        public void UpdateSkill(Skill skill)
        {
            if (skill == null) return;
            RemoveSkill(SelectedSkill?.Model);
            AddSkill(skill);
        }
    }
}
