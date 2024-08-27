using TMPro;
using UnityEngine;
using UnityEngine.Localization;

public class TextDisplay : MonoBehaviour
{
    private TMP_Text nameDisplay;

    private LocalizedString value;

    private void Awake()
    {
        nameDisplay = GetComponent<TMP_Text>();
    }

    public void SetValue(LocalizedString value)
    {
        if (this.value != null)
        {
            this.value.StringChanged -= UpdateTextDisplay;
        }

        this.value = value;

        if (this.value != null)
        {
            this.value.StringChanged += UpdateTextDisplay;
            UpdateTextDisplay(this.value.GetLocalizedString());
        }
        else
        {
            UpdateTextDisplay("-");
        }
    }

    private void UpdateTextDisplay(string name)
    {
        nameDisplay.text = name;
    }
}
