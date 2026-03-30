// Decompiled with JetBrains decompiler
// Type: InputInterceptorNS.Hook`1
// Assembly: InputInterceptor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 604977C5-2ADE-4FC3-BFE8-4BBC3D0D606F
// Assembly location: D:\Code\Git\AutoMouse\keysim\WimKeySim\WimKeySim\bin\Debug\net6.0-windows\InputInterceptor.dll

using System;
using System.Collections.Generic;
using System.Threading;

#nullable disable
namespace InputInterceptorNS;

public abstract class Hook<TCallbackStroke> : IDisposable
{
  public IntPtr Context { get; private set; }

  public int Device { get; private set; }

  public int RandomDevice { get; private set; }

  public ushort FilterMode { get; private set; }

  public Predicate Predicate { get; private set; }

  public Hook<TCallbackStroke>.CallbackAction Callback { get; private set; }

  public Exception Exception { get; private set; }

  public bool Active { get; private set; }

  public Thread Thread { get; private set; }

  public bool IsInitialized => this.Context != IntPtr.Zero && this.Device != -1;

  public bool CanSimulateInput
  {
    get
    {
      if (!(this.Context != IntPtr.Zero))
        return false;
      return this.Device != -1 || this.RandomDevice != -1;
    }
  }

  public bool HasException => this.Exception != null;

  protected int AnyDevice => this.Device == -1 ? this.RandomDevice : this.Device;

  protected abstract void CallbackWrapper(ref Stroke stroke);

  public Hook(
    ushort filterMode,
    Predicate predicate,
    Hook<TCallbackStroke>.CallbackAction callback)
  {
    IntPtr context = InputInterceptor.CreateContext();
    List<DeviceData> deviceList = InputInterceptor.GetDeviceList(context, predicate);
    this.Context = context;
    this.Device = -1;
    this.RandomDevice = deviceList.Count > 0 ? deviceList[0].Device : -1;
    this.FilterMode = filterMode;
    this.Predicate = predicate;
    this.Callback = callback;
    this.Exception = (Exception) null;
    if (this.Context != IntPtr.Zero)
    {
      this.Active = filterMode != (ushort) 0 || callback != null;
      this.Thread = new Thread(new ThreadStart(this.InterceptionMain));
      this.Thread.Priority = this.Callback != null ? ThreadPriority.Highest : ThreadPriority.Normal;
      this.Thread.IsBackground = true;
      this.Thread.Start();
    }
    else
    {
      this.Active = false;
      this.Thread = (Thread) null;
    }
  }

  private void InterceptionMain()
  {
    InputInterceptor.SetFilter(this.Context, this.Predicate, this.FilterMode);
    Stroke stroke = new Stroke();
    while (this.Active)
    {
      int device = InputInterceptor.WaitWithTimeout(this.Context, 100UL);
      if (InputInterceptor.Receive(this.Context, device, ref stroke, 1U) > 0)
      {
        this.Device = device;
        if (this.Active)
        {
          if (this.Callback != null)
          {
            try
            {
              this.CallbackWrapper(ref stroke);
            }
            catch (Exception ex)
            {
              Console.WriteLine((object) ex);
              this.Exception = ex;
              this.Active = false;
            }
          }
        }
        InputInterceptor.Send(this.Context, device, ref stroke, 1U);
      }
    }
  }

  public void Dispose()
  {
    if (!(this.Context != IntPtr.Zero))
      return;
    if (this.Active)
    {
      this.Active = false;
      this.Thread.Join();
    }
    InputInterceptor.DestroyContext(this.Context);
    this.Context = IntPtr.Zero;
  }

  public delegate void CallbackAction(ref TCallbackStroke stroke);
}
