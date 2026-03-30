// Decompiled with JetBrains decompiler
// Type: InputInterceptorNS.KeyboardHook
// Assembly: InputInterceptor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 604977C5-2ADE-4FC3-BFE8-4BBC3D0D606F
// Assembly location: D:\Code\Git\AutoMouse\keysim\WimKeySim\WimKeySim\bin\Debug\net6.0-windows\InputInterceptor.dll

using System.Collections.Generic;
using System.Threading;

#nullable disable
namespace InputInterceptorNS;

public class KeyboardHook : Hook<KeyStroke>
{
  private static readonly Dictionary<char, KeyboardHook.KeyData> KeyDictionary = new Dictionary<char, KeyboardHook.KeyData>();
  private static readonly KeyboardHook.KeyData QuestionMark;

  static KeyboardHook()
  {
    KeyboardHook.KeyDictionary.Add('`', new KeyboardHook.KeyData()
    {
      Code = KeyCode.Tilde
    });
    KeyboardHook.KeyDictionary.Add('1', new KeyboardHook.KeyData()
    {
      Code = KeyCode.One
    });
    KeyboardHook.KeyDictionary.Add('2', new KeyboardHook.KeyData()
    {
      Code = KeyCode.Two
    });
    KeyboardHook.KeyDictionary.Add('3', new KeyboardHook.KeyData()
    {
      Code = KeyCode.Three
    });
    KeyboardHook.KeyDictionary.Add('4', new KeyboardHook.KeyData()
    {
      Code = KeyCode.Four
    });
    KeyboardHook.KeyDictionary.Add('5', new KeyboardHook.KeyData()
    {
      Code = KeyCode.Five
    });
    KeyboardHook.KeyDictionary.Add('6', new KeyboardHook.KeyData()
    {
      Code = KeyCode.Six
    });
    KeyboardHook.KeyDictionary.Add('7', new KeyboardHook.KeyData()
    {
      Code = KeyCode.Seven
    });
    KeyboardHook.KeyDictionary.Add('8', new KeyboardHook.KeyData()
    {
      Code = KeyCode.Eight
    });
    KeyboardHook.KeyDictionary.Add('9', new KeyboardHook.KeyData()
    {
      Code = KeyCode.Nine
    });
    KeyboardHook.KeyDictionary.Add('0', new KeyboardHook.KeyData()
    {
      Code = KeyCode.Zero
    });
    KeyboardHook.KeyDictionary.Add('-', new KeyboardHook.KeyData()
    {
      Code = KeyCode.Dash
    });
    KeyboardHook.KeyDictionary.Add('=', new KeyboardHook.KeyData()
    {
      Code = KeyCode.Equals
    });
    KeyboardHook.KeyDictionary.Add('q', new KeyboardHook.KeyData()
    {
      Code = KeyCode.Q
    });
    KeyboardHook.KeyDictionary.Add('w', new KeyboardHook.KeyData()
    {
      Code = KeyCode.W
    });
    KeyboardHook.KeyDictionary.Add('e', new KeyboardHook.KeyData()
    {
      Code = KeyCode.E
    });
    KeyboardHook.KeyDictionary.Add('r', new KeyboardHook.KeyData()
    {
      Code = KeyCode.R
    });
    KeyboardHook.KeyDictionary.Add('t', new KeyboardHook.KeyData()
    {
      Code = KeyCode.T
    });
    KeyboardHook.KeyDictionary.Add('y', new KeyboardHook.KeyData()
    {
      Code = KeyCode.Y
    });
    KeyboardHook.KeyDictionary.Add('u', new KeyboardHook.KeyData()
    {
      Code = KeyCode.U
    });
    KeyboardHook.KeyDictionary.Add('i', new KeyboardHook.KeyData()
    {
      Code = KeyCode.I
    });
    KeyboardHook.KeyDictionary.Add('o', new KeyboardHook.KeyData()
    {
      Code = KeyCode.O
    });
    KeyboardHook.KeyDictionary.Add('p', new KeyboardHook.KeyData()
    {
      Code = KeyCode.P
    });
    KeyboardHook.KeyDictionary.Add('[', new KeyboardHook.KeyData()
    {
      Code = KeyCode.OpenBracketBrace
    });
    KeyboardHook.KeyDictionary.Add(']', new KeyboardHook.KeyData()
    {
      Code = KeyCode.CloseBracketBrace
    });
    KeyboardHook.KeyDictionary.Add('a', new KeyboardHook.KeyData()
    {
      Code = KeyCode.A
    });
    KeyboardHook.KeyDictionary.Add('s', new KeyboardHook.KeyData()
    {
      Code = KeyCode.S
    });
    KeyboardHook.KeyDictionary.Add('d', new KeyboardHook.KeyData()
    {
      Code = KeyCode.D
    });
    KeyboardHook.KeyDictionary.Add('f', new KeyboardHook.KeyData()
    {
      Code = KeyCode.F
    });
    KeyboardHook.KeyDictionary.Add('g', new KeyboardHook.KeyData()
    {
      Code = KeyCode.G
    });
    KeyboardHook.KeyDictionary.Add('h', new KeyboardHook.KeyData()
    {
      Code = KeyCode.H
    });
    KeyboardHook.KeyDictionary.Add('j', new KeyboardHook.KeyData()
    {
      Code = KeyCode.J
    });
    KeyboardHook.KeyDictionary.Add('k', new KeyboardHook.KeyData()
    {
      Code = KeyCode.K
    });
    KeyboardHook.KeyDictionary.Add('l', new KeyboardHook.KeyData()
    {
      Code = KeyCode.L
    });
    KeyboardHook.KeyDictionary.Add(';', new KeyboardHook.KeyData()
    {
      Code = KeyCode.Semicolon
    });
    KeyboardHook.KeyDictionary.Add('\'', new KeyboardHook.KeyData()
    {
      Code = KeyCode.Apostrophe
    });
    KeyboardHook.KeyDictionary.Add('\\', new KeyboardHook.KeyData()
    {
      Code = KeyCode.Backslash
    });
    KeyboardHook.KeyDictionary.Add('z', new KeyboardHook.KeyData()
    {
      Code = KeyCode.Z
    });
    KeyboardHook.KeyDictionary.Add('x', new KeyboardHook.KeyData()
    {
      Code = KeyCode.X
    });
    KeyboardHook.KeyDictionary.Add('c', new KeyboardHook.KeyData()
    {
      Code = KeyCode.C
    });
    KeyboardHook.KeyDictionary.Add('v', new KeyboardHook.KeyData()
    {
      Code = KeyCode.V
    });
    KeyboardHook.KeyDictionary.Add('b', new KeyboardHook.KeyData()
    {
      Code = KeyCode.B
    });
    KeyboardHook.KeyDictionary.Add('n', new KeyboardHook.KeyData()
    {
      Code = KeyCode.N
    });
    KeyboardHook.KeyDictionary.Add('m', new KeyboardHook.KeyData()
    {
      Code = KeyCode.M
    });
    KeyboardHook.KeyDictionary.Add(',', new KeyboardHook.KeyData()
    {
      Code = KeyCode.Comma
    });
    KeyboardHook.KeyDictionary.Add('.', new KeyboardHook.KeyData()
    {
      Code = KeyCode.Dot
    });
    KeyboardHook.KeyDictionary.Add('/', new KeyboardHook.KeyData()
    {
      Code = KeyCode.Slash
    });
    KeyboardHook.KeyDictionary.Add(' ', new KeyboardHook.KeyData()
    {
      Code = KeyCode.Space
    });
    KeyboardHook.KeyDictionary.Add('~', new KeyboardHook.KeyData()
    {
      Code = KeyCode.Tilde,
      Shift = true
    });
    KeyboardHook.KeyDictionary.Add('!', new KeyboardHook.KeyData()
    {
      Code = KeyCode.One,
      Shift = true
    });
    KeyboardHook.KeyDictionary.Add('@', new KeyboardHook.KeyData()
    {
      Code = KeyCode.Two,
      Shift = true
    });
    KeyboardHook.KeyDictionary.Add('#', new KeyboardHook.KeyData()
    {
      Code = KeyCode.Three,
      Shift = true
    });
    KeyboardHook.KeyDictionary.Add('$', new KeyboardHook.KeyData()
    {
      Code = KeyCode.Four,
      Shift = true
    });
    KeyboardHook.KeyDictionary.Add('%', new KeyboardHook.KeyData()
    {
      Code = KeyCode.Five,
      Shift = true
    });
    KeyboardHook.KeyDictionary.Add('^', new KeyboardHook.KeyData()
    {
      Code = KeyCode.Six,
      Shift = true
    });
    KeyboardHook.KeyDictionary.Add('&', new KeyboardHook.KeyData()
    {
      Code = KeyCode.Seven,
      Shift = true
    });
    KeyboardHook.KeyDictionary.Add('*', new KeyboardHook.KeyData()
    {
      Code = KeyCode.Eight,
      Shift = true
    });
    KeyboardHook.KeyDictionary.Add('(', new KeyboardHook.KeyData()
    {
      Code = KeyCode.Nine,
      Shift = true
    });
    KeyboardHook.KeyDictionary.Add(')', new KeyboardHook.KeyData()
    {
      Code = KeyCode.Zero,
      Shift = true
    });
    KeyboardHook.KeyDictionary.Add('_', new KeyboardHook.KeyData()
    {
      Code = KeyCode.Dash,
      Shift = true
    });
    KeyboardHook.KeyDictionary.Add('+', new KeyboardHook.KeyData()
    {
      Code = KeyCode.Equals,
      Shift = true
    });
    KeyboardHook.KeyDictionary.Add('Q', new KeyboardHook.KeyData()
    {
      Code = KeyCode.Q,
      Shift = true
    });
    KeyboardHook.KeyDictionary.Add('W', new KeyboardHook.KeyData()
    {
      Code = KeyCode.W,
      Shift = true
    });
    KeyboardHook.KeyDictionary.Add('E', new KeyboardHook.KeyData()
    {
      Code = KeyCode.E,
      Shift = true
    });
    KeyboardHook.KeyDictionary.Add('R', new KeyboardHook.KeyData()
    {
      Code = KeyCode.R,
      Shift = true
    });
    KeyboardHook.KeyDictionary.Add('T', new KeyboardHook.KeyData()
    {
      Code = KeyCode.T,
      Shift = true
    });
    KeyboardHook.KeyDictionary.Add('Y', new KeyboardHook.KeyData()
    {
      Code = KeyCode.Y,
      Shift = true
    });
    KeyboardHook.KeyDictionary.Add('U', new KeyboardHook.KeyData()
    {
      Code = KeyCode.U,
      Shift = true
    });
    KeyboardHook.KeyDictionary.Add('I', new KeyboardHook.KeyData()
    {
      Code = KeyCode.I,
      Shift = true
    });
    KeyboardHook.KeyDictionary.Add('O', new KeyboardHook.KeyData()
    {
      Code = KeyCode.O,
      Shift = true
    });
    KeyboardHook.KeyDictionary.Add('P', new KeyboardHook.KeyData()
    {
      Code = KeyCode.P,
      Shift = true
    });
    KeyboardHook.KeyDictionary.Add('{', new KeyboardHook.KeyData()
    {
      Code = KeyCode.OpenBracketBrace,
      Shift = true
    });
    KeyboardHook.KeyDictionary.Add('}', new KeyboardHook.KeyData()
    {
      Code = KeyCode.CloseBracketBrace,
      Shift = true
    });
    KeyboardHook.KeyDictionary.Add('A', new KeyboardHook.KeyData()
    {
      Code = KeyCode.A,
      Shift = true
    });
    KeyboardHook.KeyDictionary.Add('S', new KeyboardHook.KeyData()
    {
      Code = KeyCode.S,
      Shift = true
    });
    KeyboardHook.KeyDictionary.Add('D', new KeyboardHook.KeyData()
    {
      Code = KeyCode.D,
      Shift = true
    });
    KeyboardHook.KeyDictionary.Add('F', new KeyboardHook.KeyData()
    {
      Code = KeyCode.F,
      Shift = true
    });
    KeyboardHook.KeyDictionary.Add('G', new KeyboardHook.KeyData()
    {
      Code = KeyCode.G,
      Shift = true
    });
    KeyboardHook.KeyDictionary.Add('H', new KeyboardHook.KeyData()
    {
      Code = KeyCode.H,
      Shift = true
    });
    KeyboardHook.KeyDictionary.Add('J', new KeyboardHook.KeyData()
    {
      Code = KeyCode.J,
      Shift = true
    });
    KeyboardHook.KeyDictionary.Add('K', new KeyboardHook.KeyData()
    {
      Code = KeyCode.K,
      Shift = true
    });
    KeyboardHook.KeyDictionary.Add('L', new KeyboardHook.KeyData()
    {
      Code = KeyCode.L,
      Shift = true
    });
    KeyboardHook.KeyDictionary.Add(':', new KeyboardHook.KeyData()
    {
      Code = KeyCode.Semicolon,
      Shift = true
    });
    KeyboardHook.KeyDictionary.Add('"', new KeyboardHook.KeyData()
    {
      Code = KeyCode.Apostrophe,
      Shift = true
    });
    KeyboardHook.KeyDictionary.Add('|', new KeyboardHook.KeyData()
    {
      Code = KeyCode.Backslash,
      Shift = true
    });
    KeyboardHook.KeyDictionary.Add('Z', new KeyboardHook.KeyData()
    {
      Code = KeyCode.Z,
      Shift = true
    });
    KeyboardHook.KeyDictionary.Add('X', new KeyboardHook.KeyData()
    {
      Code = KeyCode.X,
      Shift = true
    });
    KeyboardHook.KeyDictionary.Add('C', new KeyboardHook.KeyData()
    {
      Code = KeyCode.C,
      Shift = true
    });
    KeyboardHook.KeyDictionary.Add('V', new KeyboardHook.KeyData()
    {
      Code = KeyCode.V,
      Shift = true
    });
    KeyboardHook.KeyDictionary.Add('B', new KeyboardHook.KeyData()
    {
      Code = KeyCode.B,
      Shift = true
    });
    KeyboardHook.KeyDictionary.Add('N', new KeyboardHook.KeyData()
    {
      Code = KeyCode.N,
      Shift = true
    });
    KeyboardHook.KeyDictionary.Add('M', new KeyboardHook.KeyData()
    {
      Code = KeyCode.M,
      Shift = true
    });
    KeyboardHook.KeyDictionary.Add('<', new KeyboardHook.KeyData()
    {
      Code = KeyCode.Comma,
      Shift = true
    });
    KeyboardHook.KeyDictionary.Add('>', new KeyboardHook.KeyData()
    {
      Code = KeyCode.Dot,
      Shift = true
    });
    KeyboardHook.KeyDictionary.Add('?', new KeyboardHook.KeyData()
    {
      Code = KeyCode.Slash,
      Shift = true
    });
    KeyboardHook.QuestionMark = new KeyboardHook.KeyData()
    {
      Code = KeyCode.Slash,
      Shift = true
    };
  }

  public KeyboardHook(KeyboardFilter filter = KeyboardFilter.None, Hook<KeyStroke>.CallbackAction callback = null)
    : base((ushort) filter, new Predicate(InputInterceptor.IsKeyboard), callback)
  {
  }

  public KeyboardHook(Hook<KeyStroke>.CallbackAction callback)
    : base((ushort) byte.MaxValue, new Predicate(InputInterceptor.IsKeyboard), callback)
  {
  }

  protected override void CallbackWrapper(ref Stroke stroke) => this.Callback(ref stroke.Key);

  public bool SetKeyState(KeyCode code, KeyState state)
  {
    if (!this.CanSimulateInput)
      return false;
    return InputInterceptor.Send(this.Context, this.AnyDevice, ref new Stroke()
    {
      Key = {
        Code = code,
        State = state
      }
    }, 1U) == 1;
  }

  public bool SimulateKeyDown(KeyCode code) => this.SetKeyState(code, KeyState.Down);

  public bool SimulateKeyUp(KeyCode code) => this.SetKeyState(code, KeyState.Up);

  public bool SimulateKeyPress(KeyCode code, int releaseDelay = 75)
  {
    if (!this.SimulateKeyDown(code))
      return false;
    Thread.Sleep(releaseDelay);
    return this.SimulateKeyUp(code);
  }

  public bool SimulateInput(string text, int delayBetweenKeyPresses = 50, int releaseDelay = 75)
  {
    bool flag = false;
    foreach (char key in text)
    {
      KeyboardHook.KeyData questionMark;
      if (!KeyboardHook.KeyDictionary.TryGetValue(key, out questionMark))
        questionMark = KeyboardHook.QuestionMark;
      if (questionMark.Shift != flag)
      {
        if (questionMark.Shift)
        {
          if (!this.SetKeyState(KeyCode.LeftShift, KeyState.Down))
            return false;
        }
        else if (!this.SetKeyState(KeyCode.LeftShift, KeyState.Up))
          return false;
        flag = questionMark.Shift;
      }
      if (!this.SimulateKeyPress(questionMark.Code, releaseDelay))
        return false;
      Thread.Sleep(delayBetweenKeyPresses);
    }
    return !flag || this.SetKeyState(KeyCode.LeftShift, KeyState.Up);
  }

  private struct KeyData
  {
    public KeyCode Code;
    public bool Shift;
  }
}
