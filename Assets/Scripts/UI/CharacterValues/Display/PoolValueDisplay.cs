using DSA.Character;
using DSA.Character.Modifier;
using DSA.Character.Value;
using UnityEngine;

public class PoolValueDisplay : MonoBehaviour, ICharacterValueDisplay
{
    [Header("Settings")]
    [SerializeField]
    private PoolValueType type;

    [SerializeField]
    protected UIIncreaseHandler increaseHandler;

    [SerializeField]
    protected ValueDisplay valueDisplay;

    [SerializeField]
    protected TextDisplay nameDisplay;

    public void Bind(Character character)
    {
        PoolValue poolValue = character.GetPoolValue(type);

        nameDisplay.SetValue(poolValue.Data.Name);

        valueDisplay.SetValue(poolValue);

        increaseHandler.SetIncreasable(poolValue.Increasable);
    }
}
