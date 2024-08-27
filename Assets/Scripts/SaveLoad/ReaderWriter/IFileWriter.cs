public interface IFileWriter
{
    public void OpenFile(string fileName);
    public void CloseFile();

    public void Write(int intValue);
    public void Write(float floatValue);
    public void Write(string stringValue);
    public void Write(bool boolValue);
}
