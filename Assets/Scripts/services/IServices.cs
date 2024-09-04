using factory;

namespace services
{
  public interface IServices
  {
    IRandomService   RandomService   { get; }
    CascadeFactory   CascadeFactory  { get; }
    IAlphabetCarrier AlphabetCarrier { get; }
  }
}