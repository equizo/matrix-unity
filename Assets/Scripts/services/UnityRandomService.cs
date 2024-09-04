using System.Collections.Generic;
using UnityEngine;

namespace services
{
  public class UnityRandomService : IRandomService
  {
    public float Get(float boundary) =>
      Get(0f, boundary);

    public float Get(float boundaryA, float boundaryB) =>
      Random.Range(boundaryA, boundaryB);

    public int Get(int boundary) =>
      Get(0, boundary);

    public int Get(int boundaryA, int boundaryB) =>
      Random.Range(boundaryA, boundaryB);

    public char GetChar(string alphabet) =>
      alphabet[Get(alphabet.Length)];

    public int Pop(List<int> collection)
    {
      int index = Get(collection.Count);
      int value = collection[index];
      collection.RemoveAt(index);
      return value;
    }

    public float Value =>
      Random.value;
  }
}