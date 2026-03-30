// Decompiled with JetBrains decompiler
// Type: InputInterceptorNS.MouseStroke
// Assembly: InputInterceptor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 604977C5-2ADE-4FC3-BFE8-4BBC3D0D606F
// Assembly location: D:\Code\Git\AutoMouse\keysim\WimKeySim\WimKeySim\bin\Debug\net6.0-windows\InputInterceptor.dll

#nullable disable
namespace InputInterceptorNS;

public struct MouseStroke
{
  public MouseState State;
  public MouseFlags Flags;
  public short Rolling;
  public int X;
  public int Y;
  public uint Information;
}
