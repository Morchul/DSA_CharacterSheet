using DSA.Character;
using UnityEngine;

public class TestScriptUI : MonoBehaviour
{
    [SerializeField]
    private TestScript testScript;

    [SerializeField]
    private CharacterContainer characterContainer;

    [SerializeField]
    private CharacterValuesContainer characterValuesContainer;

    [SerializeField]
    private SaveHandler saveHandler;

    private Character character;

    public void Start()
    {
        character = testScript.Character;

        characterContainer.SetCharacter(character);

        characterContainer.AddElement(characterValuesContainer);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            characterContainer.ActivateIncreaser(new DefaultIncreaserFactory());
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            characterContainer.DeactivateIncreaser(false);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            characterContainer.DeactivateIncreaser(true);
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            Debug.Log("XP: " + character.XP);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            saveHandler.SaveCharacter(character);
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            saveHandler.LoadCharacter(character);
        }
    }
}
