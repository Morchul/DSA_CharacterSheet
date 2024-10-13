using DSA.Character.Value;
using System.Collections.Generic;
using UnityEngine.UIElements;

namespace DSA.UI.CharacterContainer
{
    public class UIMainAttribute : UICharacterValue
    {
        private readonly Label abbreviation;
        private readonly Label value;

        private IncreaseContainer increaseContainer;

        private MainAttributeType attributeType { get; set; }

        private MainAttribute mainAttribute;

        private ShowValueInspectorManipulator showValueInspectorManipulator;

        public UIMainAttribute(MainAttributeType mainAttributeType) : this()
        {
            attributeType = mainAttributeType;
        }

        public UIMainAttribute()
        {
            this.abbreviation = new Label("CO");
            this.value = new Label("99");

            this.increaseContainer = new IncreaseContainer();

            VisualElement ve = new VisualElement();
            //TODO move style into uss
            ve.style.flexDirection = new StyleEnum<FlexDirection>(FlexDirection.Row);
            ve.style.alignItems = new StyleEnum<Align>(Align.Center);
            ve.Add(value);
            ve.Add(increaseContainer);

            this.Add(abbreviation);
            this.Add(ve);

            this.AddToClassList(StyleClass.MAIN_ATTRIBUTE_DISPLAY);
            abbreviation.ClearClassList();
            abbreviation.AddToClassList(StyleClass.MAIN_ATTRIBUTE_DISPLAY_ABBREVIATION);
            value.ClearClassList();
            value.AddToClassList(StyleClass.MAIN_ATTRIBUTE_DISPLAY_VALUE);

            showValueInspectorManipulator = new ShowValueInspectorManipulator();
            this.AddManipulator(showValueInspectorManipulator);
        }

        public override void Bind(Character.Character character)
        {
            mainAttribute = character.GetAttribute(attributeType);
            increaseContainer.SetIncreasable(mainAttribute.Increasable);

            mainAttribute.Value.OnValueChanged += UpdateDisplay;

            showValueInspectorManipulator.SetValue(mainAttribute);

            UpdateDisplay();
        }

        private void UpdateDisplay()
        {
            abbreviation.text = mainAttribute.Data.Abbreviation;
            value.text = mainAttribute.Value.CurrentValue.ToString();
        }

        public override void ActivateIncreaser(IIncreaser increaser)
        {
            increaseContainer.ActivateIncreaser(increaser);
        }

        public override void DeactivateIncreaser()
        {
            increaseContainer.DeactivateIncreaser();
        }
    }
}
