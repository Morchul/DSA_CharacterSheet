using DSA.Character;
using DSA.Character.Modifier;
using DSA.Character.Value;
using System.IO;

public class CharacterSaveHandler
{
    private const string CHARACTER_SAVE_FILE_DIRECTORY = "/Character/";

    public string GetSaveFileLocation(Character character)
    {
        return $"/{CHARACTER_SAVE_FILE_DIRECTORY}/{character.Name}.txt";
    }

    public string[] GetListOfCharacters()
    {
        string[] filePaths = Directory.GetFiles(SaveHandler.SAVE_DIRECTORY + CHARACTER_SAVE_FILE_DIRECTORY);
        string[] files = new string[filePaths.Length];
        for(int i = 0; i < files.Length; ++i)
        {
            files[i] = FileUtility.GetFile(filePaths[i], withoutExtension: true);
        }
        return files;
    }

    public void Save(Character character, IFileWriter fileWriter)
    {
        Log.Debug($"Start Saving character {character.Name}");

        MainAttribute[] mainAttributes = character.MainAttributes;
        Log.Verbose($"Saving {mainAttributes.Length} Main Attributes");
        foreach(MainAttribute mainAttribute in mainAttributes) SaveMainAttribute(mainAttribute, fileWriter);

        Skill[] physivalSkills = character.PhysicalSkills;
        Log.Verbose($"Saving {physivalSkills.Length} Physical Skills");
        foreach (Skill skill in physivalSkills) SaveSkill(skill, fileWriter);

        Skill[] socialSkills = character.SocialSkills;
        Log.Verbose($"Saving {socialSkills.Length} Social Skills");
        foreach (Skill skill in socialSkills) SaveSkill(skill, fileWriter);

        Skill[] natureSkills = character.NatureSkills;
        Log.Verbose($"Saving {natureSkills.Length} Nature Skills");
        foreach (Skill skill in natureSkills) SaveSkill(skill, fileWriter);

        Skill[] knowledgeSkills = character.KnowledgeSkills;
        Log.Verbose($"Saving {knowledgeSkills.Length} Knowledge Skills");
        foreach (Skill skill in knowledgeSkills) SaveSkill(skill, fileWriter);

        Skill[] craftSkills = character.CraftSkills;
        Log.Verbose($"Saving {craftSkills.Length} Craft Skills");
        foreach (Skill skill in craftSkills) SaveSkill(skill, fileWriter);

        CombatTechnic[] combatTechnics = character.CombatTechnics;
        Log.Verbose($"Saving {combatTechnics.Length} Combat Technics");
        foreach (CombatTechnic combatTechnic in combatTechnics) SaveCombatTechnic(combatTechnic, fileWriter);

        Log.Debug($"Saved Character {character.Name} successfully");
    }

    public void Load(Character character, IFileReader fileReader)
    {
        Log.Debug($"Start loading character {character.Name}");

        MainAttribute[] mainAttributes = character.MainAttributes;
        Log.Verbose($"Loading {mainAttributes.Length} Main Attributes");
        foreach (MainAttribute mainAttribute in mainAttributes) LoadMainAttribute(mainAttribute, fileReader);

        Skill[] physivalSkills = character.PhysicalSkills;
        Log.Verbose($"Loading {physivalSkills.Length} Physical Skills");
        foreach (Skill skill in physivalSkills) LoadSkill(skill, fileReader);

        Skill[] socialSkills = character.SocialSkills;
        Log.Verbose($"Loading {socialSkills.Length} Social Skills");
        foreach (Skill skill in socialSkills) LoadSkill(skill, fileReader);

        Skill[] natureSkills = character.NatureSkills;
        Log.Verbose($"Loading {natureSkills.Length} Nature Skills");
        foreach (Skill skill in natureSkills) LoadSkill(skill, fileReader);

        Skill[] knowledgeSkills = character.KnowledgeSkills;
        Log.Verbose($"Loading {knowledgeSkills.Length} Knowledge Skills");
        foreach (Skill skill in knowledgeSkills) LoadSkill(skill, fileReader);

        Skill[] craftSkills = character.CraftSkills;
        Log.Verbose($"Loading {craftSkills.Length} Craft Skills");
        foreach (Skill skill in craftSkills) LoadSkill(skill, fileReader);

        CombatTechnic[] combatTechnics = character.CombatTechnics;
        Log.Verbose($"Loading {combatTechnics.Length} Combat Technics");
        foreach (CombatTechnic combatTechnic in combatTechnics) LoadCombatTechnic(combatTechnic, fileReader);

        Log.Debug($"Loaded Character {character.Name} successfully");
    }

    private void SaveCombatTechnic(CombatTechnic combatTechnic, IFileWriter writer)
    {
        SaveIncreasable(combatTechnic.Increasable, writer);
    }

    private void LoadCombatTechnic(CombatTechnic combatTechnic, IFileReader reader)
    {
        LoadIncreasable(combatTechnic.Increasable, reader);
    }

    private void SaveSkill(Skill skill, IFileWriter writer)
    {
        SaveIncreasable(skill.Increasable, writer);
    }

    private void LoadSkill(Skill skill, IFileReader reader)
    {
        LoadIncreasable(skill.Increasable, reader);
    }

    private void SaveMainAttribute(MainAttribute mainAttribute, IFileWriter writer)
    {
        SaveIncreasable(mainAttribute.Increasable, writer);
    }

    private void LoadMainAttribute(MainAttribute mainAttribute, IFileReader reader)
    {
        LoadIncreasable(mainAttribute.Increasable, reader);
    }

    private void SaveIncreasable(IIncreasable increasable, IFileWriter writer)
    {
        writer.Write(increasable.Type);
        writer.Write(increasable.IncreaseValue);
        Log.Verbose($"Saved Increasable Value [{increasable.Type.GetNameOfValueType()}] with {increasable.IncreaseValue}");
    }
    
    private void LoadIncreasable(IIncreasable increasable, IFileReader reader)
    {
        //Read
        int type = reader.ReadInt();

        if(increasable.Type != type)
        {
            Log.Error($"Error while loading Increasable [{increasable.Type.GetNameOfValueType()}]. The read type is not equal. Read type: {type} [{type.GetNameOfValueType()}]");
        }

        int increaseValue = reader.ReadInt();

        //Apply
        Log.Verbose($"Restore Increasable Value [{increasable.Type.GetNameOfValueType()}] with {increaseValue}");
        increasable.IncreaseValue = increaseValue;
    }
}