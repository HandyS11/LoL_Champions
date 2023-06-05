using Model;
using VM.Utils;

namespace VM
{
    public class SkinVM : BaseViewModel
    {
        public Skin Model
        {
            get => model;
            set => SetProperty(ref model, value);
        }
        private Skin model;

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

        public string Icon
        {
            get => model?.Icon;
            set {
                if (model?.Icon == value || value == null) return;
                Icon = value;
                OnPropertyChanged();
            }
        }

        public SkinVM(Skin model)
        {
            this.model = model;
        }
    }
}
