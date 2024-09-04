using System;
using System.IO;

namespace system
{
  public sealed class FileMonitor : IDisposable
  {
    public event Action<string> OnConfigUpdated = _ => { };

    private readonly FileSystemWatcher _watcher;
    private bool _isDisposed;
    private readonly IFileContentProvider _fileContentProvider;

    public FileMonitor(IFileContentProvider fileContentProvider, string filePath)
    {
      _fileContentProvider = fileContentProvider;
      _watcher = new FileSystemWatcher {
        Path = Path.GetDirectoryName(filePath),
        Filter = Path.GetFileName(filePath),
        NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.Size
      };

      _watcher.Changed += OnChanged;
      _watcher.EnableRaisingEvents = true;
    }

    private void OnChanged(object source, FileSystemEventArgs e)
    {
      Console.WriteLine($"File {e.FullPath} has been modified.");
      UpdateStaticData(e.FullPath);
    }

    private void UpdateStaticData(string filePath)
    {
      string content = _fileContentProvider.Read(filePath);
      OnConfigUpdated.Invoke(content);
    }

    public void Dispose()
    {
      Dispose(true);
      GC.SuppressFinalize(this);
    }

    private void Dispose(bool isDisposing)
    {
      if (_isDisposed) {
        return;
      }

      if (isDisposing) {
        _watcher.Changed -= OnChanged;
        _watcher.Dispose();
      }

      _isDisposed = true;
    }

    ~FileMonitor() =>
      Dispose(false);
  }
}