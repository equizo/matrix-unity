using UnityEngine;

public class Map
{
  public (int, int) GetSize(Vector2 holderSize, float fontSize)
  {
    const float characterSizeScaleFactor = 0.500f;
    const int nonMonospaceFontError = 0;

    int columnCount = Mathf.FloorToInt(holderSize.x / (fontSize * characterSizeScaleFactor)) -
                      nonMonospaceFontError;

    float lineHeight = fontSize * 0.8f;
    int rowsCount = Mathf.FloorToInt(holderSize.y / lineHeight) - 2;

    return (columnCount, rowsCount);
  }
}