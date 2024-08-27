using UnityEngine;

public class SaveCharacterMenu : CharacterContainerMenu
{
    [SerializeField]
    private SaveHandler saveHandler;

    public override void Select()
    {
        saveHandler.SaveCharacter(character);
        Debug.Log("Save Character");

        base.Select();
    }
}
