using CommunityToolkit.Mvvm.ComponentModel;
using Model;

namespace VM
{
    public partial class AddOrEditSkinVM : SkinVM
    {
        [ObservableProperty]
        private bool isNewSkin = false;

        [ObservableProperty]
        private string editName;

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
                Model = new(vm.Name, new Champion(""), vm.Price, vm.Icon, vm.Image, vm.Description);
                EditName = vm.Name;
            }
        }

        public SkinVM SkinVM()
        {
            return new(new Skin(EditName, Model.Champion, Price, Icon, Image, Description));
        }
    }
}
