using DSA.Character;
using UnityEngine;

public class PlayerProgramController : MonoBehaviour
{
    [Header("UI Windows")]
    [SerializeField]
    private CharacterSelectionWindow characterSelectionList;

    [SerializeField]
    private NewCharacterWindow newCharacterWindow;

    [Header("Character")]
    [SerializeField]
    private CharacterContainer characterContainer;

    [SerializeField]
    private Character character;

    [Header("")]
    [SerializeField]
    private SaveHandler saveHandler;

    private string[] characterList;

    private void Start()
    {
        characterList = saveHandler.GetListOfCharacters();
        characterSelectionList.SetListOfCharacters(characterList, LoadCharacterFromList);
        characterSelectionList.Show();

        characterContainer.SetCharacter(character);
    }

    public void LoadCharacterFromList(int index)
    {
        //Set the name so the correct file will be selected
        character.PersonalData.Name = characterList[index];
        saveHandler.LoadCharacter(character);
        characterSelectionList.Hide();
    }

    public void CreateNewCharacter()
    {
        characterSelectionList.Hide();
        newCharacterWindow.Show();
        newCharacterWindow.SetCallback(StartCharacterCreation);
    }

    private void StartCharacterCreation(NewCharacterWindow.NewCharacterWindowReturnValue characterData)
    {
        character.PersonalData.Name = characterData.Name;
        character.XP = characterData.ExperienceLevel.XP;
        characterContainer.ActivateIncreaser(new CreationIncreaserFactory(characterData.ExperienceLevel));
        newCharacterWindow.Hide();
    }
}
