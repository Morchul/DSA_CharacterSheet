using DSA.Character.Value.Calculation;
using TMPro;
using UnityEngine;

public class ModifierDisplay : MonoBehaviour
{
    [SerializeField]
    private TMP_Text valueChangeDisplay;

    [SerializeField]
    private TextDisplay nameDisplay;

    [SerializeField]
    private TextDisplay descriptionDisplay;

    private ModifierInfo modifierInfo;

    public void SetModifier(ModifierInfo modifierInfo)
    {
        this.modifierInfo = modifierInfo;
        UpdateDisplay();
    }

    public void UpdateDisplay()
    {
        valueChangeDisplay.text = modifierInfo.ValueChange.ToString();
        nameDisplay.SetValue(modifierInfo.Name);
        descriptionDisplay.SetValue(modifierInfo.Description);
    }
}
