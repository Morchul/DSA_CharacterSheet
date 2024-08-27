using DSA.Character.Value;
using TMPro;
using UnityEngine;

public class ValueDisplay : MonoBehaviour
{
    private TMP_Text valueDisplay;

    private CharacterValueBase characterValue;

    private void Awake()
    {
        valueDisplay = GetComponent<TMP_Text>();
    }

    public void SetValue(CharacterValueBase characterValue)
    {
        if(this.characterValue != null)
        {
            this.characterValue.Value.OnValueChanged -= UpdateValueDisplay;
        }

        this.characterValue = characterValue;

        if(this.characterValue != null)
        {
            this.characterValue.Value.OnValueChanged += UpdateValueDisplay;
        }

        UpdateValueDisplay();
    }

    private void UpdateValueDisplay()
    {
        if (this.characterValue == null)
        {
            valueDisplay.text = "-";
        }
        else
        {
            valueDisplay.text = characterValue.Value.CurrentValue.ToString();
        }
    }
}
