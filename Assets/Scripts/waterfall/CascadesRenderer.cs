using System.Collections.Generic;
using System.Linq;
using System.Text;
using DefaultNamespace;
using DefaultNamespace.extensions;
using TMPro;

namespace waterfall
{
  public class CascadesRenderer
  {
    private readonly TMP_Text _uiText;

    private readonly string[][] _rows;
    private readonly List<Cascade> _cascades;
    private readonly StringBuilder _result;

    public CascadesRenderer(List<Cascade> cascades, TMP_Text uiText, (int, int) map)
    {
      _cascades = cascades;
      _uiText = uiText;
      
      var mapSize = map.Item1 * map.Item2 + map.Item2 - 1;
      _result = new StringBuilder(mapSize);
      
      _rows = new string[map.Item2][];
      for (var i = 0; i < _rows.Length; i++) {
        _rows[i] = new string[map.Item1];
      }
    }

    public void Update()
    {
      ReadCascades();
      Render();
    }

    private void ReadCascades()
    {
      for (var i = _rows.Length - 1; i >= 0; i--) {
        var cascades = _cascades.FindAll(cascade => cascade.RowIndex >= i);
        if (cascades.Count == 0) {
          continue;
        }

        var row = _rows[i];
        
        for (var j = 0; j < row.Length; j++) {
          var cascadesInColumn = cascades.FindAll(cascade => cascade.ColumnIndex == j);
          if (cascadesInColumn.Count == 0) {
            row[j] = Config.EmptyChar.Paint(Config.BackgroundColor);
            continue;
          }
          
          var cascade = cascadesInColumn.Where(cascade1 => cascade1.RowIndex >= i).OrderBy(cascade1 => cascade1.RowIndex).FirstOrDefault();
          int diff = cascade.RowIndex - i;
            
          bool isAboveCascade = diff >= cascade.Length;
          if (isAboveCascade) {
            row[j] = Config.EmptyChar.Paint(Config.BackgroundColor);
          }
          else {
            row[j] = cascade.GetColoredChar(diff);
          }
        }
      }
    }
    
    private void Render()
    {
      _result.Clear();
      CombineResult();
      _uiText.SetText(_result);
    }

    private void CombineResult()
    {
      for (var i = 0; i < _rows.Length; i++) {
        var row = _rows[i];
        if (row.Length == 0) {
          continue;
        }
        
        for (var j = 0; j < row.Length; j++) {
          _result.Append(row[j]);
        }
        
        if (i < _rows.Length - 1) {
          _result.Append('\n');
        }
      }
    }
  }
}