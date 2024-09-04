using System;
using YamlDotNet.Serialization;

namespace DefaultNamespace.configuration
{
  [Serializable]
  public class CascadeConfig
  {
    [YamlMember(Alias = "short_size_min")]
    public int ShortSizeMin;
    [YamlMember(Alias = "short_size_max")]
    public int ShortSizeMax;
    [YamlMember(Alias = "char_change_probability")]
    public float CharChangeProbability;
    [YamlMember(Alias = "short_probability")]
    public float ShortProbability;
    [YamlMember(Alias = "full_size_factor")]
    public float FullSizeFactor;
    [YamlMember(Alias = "fast_probability")]
    public float FastProbability;
  }
}