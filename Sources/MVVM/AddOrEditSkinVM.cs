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

        public SkinVM SkinVM => new(Model);

        public AddOrEditSkinVM() : base(new Skin("skin", new Champion("")))
        {
        }
    }
}
