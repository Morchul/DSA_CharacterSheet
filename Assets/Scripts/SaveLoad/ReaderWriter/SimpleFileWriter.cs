using System.IO;

public class SimpleFileWriter : IFileWriter
{
	private StreamWriter writer;

	public void CloseFile()
	{
		if (writer == null) return;

		writer.Close();
		writer.Dispose();
		writer = null;
	}

	public void OpenFile(string file)
	{
		if (writer != null)
			CloseFile();

		writer = new StreamWriter(file);
	}

	public void Write(int data)
	{
		writer.WriteLine(data);
	}

	public void Write(float data)
	{
		writer.WriteLine(data);
	}

	public void Write(string data)
	{
		writer.WriteLine(data);
	}

	public void Write(bool data)
	{
		writer.WriteLine(data);
	}

	public void Flush()
	{
		writer.Flush();
	}
}

