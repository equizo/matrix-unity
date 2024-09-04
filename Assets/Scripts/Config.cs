using DefaultNamespace.configuration;

namespace DefaultNamespace
{
  public static class Config
  {
    public const string ConfigFileName = "config.yaml";

    private static TimeConfig MatrixConfigTime =>
      MatrixConfigCarrier.MatrixConfig.Time;

    private static CascadeConfig MatrixConfigCascade =>
      MatrixConfigCarrier.MatrixConfig.Cascade;

    private static ColorsConfig MatrixConfigColors =>
      MatrixConfigCarrier.MatrixConfig.Colors;

    private static float TimeScale =>
      MatrixConfigTime.TimeScale;

    private static readonly float UpdateCascadeInterval = MatrixConfigTime.UpdateCascadeInterval * TimeScale;
    private static readonly float CascadeSpeedUp = MatrixConfigTime.CascadeSpeedUp;
    public static readonly (float, float) UpdateCascadeIntervalBoundaries =
      (UpdateCascadeInterval, UpdateCascadeInterval * CascadeSpeedUp);

    public static readonly (int, int) ShortCascadeLengthBoundaries =
      (MatrixConfigCascade.ShortSizeMin, MatrixConfigCascade.ShortSizeMax);
    public static readonly float CascadeCharChangeProbability = MatrixConfigCascade.CharChangeProbability;
    public static readonly float AddCascadeInterval = MatrixConfigTime.AddCascadeInterval * TimeScale;
    public static readonly float ShortCascadeProbability = MatrixConfigCascade.ShortProbability;
    public static readonly float CascadeFullLengthPortion = MatrixConfigCascade.FullSizeFactor;
    public static readonly float FastCascadeProbability = MatrixConfigCascade.FastProbability;
    public static readonly float RenderingInterval = UpdateCascadeInterval * CascadeSpeedUp;

    // private const string EmptyChar = "  ";
    public const string EmptyChar = ".";

    public static string BackgroundColor =>
      MatrixConfigColors.Background;

    public static string FirstCharColor =>
      MatrixConfigColors.FirstCharacter;

    public static string RegularCharColor =>
      MatrixConfigColors.RegularCharacter;

    public static string[] TrailCharColors =>
      MatrixConfigColors.Trail;

    // Add:
    // font size
    // background color to main camera background
  }
}