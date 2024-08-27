using DSA.Character;
using System.Collections.Generic;
using UnityEngine.UIElements;
using static DSA.Character.Value.Data.MainAttributeDatabase;

public class MainAttributeContainer : VisualElement
{
    private readonly List<AttributeVisualElement> attributeVisualElement;

    public MainAttributeContainer()
    {
        attributeVisualElement = new List<AttributeVisualElement>();
        
        foreach(MainAttributeData mainAttributeData in MainAttributes())
        {
            AttributeVisualElement attributeVisual = new AttributeVisualElement(mainAttributeData.Type);
            attributeVisualElement.Add(attributeVisual);
            this.Add(attributeVisual);
        }

        this.AddManipulator(new DragAndDropManipulator());
        this.AddToClassList("main-attribute-container-style");
    }

    public void Bind(Character character)
    {
        for (int i = 0; i < attributeVisualElement.Count; ++i)
        {
            attributeVisualElement[i].Bind(character);
        }
    }
}
