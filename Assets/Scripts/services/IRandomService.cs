using System.Collections.Generic;

namespace services
{
  public interface IRandomService
  {
    float Get(float boundary);
    float Get(float boundaryA, float boundaryB);
    int   Get(int boundary);
    int   Get(int boundaryA, int boundaryB);
    char  GetChar(string alphabet);
    int   Pop(List<int> collection);
    float Value { get; }
  }
}