// Decompiled with JetBrains decompiler
// Type: InputInterceptorNS.MouseHook
// Assembly: InputInterceptor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 604977C5-2ADE-4FC3-BFE8-4BBC3D0D606F
// Assembly location: D:\Code\Git\AutoMouse\keysim\WimKeySim\WimKeySim\bin\Debug\net6.0-windows\InputInterceptor.dll

using System;
using System.Threading;

#nullable disable
namespace InputInterceptorNS;

public class MouseHook : Hook<MouseStroke>
{
  private const int SM_CXSCREEN = 0;
  private const int SM_CYSCREEN = 1;
  private static readonly int PrimaryScreenWidth = NativeMethods.GetSystemMetrics(0);
  private static readonly int PrimaryScreenHeight = NativeMethods.GetSystemMetrics(1);

  public MouseHook(MouseFilter filter = MouseFilter.None, Hook<MouseStroke>.CallbackAction callback = null)
    : base((ushort) filter, new Predicate(InputInterceptor.IsMouse), callback)
  {
  }

  public MouseHook(Hook<MouseStroke>.CallbackAction callback)
    : base(ushort.MaxValue, new Predicate(InputInterceptor.IsMouse), callback)
  {
  }

  protected override void CallbackWrapper(ref Stroke stroke) => this.Callback(ref stroke.Mouse);

  public bool SetMouseState(MouseState state, short rolling = 0)
  {
    if (!this.CanSimulateInput)
      return false;
    return InputInterceptor.Send(this.Context, this.AnyDevice, ref new Stroke()
    {
      Mouse = {
        State = state,
        Rolling = rolling
      }
    }, 1U) == 1;
  }

  public bool SimulateLeftButtonDown() => this.SetMouseState(MouseState.LeftButtonDown);

  public bool SimulateLeftButtonUp() => this.SetMouseState(MouseState.LeftButtonUp);

  public bool SimulateLeftButtonClick(int releaseDelay = 50)
  {
    if (!this.SimulateLeftButtonDown())
      return false;
    Thread.Sleep(releaseDelay);
    return this.SimulateLeftButtonUp();
  }

  public bool SimulateMiddleButtonDown() => this.SetMouseState(MouseState.MiddleButtonDown);

  public bool SimulateMiddleButtonUp() => this.SetMouseState(MouseState.MiddleButtonUp);

  public bool SimulateMiddleButtonClick(int releaseDelay = 50)
  {
    if (!this.SimulateMiddleButtonDown())
      return false;
    Thread.Sleep(releaseDelay);
    return this.SimulateMiddleButtonUp();
  }

  public bool SimulateRightButtonDown() => this.SetMouseState(MouseState.RightButtonDown);

  public bool SimulateRightButtonUp() => this.SetMouseState(MouseState.RightButtonUp);

  public bool SimulateRightButtonClick(int releaseDelay = 50)
  {
    if (!this.SimulateRightButtonDown())
      return false;
    Thread.Sleep(releaseDelay);
    return this.SimulateRightButtonUp();
  }

  public bool SimulateScrollDown(short rolling = 120)
  {
    return this.SetMouseState(MouseState.ScrollVertical, -rolling);
  }

  public bool SimulateScrollUp(short rolling = 120)
  {
    return this.SetMouseState(MouseState.ScrollVertical, rolling);
  }

  public Win32Point GetCursorPosition()
  {
    Win32Point lpPoint;
    NativeMethods.GetCursorPos(out lpPoint);
    return lpPoint;
  }

  public bool SetCursorPosition(Win32Point point, bool useWinAPI = false)
  {
    return this.SetCursorPosition(point.X, point.Y, useWinAPI);
  }

  public bool SetCursorPosition(int x, int y, bool useWinAPI = false)
  {
    if (useWinAPI)
      return NativeMethods.SetCursorPos(x, y);
    if (!this.CanSimulateInput)
      return false;
    return InputInterceptor.Send(this.Context, this.AnyDevice, ref new Stroke()
    {
      Mouse = {
        X = (int) ushort.MaxValue * x / (MouseHook.PrimaryScreenWidth - 1),
        Y = (int) ushort.MaxValue * y / (MouseHook.PrimaryScreenHeight - 1),
        Flags = MouseFlags.MoveAbsolute
      }
    }, 1U) == 1;
  }

  public bool MoveCursorBy(int dX, int dY, bool useWinAPI = false)
  {
    if (useWinAPI)
    {
      Win32Point cursorPosition = this.GetCursorPosition();
      return NativeMethods.SetCursorPos(cursorPosition.X + dX, cursorPosition.Y + dY);
    }
    if (!this.CanSimulateInput)
      return false;
    return InputInterceptor.Send(this.Context, this.AnyDevice, ref new Stroke()
    {
      Mouse = {
        X = dX,
        Y = dY,
        Flags = MouseFlags.MoveRelative
      }
    }, 1U) == 1;
  }

  private bool SmoothMoveCursorBy(
    Win32Point startPosition,
    int dX,
    int dY,
    int speed = 15,
    bool useWinAPI = false)
  {
    if (!this.CanSimulateInput)
      return false;
    if (dX == 0 && dY == 0)
      return true;
    if (Math.Abs(dX) >= Math.Abs(dY))
    {
      double num1 = (double) dY / (double) dX;
      int num2 = 0;
      for (int index = Math.Abs(dX / speed); num2 < index; ++num2)
      {
        if (!this.SetCursorPosition(startPosition.X + num2 * dX / index, (int) ((double) startPosition.Y + (double) (num2 * dX / index) * num1), useWinAPI))
          return false;
        Thread.Sleep(10);
      }
    }
    else
    {
      double num3 = (double) dX / (double) dY;
      int num4 = 0;
      for (int index = Math.Abs(dY / speed); num4 < index; ++num4)
      {
        if (!this.SetCursorPosition((int) ((double) startPosition.X + (double) (num4 * dY / index) * num3), startPosition.Y + num4 * dY / index, useWinAPI))
          return false;
        Thread.Sleep(10);
      }
    }
    return this.SetCursorPosition(startPosition.X + dX, startPosition.Y + dY, useWinAPI);
  }

  public bool SimulateMoveTo(Win32Point point, int speed = 15, bool useWinAPI = false)
  {
    return this.SimulateMoveTo(point.X, point.Y, speed, useWinAPI);
  }

  public bool SimulateMoveTo(int x, int y, int speed = 15, bool useWinAPI = false)
  {
    if (!this.CanSimulateInput)
      return false;
    Win32Point cursorPosition = this.GetCursorPosition();
    int dX = x - cursorPosition.X;
    int dY = y - cursorPosition.Y;
    return this.SmoothMoveCursorBy(cursorPosition, dX, dY, speed, useWinAPI);
  }

  public bool SimulateMoveBy(int dX, int dY, int speed = 15, bool useWinAPI = false)
  {
    return this.CanSimulateInput && this.SmoothMoveCursorBy(this.GetCursorPosition(), dX, dY, speed, useWinAPI);
  }
}
