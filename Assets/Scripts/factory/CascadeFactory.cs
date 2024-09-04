using System.Collections.Generic;
using DefaultNamespace;
using services;
using waterfall;

namespace factory
{
  public class CascadeFactory
  {
    private readonly IRandomService _randomService;
    private int _maxCascadeLength;
    private List<int> _columns;
    private readonly IAlphabetCarrier _alphabetCarrier;

    public CascadeFactory(IRandomService randomService, IAlphabetCarrier alphabetCarrier)
    {
      _alphabetCarrier = alphabetCarrier;
      _randomService = randomService;
    }

    public void Init((int, int) size, List<int> columns)
    {
      _columns = columns;
      _maxCascadeLength = size.Item2;
    }

    public Cascade Get()
    {
      int columnIndex = _randomService.Pop(_columns);
      bool isShortCascade = _randomService.Value <= Config.ShortCascadeProbability;
      var shortCascadeLengthBoundaries = Config.ShortCascadeLengthBoundaries;
      int length;
      if (isShortCascade) {
        length = _randomService.Get(shortCascadeLengthBoundaries.Item1, shortCascadeLengthBoundaries.Item2);
        return new Cascade(columnIndex, length, _randomService, _alphabetCarrier);
      }

      length = _randomService.Get((int) (_maxCascadeLength * Config.CascadeFullLengthPortion), _maxCascadeLength);
      return new Cascade(columnIndex, length, _randomService, _alphabetCarrier);
    }
  }
}