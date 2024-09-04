using System;
using System.Runtime.InteropServices;

namespace system
{
  public class MinimizeWindowHandler
  {
    [DllImport("user32.dll", EntryPoint = "ShowWindow")]
    private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

    [DllImport("user32.dll", EntryPoint = "GetActiveWindow")]
    private static extern IntPtr GetActiveWindow();

    private const int SWMinimize = 6;

    public void MinimizeUnityWindow()
    {
    #if !UNITY_EDITOR
      ShowWindow(GetActiveWindow(), SWMinimize);
    #endif
    }
  }
}