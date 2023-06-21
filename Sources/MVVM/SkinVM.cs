using CommunityToolkit.Mvvm.ComponentModel;
using Model;

namespace VM
{
    public partial class SkinVM : ObservableObject
    {
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(Name))]
        [NotifyPropertyChangedFor(nameof(Icon))]
        [NotifyPropertyChangedFor(nameof(Image))]
        [NotifyPropertyChangedFor(nameof(Price))]
        private Skin model;

        public string Name
        {
            get => Model?.Name;
        }

        public string Description
        {
            get => Model?.Description;
            set => SetProperty(Model.Description, value, Model, (m, d) => m.Description = d);
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

        public float Price
        {
            get => Model.Price;
            set => SetProperty(Model.Price, value, Model, (m, p) => m.Price = p);
        }

        public SkinVM(Skin model)
        {
            Model = model;
        }
    }
}
