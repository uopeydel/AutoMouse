// Decompiled with JetBrains decompiler
// Type: InputInterceptorNS.Predicate
// Assembly: InputInterceptor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 604977C5-2ADE-4FC3-BFE8-4BBC3D0D606F
// Assembly location: D:\Code\Git\AutoMouse\keysim\WimKeySim\WimKeySim\bin\Debug\net6.0-windows\InputInterceptor.dll

using System.Runtime.InteropServices;

#nullable disable
namespace InputInterceptorNS;

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public delegate bool Predicate(int device);
