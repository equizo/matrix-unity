using TMPro;
using UnityEngine;

namespace ui
{
  public class Ui : MonoBehaviour
  {
    #region Editor references

    [field:SerializeField] public TMP_Text Text { get; private set; }
    [SerializeField] private RectTransform _holder;

    #endregion

    public Vector2 HolderSize {
      get {
        var rect = _holder.rect;
        return new Vector2(rect.width, rect.height);
      }
    }
  }
}