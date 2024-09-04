namespace services
{
  public class AlphabetCarrier : IAlphabetCarrier
  {
    private readonly IRandomService _randomService;

    // private const string Alphabet = "qwertyuiopasdfghjklzxcvbnm";
    private const string Alphabet = "ﾊﾐﾋｰｳｼﾅﾓﾆｻﾜﾂｵﾘｱﾎﾃﾏｹﾒｴｶｷﾑﾕﾗｾﾈｽﾀﾇﾍ0123456789<>.=*+-";
    // private const string Alphabet = "ﾊﾐﾋｰｳｼﾅﾓﾆｻﾜﾂｵﾘｱﾎﾃﾏｹﾒｴｶｷﾑﾕﾗｾﾈｽﾀﾇﾍ0123456789";

    public char RandomChar =>
      _randomService.GetChar(Alphabet);

    public AlphabetCarrier(IRandomService randomService) =>
      _randomService = randomService;
  }
}