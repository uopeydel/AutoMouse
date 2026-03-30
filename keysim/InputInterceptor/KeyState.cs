// Decompiled with JetBrains decompiler
// Type: InputInterceptorNS.KeyState
// Assembly: InputInterceptor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 604977C5-2ADE-4FC3-BFE8-4BBC3D0D606F
// Assembly location: D:\Code\Git\AutoMouse\keysim\WimKeySim\WimKeySim\bin\Debug\net6.0-windows\InputInterceptor.dll

using System;

#nullable disable
namespace InputInterceptorNS;

[Flags]
public enum KeyState : ushort
{
  Down = 0,
  Up = 1,
  E0 = 2,
  E1 = 4,
  TermsrvSetLED = 8,
  TermsrvShadow = 16, // 0x0010
  TermsrvVKPacket = 32, // 0x0020
}
