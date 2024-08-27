using DSA.Character;
using DSA.Character.Value;
using UnityEngine;

public class BaseValueDisplay : MonoBehaviour, ICharacterValueDisplay
{
    [Header("Settings")]
    [SerializeField]
    private BaseValueType type;

    [SerializeField]
    private bool useAbbreviation;

    [SerializeField]
    protected ValueDisplay valueDisplay;

    [SerializeField]
    protected TextDisplay nameDisplay;

    public void Bind(Character character)
    {
        BaseValue baseValue = character.GetBaseValue(type);

        if (useAbbreviation)
        {
            nameDisplay.SetValue(baseValue.Data.Abbreviation);
        }
        else
        {
            nameDisplay.SetValue(baseValue.Data.Name);
        }

        valueDisplay.SetValue(baseValue);
    }
}
