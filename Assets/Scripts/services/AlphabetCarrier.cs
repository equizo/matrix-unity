namespace services
{
  public class AlphabetCarrier : IAlphabetCarrier
  {
    private readonly IRandomService _randomService;
    private readonly string _alphabet;

    public char RandomChar =>
      _randomService.GetChar(_alphabet);

    public AlphabetCarrier(IRandomService randomService, string alphabet)
    {
      _randomService = randomService;
      _alphabet = alphabet;
    }
  }
}