using DSA.Character;
using DSA.Character.Advantage;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdvantageListContainer : MonoBehaviour, ICharacterContainerElement
{
    [SerializeField]
    private Button advatageListButton;

    private List<IAdvantage> advantages;

    public void ActivateIncreaser(IIncreaser increaser)
    {
        if (increaser.AllowEditOfAdvantages)
        {

        }
    }

    public void DeactivateIncreaser()
    {
        
    }

    public void SetCharacter(Character character)
    {
        advantages = character.Advantages;
    }
}
