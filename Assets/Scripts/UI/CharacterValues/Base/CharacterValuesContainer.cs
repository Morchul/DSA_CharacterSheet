using DSA.Character;
using UnityEngine;
using UnityEngine.EventSystems;

public class CharacterValuesContainer : MonoBehaviour, ICharacterContainerElement, IDragHandler, IPointerDownHandler
{
    private ICharacterValueDisplay[] characterValueDisplays;
    private UIIncreaseHandler[] increaseHandler;

    private bool editModeEnabled;

    private void Awake()
    {
        characterValueDisplays = GetComponentsInChildren<ICharacterValueDisplay>();
        increaseHandler = GetComponentsInChildren<UIIncreaseHandler>(includeInactive: true);

        editModeEnabled = false;
    }

    public void SetCharacter(Character character)
    {
        for (int i = 0; i < characterValueDisplays.Length; ++i)
        {
            characterValueDisplays[i].Bind(character);
        }
    }

    public void ActivateIncreaser(IIncreaser increaser)
    {
        for (int i = 0; i < increaseHandler.Length; ++i)
        {
            increaseHandler[i].EnableIncrease(increaser);
        }
    }

    public void DeactivateIncreaser()
    {
        for (int i = 0; i < increaseHandler.Length; ++i)
        {
            increaseHandler[i].DisableIncrease();
        }
    }

    public void SetContainerEditMode(bool active)
    {
        editModeEnabled = active;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (editModeEnabled)
        {

        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        
    }
}
