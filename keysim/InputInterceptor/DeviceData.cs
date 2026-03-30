// Decompiled with JetBrains decompiler
// Type: InputInterceptorNS.DeviceData
// Assembly: InputInterceptor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 604977C5-2ADE-4FC3-BFE8-4BBC3D0D606F
// Assembly location: D:\Code\Git\AutoMouse\keysim\WimKeySim\WimKeySim\bin\Debug\net6.0-windows\InputInterceptor.dll

using System.Collections.Generic;

#nullable disable
namespace InputInterceptorNS;

public class DeviceData
{
  public int Device;
  public string CompositeName;
  public List<string> Names;

  public DeviceData(int device, string rawCompositeName)
  {
    this.Device = device;
    this.CompositeName = string.Empty;
    this.Names = new List<string>();
    foreach (string str in rawCompositeName.Split(new char[1]))
    {
      if (str.Length > 0)
      {
        this.CompositeName += str;
        this.Names.Add(str);
      }
    }
  }
}
