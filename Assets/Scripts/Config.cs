namespace DefaultNamespace
{
  public static class Config
  {
    private const float TimeScale = 0.5f * 1.8f;

    private const float CascadeTimer = 0.125f * TimeScale;
    private const float CascadeTimerSpeedUp = 0.35f;
    public static readonly (float, float) CascadeTimerBoundaries = (CascadeTimer, CascadeTimer * CascadeTimerSpeedUp);
    public static readonly (int, int) ShortCascadeLengthBoundaries = (2, 6);
    public const float CascadeCharChangeProbability =  0.03f;
    public const float AddCascadeInterval = 0.045f * TimeScale;
    public const float ShortCascadeProbability = 0.2f;
    public const float CascadeFullLengthPortion = 0.5f;
    public const float FastCascadeProbability = 0.1f;
    public const float RenderingInterval = CascadeTimer * CascadeTimerSpeedUp;

    // private const string EmptyChar = "  ";
    public const string EmptyChar = ".";
    public const string BackgroundColor = "#000000";
    public const string FirstCharColor = "#CFCFCF";
    public const string RegularCharColor = "#28791E";
    public static readonly string[] TrailCharColors = {
      "#003300",
      "#004C00",
      "#006600",
      "#008000",
      "#009900",
      "#00B200",
      "#00CC00"
    };
  }
}