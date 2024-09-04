using YamlDotNet.Serialization;

namespace DefaultNamespace.configuration
{
  public static class YamlReader
  {
    public static T Deserialize<T>(string text) =>
      new DeserializerBuilder().Build().Deserialize<T>(text);
  }
}