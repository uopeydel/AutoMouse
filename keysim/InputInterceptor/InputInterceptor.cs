// Decompiled with JetBrains decompiler
// Type: InputInterceptorNS.InputInterceptor
// Assembly: InputInterceptor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 604977C5-2ADE-4FC3-BFE8-4BBC3D0D606F
// Assembly location: D:\Code\Git\AutoMouse\keysim\WimKeySim\WimKeySim\bin\Debug\net6.0-windows\InputInterceptor.dll

using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Principal;

#nullable disable
namespace InputInterceptorNS;

public static class InputInterceptor
{
  private static DllWrapper DllWrapper;
  public static bool Initialized = InputInterceptor.DllWrapper != null;

  public static bool Disposed
  {
    get
    {
      DllWrapper dllWrapper = InputInterceptor.DllWrapper;
      return dllWrapper == null || dllWrapper.Disposed;
    }
  }

  public static IntPtr CreateContext() => InputInterceptor.DllWrapper.CreateContext();

  public static void DestroyContext(IntPtr context)
  {
    InputInterceptor.DllWrapper.DestroyContext(context);
  }

  public static int GetPrecedence(IntPtr context, int device)
  {
    return InputInterceptor.DllWrapper.GetPrecedence(context, device);
  }

  public static void SetPrecedence(IntPtr context, int device, int precedence)
  {
    InputInterceptor.DllWrapper.SetPrecedence(context, device, precedence);
  }

  public static ushort GetFilter(IntPtr context, int device)
  {
    return InputInterceptor.DllWrapper.GetFilter(context, device);
  }

  public static void SetFilter(
    IntPtr context,
    Predicate interception_predicate,
    KeyboardFilter filter)
  {
    InputInterceptor.DllWrapper.SetFilter(context, interception_predicate, (ushort) filter);
  }

  public static void SetFilter(
    IntPtr context,
    Predicate interception_predicate,
    MouseFilter filter)
  {
    InputInterceptor.DllWrapper.SetFilter(context, interception_predicate, (ushort) filter);
  }

  public static void SetFilter(IntPtr context, Predicate interception_predicate, ushort filter)
  {
    InputInterceptor.DllWrapper.SetFilter(context, interception_predicate, filter);
  }

  public static int Wait(IntPtr context) => InputInterceptor.DllWrapper.Wait(context);

  public static int WaitWithTimeout(IntPtr context, ulong milliseconds)
  {
    return InputInterceptor.DllWrapper.WaitWithTimeout(context, milliseconds);
  }

  public static int Send(IntPtr context, int device, ref Stroke stroke, uint nstroke)
  {
    return InputInterceptor.DllWrapper.Send(context, device, ref stroke, nstroke);
  }

  public static int Receive(IntPtr context, int device, ref Stroke stroke, uint nstroke)
  {
    return InputInterceptor.DllWrapper.Receive(context, device, ref stroke, nstroke);
  }

  public static uint GetHardwareId(
    IntPtr context,
    int device,
    IntPtr hardware_id_buffer,
    uint buffer_size)
  {
    return InputInterceptor.DllWrapper.GetHardwareId(context, device, hardware_id_buffer, buffer_size);
  }

  public static bool IsInvalid(int device) => InputInterceptor.DllWrapper.IsInvalid(device) != 0;

  public static bool IsKeyboard(int device) => InputInterceptor.DllWrapper.IsKeyboard(device) != 0;

  public static bool IsMouse(int device) => InputInterceptor.DllWrapper.IsMouse(device) != 0;

  static InputInterceptor() => InputInterceptor.DllWrapper = (DllWrapper) null;

  public static bool Initialize()
  {
    if (InputInterceptor.Initialized)
      return true;
    try
    {
      InputInterceptor.DllWrapper = new DllWrapper(Helpers.GetResource($"interception_x{(IntPtr.Size == 8 ? "64" : "86")}.dll"));
      return true;
    }
    catch (Exception ex)
    {
      Console.WriteLine((object) ex);
      return false;
    }
  }

  public static bool Dispose()
  {
    if (InputInterceptor.Disposed)
      return true;
    try
    {
      InputInterceptor.DllWrapper.Dispose();
      InputInterceptor.DllWrapper = (DllWrapper) null;
      return true;
    }
    catch (Exception ex)
    {
      Console.WriteLine((object) ex);
      return false;
    }
  }

  public static bool CheckDriverInstalled()
  {
    RegistryKey registryKey1 = Registry.LocalMachine.OpenSubKey("SYSTEM").OpenSubKey("CurrentControlSet").OpenSubKey("Services");
    RegistryKey registryKey2 = registryKey1.OpenSubKey("keyboard");
    RegistryKey registryKey3 = registryKey1.OpenSubKey("mouse");
    return registryKey2 != null && registryKey3 != null && !((string) registryKey2.GetValue("DisplayName", (object) string.Empty) != "Keyboard Upper Filter Driver") && !((string) registryKey3.GetValue("DisplayName", (object) string.Empty) != "Mouse Upper Filter Driver");
  }

  public static bool CheckAdministratorRights()
  {
    return new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole((WindowsBuiltInRole) 544);
  }

  private static bool ExecuteInstaller(string arguments)
  {
    bool flag = false;
    if (InputInterceptor.CheckAdministratorRights())
    {
      string tempFileName = Path.GetTempFileName();
      try
      {
        File.WriteAllBytes(tempFileName, Helpers.GetResource("install-interception.exe"));
        Process process = new Process();
        process.StartInfo.FileName = tempFileName;
        process.StartInfo.Arguments = arguments;
        process.StartInfo.UseShellExecute = false;
        process.StartInfo.CreateNoWindow = true;
        process.Start();
        process.WaitForExit();
        flag = process.ExitCode == 0;
        File.Delete(tempFileName);
      }
      catch (Exception ex)
      {
        Console.WriteLine((object) ex);
      }
    }
    return flag;
  }

  public static bool InstallDriver()
  {
    return !InputInterceptor.CheckDriverInstalled() && InputInterceptor.ExecuteInstaller("/install");
  }

  public static bool UninstallDriver()
  {
    return InputInterceptor.CheckDriverInstalled() && InputInterceptor.ExecuteInstaller("/uninstall");
  }

  public static List<DeviceData> GetDeviceList(Predicate predicate = null)
  {
    IntPtr context = InputInterceptor.CreateContext();
    List<DeviceData> deviceList = InputInterceptor.GetDeviceList(context, predicate);
    InputInterceptor.DestroyContext(context);
    return deviceList;
  }

  public static List<DeviceData> GetDeviceList(IntPtr context, Predicate predicate = null)
  {
    List<DeviceData> deviceList = new List<DeviceData>();
    char[] chArray = new char[1024 /*0x0400*/];
    GCHandle gcHandle = GCHandle.Alloc((object) chArray, GCHandleType.Pinned);
    IntPtr hardware_id_buffer = gcHandle.AddrOfPinnedObject();
    for (int device = 1; device <= 20; ++device)
    {
      if ((predicate == null ? (!InputInterceptor.IsInvalid(device) ? 1 : 0) : (predicate(device) ? 1 : 0)) != 0)
      {
        uint hardwareId = InputInterceptor.GetHardwareId(context, device, hardware_id_buffer, (uint) chArray.Length);
        if (hardwareId > 0U)
        {
          string rawCompositeName = new string(chArray, 0, (int) hardwareId);
          deviceList.Add(new DeviceData(device, rawCompositeName));
        }
      }
    }
    gcHandle.Free();
    return deviceList;
  }
}
