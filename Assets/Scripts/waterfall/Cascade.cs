using DefaultNamespace;
using DefaultNamespace.extensions;
using services;

namespace waterfall
{
  public class Cascade
  {
    public readonly int ColumnIndex;

    private string[] _colors;
    private readonly IRandomService _randomService;
    private readonly IAlphabetCarrier _alphabetCarrier;
    private readonly Timer _timer;

    private char RandomChar =>
      _alphabetCarrier.RandomChar;

    public int    RowIndex { get; private set; }
    public int    Length   { get; }
    public char[] Chars    { get; }

    public Cascade(int columnIndex, int length, IRandomService randomService, IAlphabetCarrier alphabetCarrier)
    {
      _alphabetCarrier = alphabetCarrier;
      _randomService = randomService;

      bool isFast = _randomService.Value <= Config.FastCascadeProbability;
      var period = isFast ? Config.CascadeTimerBoundaries.Item2 : Config.CascadeTimerBoundaries.Item1;
      _timer = new Timer(period);
      _timer.OnTick += Move;

      Length = length;
      ColumnIndex = columnIndex;
      GenerateColoredChars();
      Chars = new char[Length];
      for (var i = 0; i < Chars.Length; i++) {
        Chars[i] = '\0';
      }

      RowIndex = -1;
    }

    private void GenerateColoredChars()
    {
      _colors = new string[Length];
      _colors[0] = Config.FirstCharColor;
      for (int i = _colors.Length - 1, j = 0; i >= 1; i--, j++) {
        string[] trailCharColors = Config.TrailCharColors;
        _colors[i] = j < trailCharColors.Length ? trailCharColors[j] : Config.RegularCharColor;
      }
    }

    ~Cascade() =>
      _timer.OnTick -= Move;

    public void Update(float deltaTime) =>
      _timer.Update(deltaTime);

    private void Move()
    {
      ShiftChars();
      Chars[0] = RandomChar;
      RowIndex++;
    }

    private void ShiftChars()
    {
      for (int i = Chars.Length - 1; i >= 1; i--) {
        bool isOriginalCharSet = _randomService.Value > Config.CascadeCharChangeProbability;
        Chars[i] = isOriginalCharSet ? Chars[i - 1] : RandomChar;
      }
    }

    public string GetColoredChar(int index) =>
      Chars[index].Paint(_colors[index]);
  }
}