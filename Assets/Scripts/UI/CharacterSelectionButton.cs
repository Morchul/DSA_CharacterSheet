using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelectionButton : MonoBehaviour
{
    [SerializeField]
    private Button button;

    [SerializeField]
    private TMP_Text characterNameDisplay;

    public void Init(int index, string characterName, System.Action<int> OnClick)
    {
        characterNameDisplay.text = characterName;

        button.onClick.AddListener(() => OnClick(index));
    }
}
