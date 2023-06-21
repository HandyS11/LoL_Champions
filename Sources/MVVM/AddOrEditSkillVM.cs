using Model;
using VM.Enums;

namespace VM
{
    public class AddOrEditSkillVM : SkillVM
    {
        public bool IsNewSkill
        {
            get => isNewSkill;
            set => SetProperty(ref isNewSkill, value);
        }
        private bool isNewSkill = false;

        public string EditName
        {
            get => editName;
            set => SetProperty(ref editName, value);
        }
        private string editName;

        public TypeSkill SkillPicker
        {
            get => skillPicker;
            set => SetProperty(ref skillPicker, value);
        }
        private TypeSkill skillPicker;

        public string EditDesc
        {
            get => editDesc;
            set => SetProperty(ref editDesc, value);
        }
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

