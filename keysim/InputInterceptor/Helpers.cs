// Decompiled with JetBrains decompiler
// Type: InputInterceptorNS.Helpers
// Assembly: InputInterceptor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 604977C5-2ADE-4FC3-BFE8-4BBC3D0D606F
// Assembly location: D:\Code\Git\AutoMouse\keysim\WimKeySim\WimKeySim\bin\Debug\net6.0-windows\InputInterceptor.dll

using System.IO;
using System.Reflection;

#nullable disable
namespace InputInterceptorNS;

internal static class Helpers
{
  public static byte[] GetResource(string name)
  {
    TypeInfo typeInfo = typeof (Helpers).GetTypeInfo();
    using (Stream manifestResourceStream = typeInfo.Assembly.GetManifestResourceStream($"{typeInfo.Namespace}.Resources.{name}"))
    {
      byte[] buffer = new byte[manifestResourceStream.Length];
      manifestResourceStream.Read(buffer, 0, (int) manifestResourceStream.Length);
      return buffer;
    }
  }
}
