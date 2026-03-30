// Decompiled with JetBrains decompiler
// Type: InputInterceptorNS.MouseFlags
// Assembly: InputInterceptor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 604977C5-2ADE-4FC3-BFE8-4BBC3D0D606F
// Assembly location: D:\Code\Git\AutoMouse\keysim\WimKeySim\WimKeySim\bin\Debug\net6.0-windows\InputInterceptor.dll

using System;

#nullable disable
namespace InputInterceptorNS;

[Flags]
public enum MouseFlags : ushort
{
  MoveRelative = 0,
  MoveAbsolute = 1,
  VirtualDesktop = 2,
  AttributesChanged = 4,
  MoveWithoutCoalescing = 8,
  TerminalServicesSourceShadow = 256, // 0x0100
}
