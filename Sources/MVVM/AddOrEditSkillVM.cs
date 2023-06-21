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
        private string editName = "Nom de la compétence";

        public TypeSkill SkillPicker
        {
            get => skillPicker;
            set => SetProperty(ref skillPicker, value);
        }
        private TypeSkill skillPicker;

        // idk how to do it properly
        public SkillVM SkillVM => new(new Skill(EditName, (SkillType)Enum.Parse(typeof(SkillType), SkillPicker.ToString()), Description));

        public AddOrEditSkillVM() : base(new Skill("Nom de la compétence", SkillType.Unknown))
        {
        }
    }
}

