using System;
using YamlDotNet.Serialization;

namespace DefaultNamespace.configuration
{
  [Serializable]
  public class MatrixConfig
  {
    [YamlMember(Alias = "time")]
    public TimeConfig Time;
    [YamlMember(Alias = "cascade")]
    public CascadeConfig Cascade;
    [YamlMember(Alias = "colors")]
    public ColorsConfig Colors;
  }
}