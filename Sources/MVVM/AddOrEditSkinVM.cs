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
        private string editName;

        //public SkinVM SkinVM => new(new Skin(EditName, Model.Champion, Price, Icon, Image, Description));

        public AddOrEditSkinVM() : base(new Skin("skin", new Champion(""))) { }

        public void Clone(SkinVM vm)
        {
            if (vm == null)
            {
                IsNewSkin = true;
                EditName = "Skin";
                Model = new Skin("Skin", new Champion(""));
            }
            else
            {
                IsNewSkin = false;
                Model = vm.Model;
                EditName = vm.Name;
            }
        }

        public SkinVM SkinVM()
        {
            return new(new Skin(EditName, Model.Champion, Price, Icon, Image, Description));
        }
    }
}
