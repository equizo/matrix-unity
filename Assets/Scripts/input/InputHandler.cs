using system;
using UnityEngine;

namespace input
{
  public class InputHandler : MonoBehaviour
  {
    #region Editor references

    [SerializeField] private KeyCode _exitKeyCode;

    #endregion

    private void Update() =>
      GetInput();

    private void GetInput()
    {
      if (Input.GetKeyDown(_exitKeyCode)) {
        Application.Quit();
      }
      else {
        if (Input.anyKey) {
          Minimize();
        }
      }
    }

    private void Minimize() =>
      new MinimizeWindowHandler().MinimizeUnityWindow();
  }
}