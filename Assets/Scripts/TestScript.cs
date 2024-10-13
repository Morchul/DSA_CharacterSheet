using DSA.Character;
using DSA.Character.Advantage;
using DSA.UI.CharacterContainer;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestScript : MonoBehaviour
{
    [SerializeField]
    private Character character;

    [SerializeField]
    private ListOfAdvantages advantageList;

    [SerializeField]
    private UICharacterContainer characterContainer;

    public Character Character => character;

    private IAdvantage noble;

    private void Start()
    {
        LevelAdvantage levelAdvantage = advantageList.GetLevelAdvantage(AdvantageType.Noble);
        noble = levelAdvantage.GetAdvantage(2);

        characterContainer.SetCharacter(character);
    }

    private void Update()
    {
        //if (Keyboard.current.iKey.wasPressedThisFrame)
        //{
        //    noble.Add(character);
        //}
        //if (Keyboard.current.rKey.wasPressedThisFrame)
        //{
        //    noble.Remove(character);
        //}

        if(Keyboard.current.iKey.wasPressedThisFrame)
        {
            characterContainer.ActivateIncreaser(new DefaultIncreaserFactory());
        }

        if (Keyboard.current.rKey.wasPressedThisFrame)
        {
            characterContainer.DeactivateIncreaser(true);
        }

        if (Keyboard.current.aKey.wasPressedThisFrame)
        {
            characterContainer.DeactivateIncreaser(false);
        }
    }

    private IEnumerator ApplyCourageBuff()
    {
        yield return new WaitForSeconds(2);

        //Debug.Log("Apply Courage Buff");

        //CourageBoost courageBoost = new CourageBoost();
        //courageBoost.SetModifierValue(2);
        //courageBoost.ApplyToCharacter(character);

        //yield return new WaitForSeconds(4);

        //Debug.Log("Increase Courage Buff");

        //courageBoost.SetModifierValue(4);
    }
}
