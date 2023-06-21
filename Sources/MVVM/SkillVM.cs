using CommunityToolkit.Mvvm.ComponentModel;
using Model;

namespace VM
{
    public partial class SkillVM : ObservableObject
    {
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(Name))]
        [NotifyPropertyChangedFor(nameof(Description))]
        [NotifyPropertyChangedFor(nameof(Type))]
        private Skill model; 

        public string Name
        {
            get => Model?.Name;
        }

        public string Description
        {
            get => Model?.Description;
            set => SetProperty(Model.Description, value, Model, (m, d) => m.Description = d);
        }

        public string Type
        {
            get => Model?.Type.ToString();
        }

        public SkillVM(Skill model)
        {
            Model = model;
        }
    }
}
