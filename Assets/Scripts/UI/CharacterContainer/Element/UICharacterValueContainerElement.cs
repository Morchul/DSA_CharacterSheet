using System.Collections.Generic;
using UnityEngine.UIElements;

namespace DSA.UI.CharacterContainer
{
    public class UICharacterValueContainerElement : UICharacterContainerElement
    {
        public new class UxmlFactory : UxmlFactory<UICharacterValueContainerElement> { }

        private List<UICharacterValue> characterContainerValues;

        public UICharacterValueContainerElement()
        {
            RegisterCallback<AttachToPanelEvent>(Init);
        }

        public void Init(AttachToPanelEvent _)
        {
            UnregisterCallback<AttachToPanelEvent>(Init);
            characterContainerValues = this.Query<UICharacterValue>().ToList();
        }

        public override void Bind(Character.Character character)
        {
            characterContainerValues.ForEach((value) => value.Bind(character));
        }

        public override void ActivateIncreaser(IIncreaser increaser)
        {
            characterContainerValues.ForEach((value) => value.ActivateIncreaser(increaser));
        }

        public override void DeactivateIncreaser(bool reset)
        {
            characterContainerValues.ForEach((value) => value.DeactivateIncreaser());
        }
    }

}
