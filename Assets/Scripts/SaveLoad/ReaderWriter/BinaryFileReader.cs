using System.IO;
using System.Text;

public class BinaryFileReader : IFileReader
{
    private BinaryReader reader;
    private Stream stream;

    public void OpenFile(string file)
    {
        if (stream != null)
            CloseFile();

        stream = File.Open(file, FileMode.Open);
        reader = new BinaryReader(stream, Encoding.UTF8, false);
    }

    public void CloseFile()
    {
        if (reader == null) return;

        reader.Close();
        stream.Close();

        reader.Dispose();
        stream.Dispose();

        reader = null;
        stream = null;
    }

    public int ReadInt() => reader.ReadInt32();

    public float ReadFloat() => reader.ReadSingle();

    public string ReadString() => reader.ReadString();

    public bool ReadBool() => reader.ReadBoolean();
}
