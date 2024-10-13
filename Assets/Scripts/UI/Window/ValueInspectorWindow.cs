using DSA.Character.Value;
using DSA.Character.Value.Calculation;
using System.Collections.Generic;
using UnityEngine.UIElements;

namespace DSA.UI.Window
{
    public class ValueInspectorWindow : VisualElement
    {
        private Value value;

        private Label title;
        private ScrollView scrollView;
        private VisualElement modifierInfoParent;

        private List<ModifierInfoDisplay> modifierInfoDisplayPool;
        private int activeModifierInfoDisplays;

        public ValueInspectorWindow()
        {
            modifierInfoDisplayPool = new List<ModifierInfoDisplay>();

            title = new Label();
            scrollView = new ScrollView();
            modifierInfoParent = new VisualElement();

            this.Add(title);
            this.Add(scrollView);
            scrollView.Add(modifierInfoParent);
        }

        public void SetValue(CharacterValueBase value)
        {
            this.value = value.Value;

            title.text = value.Name;

            activeModifierInfoDisplays = 0;

            foreach (ModifierInfo modifierInfo in this.value.ValueCalculationInfo)
            {
                ModifierInfoDisplay entry;

                if (modifierInfoDisplayPool.Count == activeModifierInfoDisplays)
                {
                    entry = new ModifierInfoDisplay();
                    modifierInfoDisplayPool.Add(entry);
                    modifierInfoParent.Add(entry);

                }
                else
                {
                    entry = modifierInfoDisplayPool[activeModifierInfoDisplays];
                    entry.RemoveFromClassList(StyleClass.HIDE);
                }

                entry.SetModifierInfo(modifierInfo);

                ++activeModifierInfoDisplays;
            }

            for(int i = activeModifierInfoDisplays; i < modifierInfoDisplayPool.Count; ++i)
            {
                modifierInfoDisplayPool[i].AddToClassList(StyleClass.HIDE);
            }
        }
    }
}

