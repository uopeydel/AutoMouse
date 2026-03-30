// Decompiled with JetBrains decompiler
// Type: InputInterceptorNS.Win32Point
// Assembly: InputInterceptor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 604977C5-2ADE-4FC3-BFE8-4BBC3D0D606F
// Assembly location: D:\Code\Git\AutoMouse\keysim\WimKeySim\WimKeySim\bin\Debug\net6.0-windows\InputInterceptor.dll

#nullable disable
namespace InputInterceptorNS;

public struct Win32Point(int x, int y)
{
  public int X = x;
  public int Y = y;
}
