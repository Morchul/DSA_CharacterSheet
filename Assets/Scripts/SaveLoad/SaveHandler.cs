using DSA.Character;
using System.IO;
using UnityEngine;

[CreateAssetMenu(fileName = "New Save Handler", menuName = "Save Handler")]
public class SaveHandler : ScriptableObject
{
    [SerializeField]
    private SaveFileType saveFileType;

    public static string SAVE_DIRECTORY => Application.persistentDataPath;

    private CharacterSaveHandler characterSaveHandler;

    private CharacterSaveHandler CharacterSaveHandler
    {
        get
        {
            if(characterSaveHandler == null)
            {
                characterSaveHandler = new CharacterSaveHandler();
            }
            return characterSaveHandler;
        }
    }

    public string[] GetListOfCharacters()
    {
        return CharacterSaveHandler.GetListOfCharacters();
    }

    public void SaveCharacter(Character character)
    {
        IFileWriter filewriter = GetWriter();

        string filePath = GetFilePath(CharacterSaveHandler.GetSaveFileLocation(character));
        EnsureRequirements(filePath);

        try
        {
            filewriter.OpenFile(filePath);

            CharacterSaveHandler.Save(character, filewriter);
        }
        finally
        {
            filewriter.CloseFile();
        }
    }

    public void LoadCharacter(Character character)
    {
        IFileReader fileReader = GetReader();

        string filePath = GetFilePath(CharacterSaveHandler.GetSaveFileLocation(character));
        EnsureRequirements(filePath);

        try
        {
            fileReader.OpenFile(filePath);

            CharacterSaveHandler.Load(character, fileReader);
        }
        finally
        {
            fileReader.CloseFile();
        }
    }

    private string GetFilePath(string filePath)
    {
        return SAVE_DIRECTORY + filePath;
    }

    private void EnsureRequirements(string filePath)
    {
        string directoryPath = FileUtility.GetDirectoryPath(filePath);

        if (!Directory.Exists(directoryPath))
        {
            Directory.CreateDirectory(directoryPath);
        }
    }

    private IFileWriter GetWriter()
    {
        switch (saveFileType)
        {
            case SaveFileType.Binary: return new BinaryFileWriter();
            case SaveFileType.Readable: return new SimpleFileWriter();
        }
        return null;
    }

    private IFileReader GetReader()
    {
        switch (saveFileType)
        {
            case SaveFileType.Binary: return new BinaryFileReader();
            case SaveFileType.Readable: return new SimpleFileReader();
        }
        return null;
    }

    public enum SaveFileType
    {
        Binary,
        Readable
    }
}
