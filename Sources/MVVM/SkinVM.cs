using Model;
using VM.Utils;

namespace VM
{
    public class SkinVM : BaseViewModel
    {
        public Skin Model
        {
            get => model;
            set
            {
                SetProperty(ref model, value);
                OnPropertyChanged(nameof(Name));
                OnPropertyChanged(nameof(Description));
                OnPropertyChanged(nameof(Icon));
                OnPropertyChanged(nameof(Image));
                OnPropertyChanged(nameof(Price));
            }
        }
        private Skin model;

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

        public string Icon
        {
            get => model?.Icon;
            set {
                if (model?.Icon == value || value == null) return;
                Model.Icon = value;
                OnPropertyChanged();
            }
        }

        public string Image
        {
            get => model?.Image.Base64;
            set
            {
                if (model?.Image.Base64 == value || value == null) return;
                Model.Image.Base64 = value;
                OnPropertyChanged();
            }
        }

        public float Price
        {
            get => model.Price;
            set
            {
                if (model.Price == value) return;
                Model.Price = value;
                OnPropertyChanged();
            }
        }

        public SkinVM(Skin model)
        {
            this.model = model;
        }
    }
}
