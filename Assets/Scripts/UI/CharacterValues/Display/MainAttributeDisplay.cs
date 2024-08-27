using DSA.Character;
using DSA.Character.Modifier;
using DSA.Character.Value;
using UnityEngine;
using UnityEngine.EventSystems;

public class MainAttributeDisplay : MonoBehaviour, ICharacterValueDisplay, IPointerClickHandler
{
    [Header("Settings")]
    [SerializeField]
    private MainAttributeType type;

    [SerializeField]
    private bool useAbbreviation;

    [SerializeField]
    protected UIIncreaseHandler increaseHandler;

    [SerializeField]
    protected ValueDisplay valueDisplay;

    [SerializeField]
    protected TextDisplay nameDisplay;

    private MainAttribute mainAttribute;

    public void Bind(Character character)
    {
        mainAttribute = character.GetAttribute(type);

        if (useAbbreviation)
        {
            nameDisplay.SetValue(mainAttribute.Data.Abbreviation);
        }
        else
        {
            nameDisplay.SetValue(mainAttribute.Data.Name);
        }

        valueDisplay.SetValue(mainAttribute);

        increaseHandler.SetIncreasable(mainAttribute.Increasable);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        WindowManager.Instance.ShowCharacterValueWindow(mainAttribute);
    }
}
