using DSA.Character;
using UnityEngine;
using UnityEngine.UIElements;

public class UICharacterContainer : MonoBehaviour
{
    [SerializeField]
    private UIDocument characterContainer;

    [SerializeField]
    private Character character;

    private MainAttributeContainer mainAttributeContainer;
    private VisualElement root;

    private void Start()
    {
        root = characterContainer.rootVisualElement;
        mainAttributeContainer = new MainAttributeContainer();
        
        Add(mainAttributeContainer);

        mainAttributeContainer.Bind(character);
    }

    public void Add(VisualElement visualElement)
    {
        root.Add(visualElement);
    }
}
