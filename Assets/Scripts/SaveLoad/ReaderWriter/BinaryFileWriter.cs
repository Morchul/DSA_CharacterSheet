using System.IO;
using System.Text;

public class BinaryFileWriter : IFileWriter
{
    private BinaryWriter writer;
    private Stream stream;

    public void OpenFile(string file)
    {
        if (stream != null)
            CloseFile();

        stream = File.Open(file, FileMode.OpenOrCreate);
        writer = new BinaryWriter(stream, Encoding.UTF8, false);
    }

    public void CloseFile()
    {
        if (writer == null) return;

        writer.Close();
        stream.Close();

        writer.Dispose();
        stream.Dispose();

        writer = null;
        stream = null;
    }

    public void Write(int intValue)
    {
        writer.Write(intValue);
    }

    public void Write(float floatValue)
    {
        writer.Write(floatValue);
    }

    public void Write(string stringValue)
    {
        writer.Write(stringValue);
    }

    public void Write(bool boolValue)
    {
        writer.Write(boolValue);
    }
}
