// Decompiled with JetBrains decompiler
// Type: InputInterceptorNS.InterceptionMethods
// Assembly: InputInterceptor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 604977C5-2ADE-4FC3-BFE8-4BBC3D0D606F
// Assembly location: D:\Code\Git\AutoMouse\keysim\WimKeySim\WimKeySim\bin\Debug\net6.0-windows\InputInterceptor.dll

using System;
using System.Runtime.InteropServices;

#nullable disable
namespace InputInterceptorNS;

internal class InterceptionMethods
{
  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate IntPtr CreateContext();

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void DestroyContext(IntPtr context);

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate int GetPrecedence(IntPtr context, int device);

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void SetPrecedence(IntPtr context, int device, int precedence);

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate ushort GetFilter(IntPtr context, int device);

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate void SetFilter(IntPtr context, Predicate interception_predicate, ushort filter);

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate int Wait(IntPtr context);

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate int WaitWithTimeout(IntPtr context, ulong milliseconds);

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate int Send(IntPtr context, int device, ref Stroke stroke, uint nstroke);

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate int Receive(IntPtr context, int device, ref Stroke stroke, uint nstroke);

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate uint GetHardwareId(
    IntPtr context,
    int device,
    IntPtr hardware_id_buffer,
    uint buffer_size);

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate int IsInvalid(int device);

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate int IsKeyboard(int device);

  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  public delegate int IsMouse(int device);
}
