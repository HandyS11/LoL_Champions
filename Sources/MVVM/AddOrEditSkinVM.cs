using Model;

namespace VM
{
    public class AddOrEditSkinVM : SkinVM
    {
        public bool IsNewSkin
        {
            get => isNewSkin;
            set
            {
                SetProperty(ref isNewSkin, value);
                if (value)
                {
                    EditName = Name;
                }
            }
        }
        private bool isNewSkin = false;

        public string EditName
        {
            get => editName;
            set => SetProperty(ref editName, value);
        }
        private string editName;

        public SkinVM SkinVM => new(new Skin(EditName, Model.Champion, Price, Icon, Image, Description));

        public AddOrEditSkinVM() : base(new Skin("skin", new Champion("")))
        {
        }
    }
}
