using DSA.Character.Value.Data;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace DSA.UI.CharacterContainer
{
    public class UICharacterContainer : MonoBehaviour
    {
        [SerializeField]
        private UIDocument characterContainer;

        private VisualElement root;
        private VisualElement elementParent;

        private List<UICharacterContainerElement> containerElements;

        private Character.Character character;

        private IIncreaser currentIncreaser;

        private void Awake()
        {
            root = characterContainer.rootVisualElement;
            elementParent = root.Q<VisualElement>("elements");

            containerElements = new List<UICharacterContainerElement>();

            BuildStatusUI();
        }

        private void BuildStatusUI()
        {
            containerElements.Add(new MainAttributeContainer());
            containerElements.Add(new SkillContainer(SkillDatabase.PhysicalSkillData));
            containerElements.Add(new SkillContainer(SkillDatabase.SocialSkillData));
            containerElements.Add(new SkillContainer(SkillDatabase.NatureSkillData));
            containerElements.Add(new SkillContainer(SkillDatabase.KnowledgeSkillData));
            containerElements.Add(new SkillContainer(SkillDatabase.CraftSkillData));
            containerElements.Add(new PersonalDataElement());

            foreach (UICharacterContainerElement containerElement in containerElements)
            {
                elementParent.Add(containerElement);
            }
        }

        public void SetCharacter(Character.Character character)
        {
            Log.Debug($"Set Character in CharacterContainer");
            this.character = character;

            containerElements.ForEach((value) => { value.Bind(character); });
        }

        public void ActivateIncreaser(IIncreaserFactory increaserFactory)
        {
            Log.Debug($"Activate Increaser in CharacterContainer");
            currentIncreaser = increaserFactory.Create();

            currentIncreaser.Start(character);

            containerElements.ForEach((value) => { value.ActivateIncreaser(currentIncreaser); });
        }

        public void DeactivateIncreaser(bool reset)
        {
            if (currentIncreaser == null)
                return;

            Log.Debug($"Deactivate Increaser in CharacterContainer");
            if (reset)
            {
                currentIncreaser.Reset();
            }
            else
            {
                currentIncreaser.Apply();
            }

            currentIncreaser = null;

            containerElements.ForEach((value) => { value.DeactivateIncreaser(reset); });
        }
    }
}

