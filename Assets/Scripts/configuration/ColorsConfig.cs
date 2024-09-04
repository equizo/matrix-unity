using System;
using YamlDotNet.Serialization;

namespace DefaultNamespace.configuration
{
  [Serializable]
  public class ColorsConfig
  {
    [YamlMember(Alias = "background")]
    public string Background;
    [YamlMember(Alias = "first_character")]
    public string FirstCharacter;
    [YamlMember(Alias = "regular_character")]
    public string RegularCharacter;
    [YamlMember(Alias = "trail")]
    public string[] Trail;
  }
}