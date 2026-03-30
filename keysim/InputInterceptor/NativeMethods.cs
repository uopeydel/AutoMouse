// Decompiled with JetBrains decompiler
// Type: InputInterceptorNS.NativeMethods
// Assembly: InputInterceptor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 604977C5-2ADE-4FC3-BFE8-4BBC3D0D606F
// Assembly location: D:\Code\Git\AutoMouse\keysim\WimKeySim\WimKeySim\bin\Debug\net6.0-windows\InputInterceptor.dll

using System;
using System.Runtime.InteropServices;

#nullable disable
namespace InputInterceptorNS;

internal class NativeMethods
{
  private const string KERNEL32 = "kernel32.dll";
  private const string USER32 = "user32.dll";

  [DllImport("kernel32.dll", SetLastError = true)]
  public static extern IntPtr LoadLibrary(string lpLibFileName);

  [DllImport("kernel32.dll", SetLastError = true)]
  public static extern bool FreeLibrary(IntPtr hLibModule);

  [DllImport("kernel32.dll", SetLastError = true)]
  public static extern IntPtr GetModuleHandle(string lpModuleName);

  [DllImport("kernel32.dll", SetLastError = true)]
  public static extern IntPtr GetProcAddress(IntPtr hModule, string lpProcName);

  [DllImport("kernel32.dll", SetLastError = true)]
  public static extern IntPtr GetCurrentProcess();

  [DllImport("kernel32.dll", SetLastError = true)]
  public static extern bool IsWow64Process(IntPtr hProcess, out bool Wow64Process);

  [DllImport("user32.dll", SetLastError = true)]
  public static extern bool GetCursorPos(out Win32Point lpPoint);

  [DllImport("user32.dll", SetLastError = true)]
  public static extern bool SetCursorPos(int x, int y);

  [DllImport("user32.dll", SetLastError = true)]
  public static extern int GetSystemMetrics(int nIndex);
}
