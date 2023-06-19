using Model;
using VM.Utils;

namespace VM
{
    public class SkillVM : BaseViewModel
    {
        public Skill Model
        {
            get => model;
            set
            {
                SetProperty(ref model, value);
                OnPropertyChanged(nameof(Name));
                OnPropertyChanged(nameof(Description));
                OnPropertyChanged(nameof(Type));
            }
        }
        private Skill model;

        public string Name
        {
            get => model?.Name;
        }

        public string Description
        {
            get => model?.Description;
            set
            {
                if (model?.Description == value || value == null) return;
                Model.Description = value;
                OnPropertyChanged();
            }
        }

        public string Type
        {
            get => model?.Type.ToString();
        }

        public SkillVM(Skill model)
        {
            this.model = model;
        }
    }
}
