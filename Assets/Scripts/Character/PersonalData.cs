namespace DSA.Character
{
    public class PersonalData
    {
        public int ID => (int)CharacterDataIDs.PersonalData;

        public ObservableValue<string> Name;
        public ObservableValue<Gender> Gender;
        public ObservableValue<Race> Race;
        public ObservableValue<string> Culture;
        public ObservableValue<string> Profession;
        public ObservableValue<SocialStanding> SocialStanding;
        public ObservableValue<string> PlaceOfBirth;
        public ObservableValue<string> Famility;
        public ObservableValue<int> Age;
        public ObservableValue<string> BirthDay;
        public ObservableValue<string> HairColor;
        public ObservableValue<string> EyeColor;
        public ObservableValue<int> Height;
        public ObservableValue<int> Weight;

        public PersonalData()
        {
            Name = new ObservableValue<string>();
            Gender = new ObservableValue<Gender>();
            Race = new ObservableValue<Race>();
            Culture = new ObservableValue<string>();
            Profession = new ObservableValue<string>();
            SocialStanding = new ObservableValue<SocialStanding>();
            PlaceOfBirth = new ObservableValue<string>();
            Famility = new ObservableValue<string>();
            Age = new ObservableValue<int>();
            BirthDay = new ObservableValue<string>();
            HairColor = new ObservableValue<string>();
            EyeColor = new ObservableValue<string>();
            Height = new ObservableValue<int>();
            Weight = new ObservableValue<int>();
        }

        public void ReadData(IFileReader fileReader)
        {
            Name.Value = fileReader.ReadString();
            Gender.Value = (Gender)fileReader.ReadInt();
            int raceID = fileReader.ReadInt();
            //Race = GetRace(raceID);
            Culture.Value = fileReader.ReadString();
            Profession.Value = fileReader.ReadString();
            SocialStanding.Value = (SocialStanding)fileReader.ReadInt();
            PlaceOfBirth.Value = fileReader.ReadString();
            Famility.Value = fileReader.ReadString();
            Age.Value = fileReader.ReadInt();
            BirthDay.Value = fileReader.ReadString();
            HairColor.Value = fileReader.ReadString();
            EyeColor.Value = fileReader.ReadString();
            Height.Value = fileReader.ReadInt();
            Weight.Value = fileReader.ReadInt();
        }

        public void WriteData(IFileWriter fileWriter)
        {
            fileWriter.Write(Name.Value);
            fileWriter.Write((int)Gender.Value);
            fileWriter.Write((int)Race.Value.ID);
            fileWriter.Write(Culture.Value);
            fileWriter.Write(Profession.Value);
            fileWriter.Write((int)SocialStanding.Value);
            fileWriter.Write(PlaceOfBirth.Value);
            fileWriter.Write(Famility.Value);
            fileWriter.Write(Age.Value);
            fileWriter.Write(BirthDay.Value);
            fileWriter.Write(HairColor.Value);
            fileWriter.Write(EyeColor.Value);
            fileWriter.Write(Height.Value);
            fileWriter.Write(Weight.Value);
        }
    }
}

