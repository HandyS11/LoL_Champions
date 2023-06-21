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
        private string editName = "Compétence";

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

        // idk how to do it properly
        public SkillVM SkillVM => new(new Skill(EditName, (SkillType)Enum.Parse(typeof(SkillType), SkillPicker.ToString()), EditDesc));

        public AddOrEditSkillVM() : base(new Skill("Compétence", SkillType.Unknown))
        {
        }
    }
}

