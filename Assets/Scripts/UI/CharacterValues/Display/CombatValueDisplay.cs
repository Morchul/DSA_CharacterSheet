using DSA.Character;
using DSA.Character.Value;
using UnityEngine;

public class CombatValueDisplay : MonoBehaviour, ICharacterValueDisplay
{
    [Header("Settings")]
    [SerializeField]
    private CombatValueType type;

    [SerializeField]
    protected ValueDisplay valueDisplay;

    public void Bind(Character character)
    {
        CombatValue combatValue = character.GetCombatValue(type);

        valueDisplay.SetValue(combatValue);
    }
}
