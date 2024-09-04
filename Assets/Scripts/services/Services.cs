using factory;

namespace services
{
  public class Services : IServices
  {
    public IRandomService   RandomService   { get; }
    public CascadeFactory   CascadeFactory  { get; }
    public IAlphabetCarrier AlphabetCarrier { get; }

    public Services()
    {
      RandomService = new UnityRandomService();
      AlphabetCarrier = new AlphabetCarrier(RandomService);
      CascadeFactory = new CascadeFactory(RandomService, AlphabetCarrier);
    }
  }
}