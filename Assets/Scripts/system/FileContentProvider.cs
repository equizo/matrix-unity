using System.IO;

namespace system
{
  public class FileContentProvider : IFileContentProvider
  {
    public string Read(string file) =>
      File.ReadAllText(file);
  }
}