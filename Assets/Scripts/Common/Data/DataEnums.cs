using DSA.Character.Value;

public enum ExperienceLevelType
{

}

[System.Serializable]
public enum CharacterDataIDs
{
    PersonalData = (1 << ValueTypeDefinition.VALUE_BASE_TYPE_BIT_SIZE),
    XP = (2 << ValueTypeDefinition.VALUE_BASE_TYPE_BIT_SIZE),
}

[System.Serializable]
public enum Gender
{
    Male,
    Female
}

[System.Serializable]
public enum SocialStanding
{
    Slave,
    Free,
    Noble,
}

[System.Serializable]
public enum RaceID
{
    Human = 1,
    HalfElf = 2,
    Elf = 3,
    Dwarf = 4
}