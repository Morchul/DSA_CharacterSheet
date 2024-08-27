using DSA.Character.Effect;
using TMPro;
using UnityEngine;

public class EffectDisplay : MonoBehaviour
{
    [SerializeField]
    private TMP_Text valueChangeDisplay;

    [SerializeField]
    private TextDisplay nameDisplay;

    [SerializeField]
    private TextDisplay descriptionDisplay;

    private EffectInfo effectInfo;

    public void SetEffect(EffectInfo effectInfo)
    {
        this.effectInfo = effectInfo;
        UpdateDisplay();
    }

    public void UpdateDisplay()
    {
        valueChangeDisplay.text = effectInfo.ValueChange.ToString();
        nameDisplay.SetValue(effectInfo.Name);
        descriptionDisplay.SetValue(effectInfo.Description);
    }
}
