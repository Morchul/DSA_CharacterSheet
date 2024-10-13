using UnityEngine.UIElements;

namespace DSA.UI.CharacterContainer
{
    public abstract class UICharacterValue : VisualElement
    {
        public abstract void Bind(Character.Character character);
        public abstract void ActivateIncreaser(IIncreaser increaser);
        public abstract void DeactivateIncreaser();
    }
}

