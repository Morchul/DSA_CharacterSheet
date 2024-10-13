using DSA.Character.Value;
using UnityEngine.UIElements;

namespace DSA.UI.CharacterContainer
{
    public class UISkill : UICharacterValue
    {
        private readonly Label nameDisplay;
        private readonly Label valueDisplay;

        private SkillType skillType { get; set; }

        private Skill skill;

        public UISkill(SkillType mainAttributeType) : this()
        {
            skillType = mainAttributeType;
        }

        public UISkill()
        {
            this.nameDisplay = new Label("Skill");
            this.valueDisplay = new Label("99");

            this.Add(nameDisplay);
            this.Add(valueDisplay);

            this.AddToClassList(StyleClass.SKILL_DISPLAY);
            nameDisplay.ClearClassList();
            nameDisplay.AddToClassList(StyleClass.SKILL_DISPLAY_NAME);
            valueDisplay.ClearClassList();
            valueDisplay.AddToClassList(StyleClass.SKILL_DISPLAY_VALUE);
        }

        public override void Bind(Character.Character character)
        {
            skill = character.GetSkill(skillType);

            skill.Value.OnValueChanged += UpdateDisplay;

            UpdateDisplay();
        }

        private void UpdateDisplay()
        {
            nameDisplay.text = skill.Data.Name;
            valueDisplay.text = skill.Value.CurrentValue.ToString();
        }

        public override void ActivateIncreaser(IIncreaser increaser)
        {
            //throw new System.NotImplementedException();
        }

        public override void DeactivateIncreaser()
        {
            //throw new System.NotImplementedException();
        }
    }

}