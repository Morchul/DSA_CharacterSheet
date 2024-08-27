using DSA.Character;
using System.Collections.Generic;
using UnityEngine;

public class CharacterContainer : MonoBehaviour
{
    private List<ICharacterContainerElement> characterContainerElements;

    private Character character;

    private IIncreaser currentIncreaser;

    public Character Character => character;

    private void Awake()
    {
        characterContainerElements = new List<ICharacterContainerElement>();

        characterContainerElements.AddRange(GetComponentsInChildren<ICharacterContainerElement>(includeInactive: true));
        Log.Debug($"Get Elements of CharacterContainer. Current amount: {characterContainerElements.Count}");
    }

    public void ActivateIncreaser(IIncreaserFactory increaserFactory)
    {
        Log.Debug($"Activate Increaser in CharacterContainer");
        currentIncreaser = increaserFactory.Create();

        currentIncreaser.Start(character);

        for (int i = 0; i < characterContainerElements.Count; ++i)
        {
            characterContainerElements[i].ActivateIncreaser(currentIncreaser);
        }
    }

    public void DeactivateIncreaser(bool reset)
    {
        Log.Debug($"Deactivate Increaser in CharacterContainer");
        if (reset)
        {
            currentIncreaser.Reset();
        }
        else
        {
            currentIncreaser.Apply();
        }

        currentIncreaser = null;

        for (int i = 0; i < characterContainerElements.Count; ++i)
        {
            characterContainerElements[i].DeactivateIncreaser();
        }
    }

    public void SetCharacter(Character character)
    {
        Log.Debug($"Set Character in CharacterContainer");
        this.character = character;

        for(int i = 0; i < characterContainerElements.Count; ++i)
        {
            characterContainerElements[i].SetCharacter(character);
        }
    }
    
    public void AddElement(ICharacterContainerElement element)
    {
        characterContainerElements.Add(element);

        if(character != null)
        {
            element.SetCharacter(character);
        }

        if(currentIncreaser != null)
        {
            element.ActivateIncreaser(currentIncreaser);
        }
    }
}
