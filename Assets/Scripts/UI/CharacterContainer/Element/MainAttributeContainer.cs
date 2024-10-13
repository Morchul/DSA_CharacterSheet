using static DSA.Character.Value.Data.MainAttributeDatabase;

namespace DSA.UI.CharacterContainer
{
    public class MainAttributeContainer : UICharacterContainerElement
    {
        private UIMainAttribute[] mainAttributeDisplays;

        public MainAttributeContainer()
        {
            mainAttributeDisplays = new UIMainAttribute[MainAttributesData.Length];

            for (int i = 0; i < mainAttributeDisplays.Length; ++i)
            {
                mainAttributeDisplays[i] = new UIMainAttribute(MainAttributesData[i].Type);
                this.Add(mainAttributeDisplays[i]);
            }

            this.AddToClassList(StyleClass.MAIN_ATTRIBUTE_CONTAINER);
        }

        public override void ActivateIncreaser(IIncreaser increaser)
        {
            for (int i = 0; i < mainAttributeDisplays.Length; ++i)
            {
                mainAttributeDisplays[i].ActivateIncreaser(increaser);
            }
        }

        public override void Bind(Character.Character character)
        {
            for (int i = 0; i < mainAttributeDisplays.Length; ++i)
            {
                mainAttributeDisplays[i].Bind(character);
            }
        }

        public override void DeactivateIncreaser(bool reset)
        {
            for (int i = 0; i < mainAttributeDisplays.Length; ++i)
            {
                mainAttributeDisplays[i].DeactivateIncreaser();
            }
        }
    }
}

