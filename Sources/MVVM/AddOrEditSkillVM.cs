using CommunityToolkit.Mvvm.ComponentModel;
using Model;
using VM.Enums;

namespace VM
{
    public partial class AddOrEditSkillVM : SkillVM
    {
        [ObservableProperty]
        private bool isNewSkill = false;

        [ObservableProperty]
        private string editName = "Compétence";

        [ObservableProperty]
        private TypeSkill skillPicker;

        [ObservableProperty]
        private string editDesc;

        public SkillVM SkillVM => new(new Skill(EditName, (SkillType)Enum.Parse(typeof(SkillType), SkillPicker.ToString()), EditDesc));

        public AddOrEditSkillVM() : base(new Skill("Compétence", SkillType.Unknown)) { }
    }
}

