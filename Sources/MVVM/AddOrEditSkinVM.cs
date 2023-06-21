using Model;

namespace VM
{
    public class AddOrEditSkinVM : SkinVM
    {
        public bool IsNewSkin
        {
            get => isNewSkin;
            set => SetProperty(ref isNewSkin, value);
        }
        private bool isNewSkin = false;

        public string EditName
        {
            get => editName;
            set => SetProperty(ref editName, value);
        }
        private string editName ="Nom du skin";

        public SkinVM SkinVM => new(new Skin(EditName, Model.Champion, Price, Icon, Image, Description));

        public AddOrEditSkinVM() : base(new Skin("skin", new Champion("")))
        {
        }
    }
}
