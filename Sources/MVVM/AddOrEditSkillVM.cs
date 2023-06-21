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
        private string editName;

        [ObservableProperty]
        private TypeSkill skillPicker;

        [ObservableProperty]
        private string editDesc;

        //public SkillVM SkillVM => new(new Skill(EditName, (SkillType)Enum.Parse(typeof(SkillType), SkillPicker.ToString()), EditDesc));

        public AddOrEditSkillVM() : base(new Skill("Compétence", SkillType.Unknown)) { }

        public void Clone(SkillVM vm)
        {
            if (vm == null)
            {
                IsNewSkill = true;
                Model = new Skill("Skill", SkillType.Unknown);
                EditName = "Compétence";
                SkillPicker = TypeSkill.Unknown;
                EditDesc = string.Empty;
            }
            else
            {
                IsNewSkill = false;
                Model = vm.Model;
                EditName = vm.Name;
                EditDesc = vm.Description;
                SkillPicker = (TypeSkill)Enum.Parse(typeof(TypeSkill), vm.Type);
            }
        }

        public SkillVM SkillVM()
        {
            return new(new Skill(EditName, (SkillType)Enum.Parse(typeof(SkillType), SkillPicker.ToString()), EditDesc));
        }
    }
}

