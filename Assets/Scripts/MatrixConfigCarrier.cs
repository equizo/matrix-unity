using DefaultNamespace.configuration;

namespace DefaultNamespace
{
  public static class MatrixConfigCarrier
  {
    public static MatrixConfig MatrixConfig;

    public static void Init(MatrixConfig matrixConfig)
    {
      MatrixConfig = matrixConfig;
      UnityEngine.Debug.Log($"{MatrixConfig.Time.TimeScale}");
    }
  }
}