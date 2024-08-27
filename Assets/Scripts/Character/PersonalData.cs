using UnityEngine;

namespace DSA.Character
{
    public class PersonalData : MonoBehaviour
    {
        public int ID => (int)CharacterDataIDs.PersonalData;

        public string Name;
        public Gender Gender;
        public Race Race;
        public string Culture;
        public string Profession;
        public SocialStanding SocialStanding;
        public string PlaceOfBirth;
        public string Famility;
        public int Age;
        public string BirthDay;
        public string HairColor;
        public string EyeColor;
        public int Height;
        public int Weight;

        public void ReadData(IFileReader fileReader)
        {
            Name = fileReader.ReadString();
            Gender = (Gender)fileReader.ReadInt();
            int raceID = fileReader.ReadInt();
            //Race = GetRace(raceID);
            Culture = fileReader.ReadString();
            Profession = fileReader.ReadString();
            SocialStanding = (SocialStanding)fileReader.ReadInt();
            PlaceOfBirth = fileReader.ReadString();
            Famility = fileReader.ReadString();
            Age = fileReader.ReadInt();
            BirthDay = fileReader.ReadString();
            HairColor = fileReader.ReadString();
            EyeColor = fileReader.ReadString();
            Height = fileReader.ReadInt();
            Weight = fileReader.ReadInt();
        }

        public void WriteData(IFileWriter fileWriter)
        {
            fileWriter.Write(Name);
            fileWriter.Write((int)Gender);
            fileWriter.Write((int)Race.ID);
            fileWriter.Write(Culture);
            fileWriter.Write(Profession);
            fileWriter.Write((int)SocialStanding);
            fileWriter.Write(PlaceOfBirth);
            fileWriter.Write(Famility);
            fileWriter.Write(Age);
            fileWriter.Write(BirthDay);
            fileWriter.Write(HairColor);
            fileWriter.Write(EyeColor);
            fileWriter.Write(Height);
            fileWriter.Write(Weight);
        }
    }
}

