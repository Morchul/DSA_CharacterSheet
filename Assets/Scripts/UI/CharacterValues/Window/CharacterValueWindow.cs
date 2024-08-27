using DSA.Character.Value;
using DSA.Character.Value.Calculation;
using System.Collections.Generic;
using UnityEngine;

public class CharacterValueWindow : MonoBehaviour, IWindow
{
    [SerializeField]
    protected TextDisplay characterValueName;

    [Header("Modifiers")]
    [SerializeField]
    private Transform modifiersDisplayParent;

    [SerializeField]
    private ModifierDisplay modifierDisplayPrefab;

    [Header("Effects")]
    [SerializeField]
    private Transform effectsDisplayParent;

    [SerializeField]
    private EffectDisplay effectDisplayPrefab;

    private List<ModifierDisplay> modifierDisplays;

    protected CharacterValueBase characterValue;

    private void Awake()
    {
        modifierDisplays = new List<ModifierDisplay>();
    }

    private void Start()
    {
        this.gameObject.SetActive(false);
    }

    public void Show()
    {
        this.characterValue.Value.OnValueChanged += UpdateWindow;

        this.gameObject.SetActive(true);
        UpdateWindow();
    }

    public virtual void SetCharacterValue(CharacterValueBase characterValue)
    {
        if (this.characterValue != null)
        {
            this.characterValue.Value.OnValueChanged -= UpdateWindow;
        }

        this.characterValue = characterValue;

        
        characterValueName.SetValue(characterValue.Name);

        if (this.gameObject.activeInHierarchy)
        {
            UpdateWindow();
            this.characterValue.Value.OnValueChanged += UpdateWindow;
        }
    }

    public void Hide()
    {
        this.gameObject.SetActive(false);
        this.characterValue.Value.OnValueChanged -= UpdateWindow;
    }

    protected virtual void UpdateWindow()
    {
        //TODO disable unused ModifieDisplays!!!
        int counter = 0;
        foreach (ModifierInfo valueModifier in characterValue.Value.ValueCalculationInfo)
        {
            if (counter < modifierDisplays.Count)
            {
                modifierDisplays[counter].SetModifier(valueModifier);
            }
            else
            {
                ModifierDisplay newDisplay = Instantiate(modifierDisplayPrefab, modifiersDisplayParent);
                modifierDisplays.Add(newDisplay);
                newDisplay.SetModifier(valueModifier);

            }
            ++counter;
        }
    }
}
