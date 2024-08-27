using UnityEngine;

public class CharacterSelectionWindow : MonoBehaviour
{
    [SerializeField]
    private CharacterSelectionButton selectCharacterButtonPrefab;

    [SerializeField]
    private Transform selectionButtonParent;

    public void SetListOfCharacters(string[] characters, System.Action<int> SelectCharacter)
    {
        for(int i = 0; i < characters.Length; ++i)
        {
            CharacterSelectionButton selectionButton = Instantiate(selectCharacterButtonPrefab, selectionButtonParent);
            selectionButton.Init(i, characters[i], SelectCharacter);
        }
    }

    public void Show()
    {
        this.gameObject.SetActive(true);
    }

    public void Hide()
    {
        this.gameObject.SetActive(false);
    }
}
