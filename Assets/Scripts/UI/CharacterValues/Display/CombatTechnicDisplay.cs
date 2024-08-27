using DSA.Character;
using DSA.Character.Modifier;
using DSA.Character.Value;
using UnityEngine;

public class CombatTechnicDisplay : MonoBehaviour, ICharacterValueDisplay
{
    [Header("Settings")]
    [SerializeField]
    private CombatTechnicType type;

    [SerializeField]
    protected UIIncreaseHandler increaseHandler;

    [SerializeField]
    protected ValueDisplay valueDisplay;

    [SerializeField]
    protected TextDisplay nameDisplay;

    public void Bind(Character character)
    {
        CombatTechnic combatTechnic = character.GetCombatTechnic(type);

        nameDisplay.SetValue(combatTechnic.Data.Name);

        valueDisplay.SetValue(combatTechnic);

        increaseHandler.SetIncreasable(combatTechnic.Increasable);
    }
}
