using DSA.Character.Value.Calculation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace DSA.UI.Window
{
    public class ModifierInfoDisplay : VisualElement
    {
        private Label nameDisplay;
        private Label modifierChangeDisplay;

        public ModifierInfoDisplay()
        {
            nameDisplay = new Label();
            modifierChangeDisplay = new Label();

            this.Add(nameDisplay);
            this.Add(modifierChangeDisplay);
        }

        public void SetModifierInfo(ModifierInfo modifierInfo)
        {
            nameDisplay.text = "Name";
            modifierChangeDisplay.text = modifierInfo.ValueChange.ToString();
        }
    }
}

