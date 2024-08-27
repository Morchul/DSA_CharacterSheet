using DSA.Character;
using DSA.Character.Value;
using UnityEngine.UIElements;

public class AttributeVisualElement : VisualElement
{
    private readonly Label abbreviation;
    private readonly Label value;

    private readonly MainAttributeType attributeType;

    private MainAttribute mainAttribute;

    public AttributeVisualElement(MainAttributeType mainAttributeType)
    {
        attributeType = mainAttributeType;

        this.abbreviation = new Label("-");
        this.value = new Label("-");

        this.Add(abbreviation);
        this.Add(value);

        this.AddToClassList("main-attribute-display");
    }

    public void Bind(Character character)
    {
        mainAttribute = character.GetAttribute(attributeType);

        mainAttribute.Value.OnValueChanged += UpdateDisplay;

        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        abbreviation.text = mainAttribute.Data.Abbreviation;
        value.text = mainAttribute.Value.CurrentValue.ToString();
    }
}
