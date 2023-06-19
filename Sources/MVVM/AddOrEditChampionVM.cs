using Model;
using System.Diagnostics;
using VM.Utils;

namespace VM
{
    public class AddOrEditChampionVM : BaseViewModel
    {
        public bool IsNewChamp
        {
            get => isNewChamp;
            set => SetProperty(ref isNewChamp, value);
        }
        private bool isNewChamp = false;

        public ChampionVM VM
        {
            get => championVM;
            set
            {
                SetProperty(ref championVM, value);
                Name = championVM.Name;
                Icon = championVM.Icon;
                Image = championVM.Image;
                Bio = championVM.Bio;
                ChampionClass = championVM.Class;
            }
        }
        private ChampionVM championVM;

        public ChampionVM ChampionVM
        {
            get
            {
                Champion c = new(Name, (ChampionClass)ChampionClass, Icon, Image, Bio);
                return new ChampionVM(c);
            }
        }

        public string Name
        {
            get => name;
            set
            {
                SetProperty(ref name, value);
                OnPropertyChanged(nameof(Champion));
            }
        }
        private string name = "Nom";

        public string Icon
        {
            get => icon;
            set
            {
                SetProperty(ref icon, value);
                OnPropertyChanged(nameof(Champion));
            }
        }
        private string icon = "";

        public string Image
        {
            get => image;
            set
            {
                SetProperty(ref image, value);
                OnPropertyChanged(nameof(Champion));
            }
        }
        private string image = "";

        public string Bio
        {
            get => bio; 
            set
            {
                SetProperty(ref bio, value);
                OnPropertyChanged(nameof(Champion));
            }
        }
        private string bio = "";

        public string SelectedRadio
        {
            get => selectedRadio;
            set
            {
                SetProperty(ref selectedRadio, value);
                Debug.WriteLine("SELECTION: " + selectedRadio);
            }
        }
        private string selectedRadio = null;

        public ChampionClass? ChampionClass
        {
            get => championClass;
            set => SetProperty(ref championClass, value);
        }
        private ChampionClass? championClass = Model.ChampionClass.Unknown;
    } 
}
