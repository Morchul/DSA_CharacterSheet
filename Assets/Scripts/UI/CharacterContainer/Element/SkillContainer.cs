using static DSA.Character.Value.Data.SkillDatabase;

namespace DSA.UI.CharacterContainer
{
    public class SkillContainer : UICharacterContainerElement
    {
        private UISkill[] skillDisplays;

        public SkillContainer(SkillData[] skills)
        {
            skillDisplays = new UISkill[skills.Length];

            for (int i = 0; i < skillDisplays.Length; ++i)
            {
                skillDisplays[i] = new UISkill(skills[i].Type);
                this.Add(skillDisplays[i]);
            }

            this.AddToClassList(StyleClass.SKILL_CONTAINER);
        }

        public override void ActivateIncreaser(IIncreaser increaser)
        {
            for (int i = 0; i < skillDisplays.Length; ++i)
            {
                skillDisplays[i].ActivateIncreaser(increaser);
            }
        }

        public override void Bind(Character.Character character)
        {
            for (int i = 0; i < skillDisplays.Length; ++i)
            {
                skillDisplays[i].Bind(character);
            }
        }

        public override void DeactivateIncreaser(bool reset)
        {
            for (int i = 0; i < skillDisplays.Length; ++i)
            {
                skillDisplays[i].DeactivateIncreaser();
            }
        }
    }
}
