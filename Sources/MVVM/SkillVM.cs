using Model;
using VM.Utils;

namespace VM
{
    public class SkillVM : BaseViewModel
    {
        public Skill Model
        {
            get => model;
            set => SetProperty(ref model, value);
        }
        private Skill model;

        public string Name
        {
            get => model?.Name;
            set
            {
                if (model?.Name == value || value == null) return;
                Name = value;
                OnPropertyChanged();
            }
        }

        public string Description
        {
            get => model?.Description;
            set
            {
                if (model?.Description == value || value == null) return;
                Description = value;
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
