// Decompiled with JetBrains decompiler
// Type: InputInterceptorNS.KeyboardFilter
// Assembly: InputInterceptor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 604977C5-2ADE-4FC3-BFE8-4BBC3D0D606F
// Assembly location: D:\Code\Git\AutoMouse\keysim\WimKeySim\WimKeySim\bin\Debug\net6.0-windows\InputInterceptor.dll

using System;

#nullable disable
namespace InputInterceptorNS;

[Flags]
public enum KeyboardFilter : ushort
{
  None = 0,
  All = 255, // 0x00FF
  KeyDown = 1,
  KeyUp = 2,
  KeyE0 = 4,
  KeyE1 = 8,
  KeyTermsrvSetLED = 16, // 0x0010
  KeyTermsrvShadow = 32, // 0x0020
  KeyTermsrvVKPacket = 64, // 0x0040
}
