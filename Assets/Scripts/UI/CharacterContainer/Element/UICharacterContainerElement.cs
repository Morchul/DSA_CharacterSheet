using UnityEngine.UIElements;

namespace DSA.UI.CharacterContainer
{
    public abstract class UICharacterContainerElement : VisualElement
    {
        public abstract void Bind(Character.Character character);
        public abstract void ActivateIncreaser(IIncreaser increaser);
        public abstract void DeactivateIncreaser(bool reset);
    }
}
