using System;
using YamlDotNet.Serialization;

namespace DefaultNamespace.configuration
{
  [Serializable]
  public class TimeConfig
  {
    [YamlMember(Alias = "scale")]
    public float TimeScale;
    [YamlMember(Alias = "update_cascade_interval")]
    public float UpdateCascadeInterval;
    [YamlMember(Alias = "add_cascade_interval")]
    public float AddCascadeInterval;
    [YamlMember(Alias = "cascade_speedup")]
    public float CascadeSpeedUp;
  }
}