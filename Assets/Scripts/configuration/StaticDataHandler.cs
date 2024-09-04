using System.IO;
using system;
using UnityEngine;

namespace DefaultNamespace.configuration
{
  public static class StaticDataHandler
  {
    private static FileMonitor _fileMonitor;
    private static IFileContentProvider _fileContentProvider;

    public static void Init(IFileContentProvider fileContentProvider)
    {
      _fileContentProvider = fileContentProvider;
      string configFilePath = Path.Combine(Application.streamingAssetsPath, Config.ConfigFileName);
      ReadConfigFile(configFilePath);
      SubscribeToConfigFileUpdates(configFilePath);
    }

    private static void ReadConfigFile(string configFilePath) =>
      UpdateStaticData(_fileContentProvider.Read(configFilePath));

    private static void SubscribeToConfigFileUpdates(string configFilePath)
    {
      _fileMonitor = new FileMonitor(_fileContentProvider, configFilePath);
      _fileMonitor.OnConfigUpdated += UpdateStaticData;
    }

    private static void UpdateStaticData(string configFileContent) =>
      MatrixConfigCarrier.Init(YamlReader.Deserialize<MatrixConfig>(configFileContent));
  }
}