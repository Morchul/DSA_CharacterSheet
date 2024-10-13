using DSA.UI.CustomControls;

namespace DSA.UI.CharacterContainer
{
    public class PersonalDataElement : UICharacterContainerElement
    {
        private Character.Character character;

        private EditableText nameField;
        private EditableText familityField;
        private EditableNumber ageField;

        public PersonalDataElement()
        {
            nameField = new EditableText();
            familityField = new EditableText();
            ageField = new EditableNumber();

            this.Add(nameField);
            this.Add(familityField);
            this.Add(ageField);
        }

        public override void Bind(Character.Character character)
        {
            this.character = character;

            nameField.SetData(character.PersonalData.Name);
            familityField.SetData(character.PersonalData.Famility);
            ageField.SetData(character.PersonalData.Age);
        }

        public override void ActivateIncreaser(IIncreaser increaser)
        {
            nameField.ActivateIncreaser(increaser);
            familityField.ActivateIncreaser(increaser);
            ageField.ActivateIncreaser(increaser);
        }

        public override void DeactivateIncreaser(bool reset)
        {
            nameField.DeactivateIncreaser(reset);
            familityField.DeactivateIncreaser(reset);
            ageField.DeactivateIncreaser(reset);
        }
    }
}

