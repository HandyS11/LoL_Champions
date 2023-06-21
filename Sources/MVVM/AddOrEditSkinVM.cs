using CommunityToolkit.Mvvm.ComponentModel;
using Model;

namespace VM
{
    public partial class AddOrEditSkinVM : SkinVM
    {
        [ObservableProperty]
        private bool isNewSkin = false;

        [ObservableProperty]
        private string editName ="Nom du skin";

        public SkinVM SkinVM => new(new Skin(EditName, Model.Champion, Price, Icon, Image, Description));

        public AddOrEditSkinVM() : base(new Skin("skin", new Champion("")))
        {
        }
    }
}
