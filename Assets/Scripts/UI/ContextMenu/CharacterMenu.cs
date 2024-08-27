using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMenu : MonoBehaviour
{
    [SerializeField]
    private SaveHandler saveHandler;

    [SerializeField]
    private CharacterContainer characterContainer;

    public void Save()
    {
        saveHandler.SaveCharacter(characterContainer.Character);
    }

    public void ActivateDefaultIncreaser()
    {
        
    }

    public void ActivateCreationIncreaser()
    {
        
    }

    public static bool IsDM()
    {
        return GameController.Instance.CurrentRole == Role.DM;
    }
}
