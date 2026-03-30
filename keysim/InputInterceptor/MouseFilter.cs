// Decompiled with JetBrains decompiler
// Type: InputInterceptorNS.MouseFilter
// Assembly: InputInterceptor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 604977C5-2ADE-4FC3-BFE8-4BBC3D0D606F
// Assembly location: D:\Code\Git\AutoMouse\keysim\WimKeySim\WimKeySim\bin\Debug\net6.0-windows\InputInterceptor.dll

using System;

#nullable disable
namespace InputInterceptorNS;

[Flags]
public enum MouseFilter : ushort
{
  None = 0,
  All = 65535, // 0xFFFF
  LeftButtonDown = 1,
  LeftButtonUp = 2,
  RightButtonDown = 4,
  RightButtonUp = 8,
  MiddleButtonDown = 16, // 0x0010
  MiddleButtonUp = 32, // 0x0020
  ExtraButton1Down = 64, // 0x0040
  ExtraButton1Up = 128, // 0x0080
  ExtraButton2Down = 256, // 0x0100
  ExtraButton2Up = 512, // 0x0200
  ScrollVertical = 1024, // 0x0400
  ScrollHorizontal = 2048, // 0x0800
  Move = 4096, // 0x1000
}
