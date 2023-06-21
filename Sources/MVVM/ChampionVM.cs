using CommunityToolkit.Mvvm.ComponentModel;
using Model;
using System.Collections.ObjectModel;
using System.Data;

namespace VM
{
    public partial class ChampionVM : ObservableObject
    {
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(Name))]
        [NotifyPropertyChangedFor(nameof(Bio))]
        [NotifyPropertyChangedFor(nameof(Icon))]
        [NotifyPropertyChangedFor(nameof(Image))]
        [NotifyPropertyChangedFor(nameof(Class))]
        [NotifyPropertyChangedFor(nameof(Stats))]
        [NotifyPropertyChangedFor(nameof(Skills))]
        [NotifyPropertyChangedFor(nameof(Skins))]
        private Champion model;

        [ObservableProperty]
        private SkinVM selectedSkin;

        [ObservableProperty]
        private SkillVM selectedSkill;

        public string Name
        {
            get => Model?.Name;
        }

        public string Bio
        {
            get => Model?.Bio;
            set => SetProperty(Model.Bio, value, Model, (m, b) => m.Bio = b);
        }

        public string Icon
        {
            get => Model?.Icon;
            set => SetProperty(Model.Icon, value, Model, (m, i) => m.Icon = i);
        }

        public string Image
        {
            get => Model?.Image.Base64;
            set => SetProperty(Model.Image.Base64, value, Model, (m, i) => m.Image.Base64 = i);
        }

        public ChampionClass Class
        {
            get => Model.Class;
            set => SetProperty(Model.Class, value, Model, (m, c) => m.Class = c);
        }

        public ReadOnlyObservableCollection<KeyValuePair<string, int>> Stats { get; private set; }
        private ObservableCollection<KeyValuePair<string, int>> stats { get; set; }

        public ReadOnlyObservableCollection<SkinVM> Skins { get; private set; }
        private ObservableCollection<SkinVM> skins { get; set; }

        public ReadOnlyObservableCollection<SkillVM> Skills { get; private set; }
        private ObservableCollection<SkillVM> skills { get; set; }

        public ChampionVM(Champion model)
        {
            Model = model;

            stats = new ObservableCollection<KeyValuePair<string, int>>(Model?.Characteristics);
            Stats = new ReadOnlyObservableCollection<KeyValuePair<string, int>>(stats);

            skins = new ObservableCollection<SkinVM>(Model?.Skins.Select(a => new SkinVM(a)));
            Skins = new ReadOnlyObservableCollection<SkinVM>(skins);

            skills = new ObservableCollection<SkillVM>(Model?.Skills.Select(a => new SkillVM(a)));
            Skills = new ReadOnlyObservableCollection<SkillVM>(skills);
        }

        public void LoadStats()
        {
            stats.Clear();
            foreach(KeyValuePair<string, int> kvp in Model.Characteristics)
            {
                stats.Add(kvp);
            }
            OnPropertyChanged(nameof(Stats));
        }

        public void AddStat(string key, int value)
        {
            if (stats == null) return;
            Model.AddCharacteristics(new Tuple<string, int>[]
            {
                new Tuple<string, int>(key, value)
            });
        }

        public void RemoveStat(string key)
        {
            if (key == "") return;
            if (Model.RemoveCharacteristics(key))
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
            OnPropertyChanged(nameof(Skins));
        }

        public void AddSkin(Skin skin)
        {
            if (skin == null) return;
            Model.AddSkin(skin);
            LoadSkins();
        }

        public void RemoveSkin(Skin skin)
        {
            if (skin == null) return;
            if (Model.RemoveSkin(skin))
            {
                LoadSkins();
            }
        }

        public void UpdateSkin(Skin skin)
        {
            if (skin == null) return;
            SelectedSkin = new SkinVM(skin);
            RemoveSkin(skin);
            AddSkin(skin);
        }

        public void LoadSkills()
        {
            skills.Clear();
            foreach (Skill skill in Model.Skills)
            {
                skills.Add(new SkillVM(skill));
            }
            OnPropertyChanged(nameof(Skills));
        }

        public void AddSkill(Skill skill)
        {
            if (skill == null) return;
            Model.AddSkill(skill);
            LoadSkills();
        }

        public void RemoveSkill(Skill skill)
        {
            if (skill == null) return;
            if (Model.RemoveSkill(skill))
            {
                LoadSkills();
            }
        }

        public void UpdateSkill(Skill skill)
        {
            if (skill == null) return;
            SelectedSkill = new SkillVM(skill);
            RemoveSkill(skill);
            AddSkill(skill);
        }
    }
}
