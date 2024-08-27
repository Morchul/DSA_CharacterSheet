using DSA.Character;
using UnityEngine;

public class DeactivateIncreaserWindow : MonoBehaviour, ICharacterContainerElement
{
    [SerializeField]
    private CharacterContainer characterContainer;

    public void ActivateIncreaser(IIncreaser increaser)
    {
        this.gameObject.SetActive(true);
    }

    public void DeactivateIncreaser()
    {
        this.gameObject.SetActive(false);
    }

    public void ApplyChanges()
    {
        characterContainer.DeactivateIncreaser(false);
    }

    public void ResetChanges()
    {
        characterContainer.DeactivateIncreaser(true);
    }

    public void SetCharacter(Character character) {}
}
