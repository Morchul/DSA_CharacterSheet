public interface IFileReader
{
    public void OpenFile(string fileName);
    public void CloseFile();

    public int ReadInt();
    public float ReadFloat();
    public string ReadString();
    public bool ReadBool();
}