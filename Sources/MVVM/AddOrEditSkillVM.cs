using System;
using System.Diagnostics;
using Model;

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

        public string SkillPicker
        {
            get => skillPicker;
            set => SetProperty(ref skillPicker, value);
        }
        private string skillPicker;

        public SkillVM SkillVM => new(new Skill(EditName, (SkillType)Enum.Parse(typeof(SkillType), SkillPicker), Description));

        public AddOrEditSkillVM() : base(new Skill("Nom de la compétence", SkillType.Unknown))
        {
        }
    }
}

