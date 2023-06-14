using Model;
using VM.Utils;

namespace VM
{
    public class AddOrEditChampionVM : BaseViewModel
    {
        public bool isNewChamp { get; set; } = false;

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
            }
        }
        private ChampionVM championVM;

        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }
        private string name = "Nom";

        public string Icon
        {
            get => icon;
            set => SetProperty(ref icon, value);
        }
        private string icon = "";

        public LargeImage Image
        {
            get => image;
            set => SetProperty(ref image, value);
        }
        private LargeImage image;

        public string Bio
        {
            get => bio; 
            set => SetProperty(ref bio, value);
        }
        private string bio;
    } 
}
