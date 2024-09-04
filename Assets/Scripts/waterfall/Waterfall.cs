using System.Collections.Generic;
using System.Linq;
using System.Text;
using factory;
using services;

namespace waterfall
{
  public class Waterfall
  {
    private const bool IsDebug = false;

    private readonly CascadeFactory _cascadesFactory;
    private readonly IRandomService _randomService;

    public readonly List<Cascade> Cascades = new();
    private readonly List<int> _columns;
    private readonly int _height;

    public Waterfall(CascadeFactory cascadesFactory, List<int> columns, int height)
    {
      _cascadesFactory = cascadesFactory;
      _height = height;
      _columns = columns;
    }

    public void Update(float deltaTime)
    {
      RemoveOldCascades();
      UpdateCascades(deltaTime);
      DebugWaterfall();
      ReleaseColumns();
    }

    private void RemoveOldCascades()
    {
      for (var i = Cascades.Count - 1; i >= 0; i--) {
        var cascade = Cascades[i];
        bool isOutOfMap = cascade.RowIndex - cascade.Length >= _height - 1;
        if (isOutOfMap) {
          Cascades.RemoveAt(i);
        }
      }
    }

    private void UpdateCascades(float deltaTime)
    {
      for (var i = 0; i < Cascades.Count; i++) {
        Cascades[i].Update(deltaTime);
      }
    }

    private void ReleaseColumns()
    {
      var cascades = Cascades
        .GroupBy(cascade => cascade.ColumnIndex)
        .Select(cascades => cascades.OrderBy(cascade => cascade.RowIndex)
          .First())
        .ToList();

      for (var i = 0; i < cascades.Count; i++) {
        var cascade = cascades[i];
        bool canReleaseColumn = cascade.RowIndex - cascade.Length >= 0;
        if (canReleaseColumn) {
          int index = cascade.ColumnIndex;
          if (!_columns.Contains(index)) {
            _columns.Add(index);
          }
        }
      }
    }

    public void AddCascade()
    {
      if (_columns.Count != 0) {
        Cascades.Add(_cascadesFactory.Get());
      }
    }

    private void DebugWaterfall()
    {
      if (!IsDebug) {
        return;
      }

      UnityEngine.Debug.Log($"------------ Cascades ({Cascades.Count}) ------------");
      for (var i = 0; i < Cascades.Count; i++) {
        var cascade = Cascades[i];
        char[] chars = cascade.Chars;
        StringBuilder sb = new StringBuilder($"{cascade.ColumnIndex}, {cascade.RowIndex} ({cascade.Length}): ");
        for (var j = 0; j < chars.Length; j++) {
          sb.Append(chars[j]);
        }

        UnityEngine.Debug.Log(sb.ToString());
      }
    }
  }
}